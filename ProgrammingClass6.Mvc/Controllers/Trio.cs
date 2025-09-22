using Microsoft.AspNetCore.Mvc;

namespace Trio
{
    class Card
    {
        public int Value { get; set; }
        public bool IsOpen { get; set; } = false;
        public override string ToString() => IsOpen ? Value.ToString() : "[*]";
    }
    class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new();
        public List<List<int>> CollectedTrios { get; set; } = new();
        public Player(string name) => Name = name;
    }
    internal class Program
    {
        static Random rnd = new Random();
        static readonly List<List<int>> WinningTrios = new()
        {
            new() {1, 6, 8},
            new() {2, 5, 9},
            new() {3, 4, 10},
            new() {4, 3, 11},
            new() {5, 2, 12},
            new() {6, 1},
            new() {7},
            new() {8, 1},
            new() {9, 2},
            new() {10, 3},
            new() {11, 4},
            new() {12, 5},
        };
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Game TRIO");
            Console.WriteLine("Enter the number of players (2-4):");

            int playerCount = int.Parse(Console.ReadLine()!);

            List<Card> deck = CreateDeck();
            Shuffle(deck);

            List<Player> players = new();
            for (int i = 1; i <= playerCount; i++)
            {
                players.Add(new Player($"Player {i}"));
            }
            int cardsPerPlayer = playerCount
                switch
            {
                2 => 12,
                3 => 9,
                4 => 7,
                _ => 0,
            };

            foreach (var player in players)
            {
                for (int i = 0; i < cardsPerPlayer; i++)
                {
                    player.Hand.Add(deck[0]);
                    deck.RemoveAt(0);
                }
            }
            List<Card> table = deck;

            int currentPlayer = rnd.Next(playerCount);
            Console.WriteLine($"Goes first {players[currentPlayer].Name}");

            while (true)
            {
                Player player = players[currentPlayer];

                Console.WriteLine($"Walks {player.Name}");

                ShowState(players, table);

                Console.WriteLine("Select a card source");
                Console.WriteLine("1 - Open your minimum");
                Console.WriteLine("2 - Open your maximum");
                Console.WriteLine("3 - Open from another");
                Console.WriteLine("4 - Open on the table");

                List<Card> opened = new();

                while (true)
                {
                    Console.WriteLine("Your choice (or 0 to end the move): ");

                    int choice = int.Parse(Console.ReadLine()!);

                    if (choice == 0) break;

                    switch (choice)
                    {
                        case 1:
                            var min = player.Hand.MinBy(c => c.Value);
                            min.IsOpen = true;
                            opened.Add(min);
                            Console.WriteLine($"Opened my minimum {min.Value}");
                            break;

                        case 2:
                            var max = player.Hand.MaxBy(c => c.Value);
                            max.IsOpen = true;
                            opened.Add(max);
                            Console.WriteLine($"Opened my maximum {max.Value}");
                            break;

                        case 3:
                            Console.WriteLine("Please enter the player number: ");
                            int num = int.Parse(Console.ReadLine()!) - 1;

                            if (num == currentPlayer || num < 0 || num >= playerCount)
                            {
                                Console.WriteLine("It is forbidden");
                                break;
                            }
                            var other = players[num];
                            Console.WriteLine("1 - minimun, 2 - maximum");

                            int which = int.Parse(Console.ReadLine()!);

                            Card oc = (which == 1) ? other.Hand.MinBy(c => c.Value)! : other.Hand.MaxBy(c => c.Value)!;
                            oc.IsOpen = true;
                            opened.Add(oc);
                            Console.WriteLine($"Opened at {other.Name}:{oc.Value}");

                            break;
                        case 4:
                            Console.WriteLine("Display card index on table (0.." + (table.Count - 1) + "): ");

                            int idx = int.Parse(Console.ReadLine()!);

                            if (idx >= 0 && idx < table.Count)
                            {
                                table[idx].IsOpen = true;
                                opened.Add(table[idx]);
                                Console.WriteLine($"Opened it on the table {table[idx].Value}");
                            }
                            break;
                    }
                }

                if (opened.Count >= 3)
                {
                    var groups = opened.GroupBy(c => c.Value).Where(g => g.Count() == 3);

                    if (groups.Any())
                    {
                        var trio = groups.First().ToList();
                        Console.WriteLine($">>> {player.Name} collected TRIO {trio[0].Value}!");

                        player.CollectedTrios.Add(trio.Select(c => c.Value).ToList());

                        foreach (var c in trio)
                        {
                            foreach (var p in players)
                            {
                                p.Hand.Remove(c);
                                table.Remove(c);
                            }
                        }

                        foreach (var w in WinningTrios)
                        {
                            if (w.All(v => player.CollectedTrios.Any(t => t.Contains(v))))
                            {
                                Console.WriteLine($"\n{player.Name} won, by collecting a combo {string.Join(" , ", w)}!");
                                return;
                            }
                        }
                    }
                }

                foreach (var p in players)
                {
                    foreach (var c in p.Hand)
                    {
                        c.IsOpen = false;
                    }
                }

                foreach (var c in table)
                {
                    c.IsOpen = false;
                }

                currentPlayer = (currentPlayer + 1) % playerCount;
            }
        }
        static List<Card> CreateDeck()
        {
            List<Card> deck = new();

            for (int i = 1; i <= 12; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    deck.Add(new Card { Value = i });
                }
            }
            return deck;
        }
        static void Shuffle(List<Card> deck)
        {
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                (deck[i], deck[j]) = (deck[j], deck[i]);
            }
        }
        static void ShowState(List<Player> players, List<Card> table)
        {
            foreach (var p in players)
            {
                Console.Write($"{p.Name}: ");
                Console.WriteLine(string.Join(" ", p.Hand));
            }

            Console.WriteLine("Table: " + string.Join(" ", table));
        }
    }
}
