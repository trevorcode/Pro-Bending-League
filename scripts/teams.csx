#load "objects.csx"

using System.Text.Json;

public void BuildTeams()
{
    string playerJson;
    string teamsTemplate;

    using (var reader = new StreamReader("../test.json"))
    {
        playerJson = reader.ReadToEnd();
    }

    using (var reader = new StreamReader("../teamsTemplate.html"))
    {
        teamsTemplate = reader.ReadToEnd();
    }

    string newHtml = "";
    List<Player> players = JsonSerializer.Deserialize<List<Player>>(playerJson);

    foreach (var player in players)
    {
        string bendersList = player.Benders.Select(m => m.Name).ToString();
        newHtml += $"<tr><td>{player.Name}</td><td>{player.TeamName}</td><td>{string.Join(", ", player.Benders.Select(m=>m.Name).ToList())}</td></tr>";
    }

    var html = teamsTemplate.Replace("{{Teams}}", newHtml);

    using (var writer = new StreamWriter("../teams.html", false))
    {
        writer.Write(html);
    }
}