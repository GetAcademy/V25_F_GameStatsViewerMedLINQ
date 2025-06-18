using System.Text.Json.Serialization;

namespace GameStatsViewer;

internal class Achievement
{
    [JsonPropertyName("apiname")]
    public string Name { get; set; }
    [JsonPropertyName("achieved")]
    public int Achieved { get; set; }
    [JsonPropertyName("unlocktime")]
    public int UnixTimeSecondsUnlocked { get; set; }

    public DateTimeOffset DateAchieved => DateTimeOffset.FromUnixTimeSeconds(UnixTimeSecondsUnlocked);

    public override string ToString()
    {
        return $"""
                Achievement:
                Name: {Name}
                Achieved: {(Achieved == 1 ? "Yes" : "No")}
                Date achieved: {(Achieved == 1 ? DateAchieved : "Not yet!")}
                """;
    }
}