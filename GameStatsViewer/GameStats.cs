using System.Text.Json.Serialization;

namespace GameStatsViewer;

internal class GameStats
{
    [JsonPropertyName("appid")]
    public int AppId { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("playtime_forever")]
    public int PlaytimeInMinutes { get; set; }
    [JsonPropertyName("achievements")]
    public List<Achievement> Achievements { get; set; }

    public override string ToString()
    {
        return $"""
                -------------------------
                Name: {Name}
                App ID: {AppId}
                Playtime (minutes): {PlaytimeInMinutes} min
                Amount of achievements: {Achievements.Count}
                """;
    }
}