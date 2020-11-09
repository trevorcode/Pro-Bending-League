#load "objects.csx"

using System.Text.Json;
using System.Text.RegularExpressions;

public void BuildPlayerPages()
{
    string playerJson;
    string pageTemplate;

    using (var reader = new StreamReader("../test.json"))
    {
        playerJson = reader.ReadToEnd();
    }

    using (var reader = new StreamReader("../playerPageTemplate.html"))
    {
        pageTemplate = reader.ReadToEnd();
    }

    if (!Directory.Exists("../players"))
    {
        Directory.CreateDirectory("../players");
    }
    else {
        var di = new DirectoryInfo("../players");
        foreach (var file in di.GetFiles())
        {
            file.Delete();
        }
    }

    
    List<Player> players = JsonSerializer.Deserialize<List<Player>>(playerJson);

    foreach (var player in players)
    {
        var html = pageTemplate;

        html = html.Replace("{{Team Name}}", player.TeamName);
        html = html.Replace("{{Manager}}", player.Name);

        string waterbender = player.Benders.FirstOrDefault(b => b.Element == "Water")?.Name;
        string earthbender = player.Benders.FirstOrDefault(b => b.Element == "Earth")?.Name;
        string firebender = player.Benders.FirstOrDefault(b => b.Element == "Fire")?.Name;

        html = html.Replace("{{Waterbender}}", waterbender);
        html = html.Replace("{{Earthbender}}", earthbender);
        html = html.Replace("{{Firebender}}", firebender);
        html = html.Replace("{{ImageURL}}", player.ImageURL);
        
        Regex reg = new Regex("[^a-zA-Z]");
        string playerNamePage = reg.Replace(player.Name, string.Empty);

        using (var writer = new StreamWriter($"../players/{playerNamePage}.html", false))
        {
            writer.Write(html);
        }
    }

    

    
}

