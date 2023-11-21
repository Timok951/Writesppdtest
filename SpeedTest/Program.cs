using System.Runtime.InteropServices;
using System.Text.Json;

namespace SpeedTest
{
    internal class Program
    {
        public class UserData
        {
            public string Name;
            public int CharactersPerMinute;
            public int CharactersPerSecond;
        }

        public static class LeaderboardManager
        {
            private const string LeaderboardFilePath = "leaderboard.json";

            public static List<UserData> LoadLeaderboard()
            {
                if (File.Exists(LeaderboardFilePath))
                {
                    string json = File.ReadAllText(LeaderboardFilePath);
                    return JsonSerializer.Deserialize<List<UserData>>(json);
                }
                else
                {
                    return new List<UserData>();
                }
            }

            public static void SaveLeaderboard(List<UserData> leaderboard)
            {
                string json = JsonSerializer.Serialize(leaderboard);
                File.WriteAllText(LeaderboardFilePath, json);
            }

            public static void DisplayLeaderboard(List<UserData> leaderboard)
            {
                Console.WriteLine("Leaderboard:");

                if (leaderboard.Any())
                {
                    foreach (var userData in leaderboard)
                    {
                        Console.WriteLine($"{userData.Name}: {userData.CharactersPerMinute} CPM, {userData.CharactersPerSecond} CPS");
                    }
                }
                else
                {
                    Console.WriteLine("No records available.");
                }
            }

            public static void UpdateLeaderboard(UserData userData, List<UserData> leaderboard)
            {
                leaderboard.Add(userData);
                leaderboard = leaderboard.OrderByDescending(u => u.CharactersPerMinute).ToList();
                SaveLeaderboard(leaderboard);
            }
        }
        static void Main(string[] args)
        {
            string text = "У лукоморья дуб зелёный Златая цепь на дубе том:И днём и ночью кот учёный Всё ходит по цепи кругом; Идёт направо — песнь заводит, Налево — сказку говорит.";

            Console.WriteLine(text);
            Console.WriteLine("\nНажмите Enter для продолжения");
            ConsoleKeyInfo key = Console.ReadKey();


            char needKey = text[0];

            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine(text);
                Console.SetCursorPosition(0, 0);

                key = Console.ReadKey();

                if (key.KeyChar == needKey)
                {
                    Console.WriteLine('F');
                }
            }

        }
        }
    }
}