using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

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
                    File.Create("leaderboard.json");
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

        public static class Writetext {
            public static void text(){
            string text = "У лукоморья дуб зелёный;Златая цепь на дубе том: И днём и ночью кот учёный Всё ходит по цепи кругом; Идёт направо — песнь заводит,Налево — сказку говорит.";
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(text);
                   
                    int i = 0;
                    while (i+1 <= text.Length)
                    {
                    ConsoleKeyInfo key = Console.ReadKey();

                    char needKey = text[i];

                        if (key.KeyChar == needKey)
                        {
                            Console.SetCursorPosition(i, 0);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(i, 0);
                            Console.WriteLine(text[i]);
                            Console.SetCursorPosition(i + 1, 0);
                            i++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.WriteLine(text);
                            Console.SetCursorPosition(i, 0);
                            Console.SetCursorPosition(i, 0);
                        }
                    }
            }
        }
        static void Main(string[] args)
        {
            string text = "У лукоморья дуб зелёный;Златая цепь на дубе том: И днём и ночью кот учёный Всё ходит по цепи кругом; Идёт направо — песнь заводит,Налево — сказку говорит.";
            Console.WriteLine(text);
            Console.WriteLine("\nНажмите Enter для продолжения");

            ConsoleKeyInfo key = Console.ReadKey();

    while (true) { 
            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Enter your name");
                string userName = Console.ReadLine();

                Stopwatch stopwatch = Stopwatch.StartNew();
                Thread thread = new Thread(Writetext.text);
                
               
                Console.SetCursorPosition(0, 4);
                thread.Start();
                Console.Clear();

                while (true)
                {
                    Console.SetCursorPosition(0, 4);
                    Console.CursorVisible = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    TimeSpan ts = stopwatch.Elapsed;
                
                    int timer = 59 - ts.Seconds;
                    Console.Write(timer + " ");
                    Console.Write(ts.Minutes);
                    Console.SetCursorPosition(0, 3);
                    Console.Write("Ваш ввод ");
                    

                    if (ts.Minutes >= 1)
                    {
                        break;
                    }

                }
                Console.Clear();

                int totalCharacters = text.Length;
                int charactersTyped = text.Length;
                double charactersPerMinute = charactersTyped / 1;
                double charactersPerSecond = charactersTyped / 60;
                UserData userData = new UserData
                {
                    Name = userName,
                    CharactersPerMinute = (int)charactersPerMinute,
                    CharactersPerSecond = (int)charactersPerSecond
                };

                LeaderboardManager.DisplayLeaderboard(new List<UserData> { userData}); 
                LeaderboardManager.DisplayLeaderboard(new List<UserData> { userData}); 
                LeaderboardManager.UpdateLeaderboard(userData, LeaderboardManager.LoadLeaderboard());
            }
            }
           

           

            
     



        }
    }
}