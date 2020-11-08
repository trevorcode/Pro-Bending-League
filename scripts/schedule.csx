#load "objects.csx"

using System.Text.Json;

string playerJson;
string teamsTemplate;

using (var reader = new StreamReader("../test.json"))
{
    playerJson = reader.ReadToEnd();
}

using (var reader = new StreamReader("../scheduleTemplate.html"))
{
    teamsTemplate = reader.ReadToEnd();
}

string newHtml = "";
List<Player> players = JsonSerializer.Deserialize<List<Player>>(playerJson);

var currentDate = DateTime.Now.AddDays(5);

var groups = players.Select(m=>m.Group).ToList();
var listOfMatches = new List<Match>();

foreach(var group in groups)
{
    
    var playersInGroup = players.Where(m=>m.Group == group).ToList();
    playersInGroup.ForEach(player => {
        var opponents = playersInGroup.Where(m=>m.Name != player.Name).ToList();
        foreach(var opponent in opponents)
        {
            if (!listOfMatches.Any(m=>m.Team1 == opponent.TeamName && m.Team2 == player.TeamName || 
            m.Team1 == player.TeamName && m.Team2 == opponent.TeamName))
            {
                listOfMatches.Add(new Match() {
                    Team1 = player.TeamName, 
                    Team2 = opponent.TeamName,
                    Team1Player = player.Name,
                    Team2Player = opponent.Name});
            }
        }
    });
}

foreach(var match in listOfMatches) {
    newHtml += $@"<tr>
    <td>{currentDate.ToShortDateString()}</td>
    <td>{match.Team1} : {match.Team1Player}</td>
    <td>vs</td>
    <td>{match.Team2} : {match.Team2Player}</td>
    </tr>";
    currentDate = currentDate.AddDays(1);
}

var html = teamsTemplate.Replace("{{Schedule}}", newHtml);

using (var writer = new StreamWriter("../schedule.html", false)) {
    writer.Write(html);
}

public class Match {
    public string Team1 { get; set; }
    public string Team1Player { get; set; }
    public string Team2 { get; set; }
    public string Team2Player { get; set; }
}