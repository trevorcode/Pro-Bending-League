#load "objects.csx"

using System.Text.Json;
using System.Text.RegularExpressions;

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
        Regex reg = new Regex("[^a-zA-Z]");
        string teamLink = reg.Replace(player.Name, string.Empty);

        string bendersList = player.Benders.Select(m => m.Name).ToString();
        newHtml += $"<tr><td>{player.Name}</td><td><a href=\"players/{teamLink}.html\">{player.TeamName}</a></td><td>{string.Join(", ", player.Benders.Select(m=>m.Name).ToList())}</td></tr>";
    }

    var html = teamsTemplate.Replace("{{Teams}}", newHtml);

    using (var writer = new StreamWriter("../teams.html", false))
    {
        writer.Write(html);
    }
}