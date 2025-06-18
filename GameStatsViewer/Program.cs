using System.Text.Json;
using GameStatsViewer;

var json = File.ReadAllText("steamgames.json");

var root = JsonSerializer.Deserialize<Root>(json);

var gameStatsApp = new GameStatsViewerApp(root.response.games);
gameStatsApp.Run();
