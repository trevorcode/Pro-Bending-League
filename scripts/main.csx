using System.Text.Json;

List<Player> players = new List<Player>();
players.Add( new Player("Blastoise101", "The Zaofu Badgermoles", 1));
players.Add( new Player("IbbiX","Sleak JaguaRavens", 1));
players.Add( new Player("Machi102","Nan Shan Narhwal-horses", 1));
players.Add( new Player("bignoselogan","Omashu Rhinobears", 1));
players.Add( new Player("AbusiveUnicorn","Lethal ladies of Lake Loagai", 2));
players.Add( new Player("Gunchar16","", 2));
players.Add( new Player("blahblahjdlfk","Be the leaf", 2));
players.Add( new Player("Uno","Team 1/3 Bald", 2));
players.Add( new Player("Jedi271","The Nomadic Elementals", 3));
players.Add( new Player("Quenchy_CactusJuice","", 3));
players.Add( new Player("grjnfrukbf","The anarchists", 3));
players.Add( new Player("Vaxiffy_","The Bend It Like Beifongs", 4));
players.Add( new Player("IUsedToBeRa'sAlGhul","The Rampaging Raptorbeetles", 4));
players.Add( new Player("MorningPants","The Cougar-Sharks", 4));

var json = JsonSerializer.Serialize(players);
var writer = new StreamWriter("../test.json", false);
writer.Write(json);
writer.Close();

public class Player
{
    public Player(string name, string teamName, int group)
    {
        Name = name;
        TeamName = teamName;
        Group = group;
        Benders = new List<Bender>();
    }

    public string Name { get; set; }
    public string TeamName { get; set; }
    public int Group { get; set; }
    public List<Bender> Benders { get; set; }
}

public class Bender {
    public string Name{ get; set; }
    public string Element { get; set; }
}
