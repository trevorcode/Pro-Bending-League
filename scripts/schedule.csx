#load "objects.csx"

using System.Text.Json;
using System.Text.RegularExpressions;

public void BuildSchedule()
{

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

    var currentDate = DateTime.Now.AddDays(3);

    var groups = players.Select(m => m.Group).ToList();
    var listOfMatches = new List<Match>();

    foreach (var group in groups)
    {

        var playersInGroup = players.Where(m => m.Group == group).ToList();
        playersInGroup.ForEach(player =>
        {
            var opponents = playersInGroup.Where(m => m.Name != player.Name).ToList();
            foreach (var opponent in opponents)
            {
                if (!listOfMatches.Any(m => m.Team1 == opponent.TeamName && m.Team2 == player.TeamName ||
                m.Team1 == player.TeamName && m.Team2 == opponent.TeamName))
                {
                    listOfMatches.Add(new Match()
                    {
                        Group = player.Group,
                        Team1 = player.TeamName,
                        Team2 = opponent.TeamName,
                        Team1Player = player.Name,
                        Team2Player = opponent.Name
                    });
                }
            }
        });
    }

    //randomize list
    //listOfMatches = listOfMatches.OrderBy(a => Guid.NewGuid()).ToList();

    List<List<Match>> listOfMatchesByGroup = new List<List<Match>>();

    foreach (int i in listOfMatches.Select(g => g.Group).Distinct())
    {
        listOfMatchesByGroup.Add(listOfMatches.Where(m => m.Group == i).ToList());
    }


    List<Match> realListOfMatches = new List<Match>();

    while (listOfMatchesByGroup.Any(m => m.Count > 0))
    {
        foreach (var matchGroup in listOfMatchesByGroup)
        {
            if (matchGroup.Count > 0)
            {
                realListOfMatches.Add(matchGroup.FirstOrDefault());
                matchGroup.RemoveAt(0);
            }

        }
    }


    foreach (var match in realListOfMatches)
    {
        Regex reg = new Regex("[^a-zA-Z]");
        string team1Link = reg.Replace(match.Team1Player, string.Empty);
        string team2Link = reg.Replace(match.Team2Player, string.Empty);

        newHtml += $@"<tr>
    <td>{match.Group}</td>
    <td>{currentDate.ToShortDateString()}</td>
    <td><a href='/players/{team1Link}.html'>{match.Team1} : {match.Team1Player}</a></td>
    <td>vs</td>
    <td><a href='/players/{team2Link}.html'>{match.Team2} : {match.Team2Player}</a></td>
    </tr>";
        currentDate = currentDate.AddDays(1);
    }

    var html = teamsTemplate.Replace("{{Schedule}}", newHtml);

    using (var writer = new StreamWriter("../schedule.html", false))
    {
        writer.Write(html);
    }
}

public class Match
{
    public int Group { get; set; }
    public string Team1 { get; set; }
    public string Team1Player { get; set; }
    public string Team2 { get; set; }
    public string Team2Player { get; set; }
}