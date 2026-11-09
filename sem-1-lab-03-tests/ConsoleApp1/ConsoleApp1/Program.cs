using System;
using System.IO;
using System.Globalization;
namespace lab03
{
    class Program
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines("event_server.log");
            string report = BuildReport(lines);
            Console.WriteLine(report);
        }
        public static string BuildReport(string[] lines)
        {
            bool isEventRunning = false;
            int warnings = 0;
            int errors = 0;

            string ConsolationPoints = "";
            string items = "";
            string winner = "";
            string points = "";
            DateTime EventDate = DateTime.MinValue;

            foreach (string line in lines)
            {
                if (line.Contains("Событие началось:"))
                {
                    isEventRunning = true;
                    EventDate = DateTime.ParseExact(line.Substring(0, 23),"yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                }
                if (!isEventRunning)
                {
                    continue;
                }
                if (line.Contains("[Warning]"))
                {
                    warnings++;
                }
                if (line.Contains("[Error]"))
                {
                    errors++;
                }
                if (line.Contains("Событие \"Восстание Ледяного Пламени\" закрыто"))
                {
                    isEventRunning = false;
                    break;
                }
                if (line.Contains(" объявлены победителями"))
                {
                    int messageStart = line.IndexOf("] ") + 2;
                    int winnerEnd = line.IndexOf(" объявлены победителями");
                    winner = line.Substring(messageStart, winnerEnd - messageStart);
                }
                if (winner != "" && line.Contains(winner + " получили ") && line.Contains(" очков события") && !line.Contains("утешительную награду:"))
                {
                    int pointStars = line.IndexOf(winner + " получили ") + (winner + " получили ").Length;
                    int pointEnd = line.IndexOf(" очков события");
                    string pointWinner = line.Substring(pointStars, pointEnd - pointStars);
                    int winnerPoints = int.Parse(pointWinner);
                    points = winnerPoints.ToString();
                }
                if (line.Contains("получили ивентовый предмет: "))
                {
                    int itemStart = line.IndexOf("получили ивентовый предмет: ") + "получили ивентовый предмет: ".Length;
                    items = line.Substring(itemStart);
                }
                if (line.Contains("утешительную награду: "))
                {
                    string marker = "утешительную награду: ";
                    int consolationStart = line.IndexOf(marker) + marker.Length;
                    int consolationEnd = line.IndexOf(" очков", consolationStart);
                    string consolation = line.Substring(consolationStart, consolationEnd - consolationStart);
                    ConsolationPoints = consolation;
                }

            }
            return $"# Итоги события: Восстание Ледяного Пламени\n" + 
                $"Дата: {EventDate:dd.MM.yyyy}\n" + 
                $"Победитель: {winner}\n" + 
                $"Очки победителя: {points}\n" + 
                $"Ивентовый предмет: {items}\n" + 
                $"Утешительная награда: {ConsolationPoints}\n" + 
                $"Предупреждения: {warnings}\n" + 
                $"Ошибки: {errors}";
        }
    }
}