using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStatsViewer
{
    internal class GameStatsViewerApp
    {
        private List<GameStats> _games;

        public GameStatsViewerApp(List<GameStats> games)
        {
            _games = games;
        }

        public void Run()
        {
            while (true)
            {
                Menu();
            }
        }

        private void Menu()
        {
            Console.WriteLine($"""
                               {GameMenuStats()}
                               ***********************************************************************
                               Welcome to GameStatsViewer!
                               1) Show all games
                               2) Exit
                               """);
            HandleInput();
        }


        private string GameMenuStats()
        {
            return $"""
                    Amount of games: {_games.Count}
                    Most played game: {_games.OrderByDescending(g => g.PlaytimeInMinutes).FirstOrDefault()?.Name}
                    Total time (all games): {TimeSpan.FromMinutes(_games.Sum(g => g.PlaytimeInMinutes)).TotalHours} hours
                    Total "perfect" games: {_games.Count(g => g.Achievements.All(a => a.Achieved == 1))}
                    Least played game: {_games.OrderBy(g => g.PlaytimeInMinutes).FirstOrDefault()?.Name}
                    """;
        }
        private void HandleInput()
        {
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ShowAllGamesMenu();
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong input.");
                    Console.Clear();
                    break;
            }
        }

        private void ShowAllGamesMenu()
        {
            Console.WriteLine("All games:");
            foreach (var game in _games)
            {
                Console.WriteLine(game.ToString());
            }

            Console.WriteLine("Write the name of a game for more info:");
            var input = Console.ReadLine();

            var selectedGames = _games.Where(g => g.Name.ToLower().Contains(input.ToLower()));

            if (!selectedGames.Any())
            {
                Console.WriteLine("No games found!!!!!!!!!!!!");
            }

            //IsValidInput(input);

            foreach (var game in selectedGames)
            {
                Console.WriteLine(game.ToString());
                foreach (var achievement in game.Achievements)
                {
                    Console.WriteLine(achievement.ToString());
                }
            }
        }

        //private void IsValidInput(string input)
        //{
        //    if(selected)
        //}
    }
}
