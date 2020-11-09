#load "objects.csx"

using System.Text.Json;

public void BuildJson()
{
    List<Player> players = new List<Player>();
    Player newPlayer;

    newPlayer = new Player("Blastoise101", "The Zaofu Badgermoles", 1);
    newPlayer.Benders.Add(new Bender("Wan", "Fire"));
    newPlayer.Benders.Add(new Bender("Suyin", "Earth"));
    newPlayer.Benders.Add(new Bender("Kuruk", "Water"));
    players.Add(newPlayer);

    newPlayer = new Player("IbbiX", "Sleek JaguaRavens", 1);
    newPlayer.Benders.Add(new Bender("Iroh II", "Fire"));
    newPlayer.Benders.Add(new Bender("Bolin", "Earth"));
    newPlayer.Benders.Add(new Bender("Liling", "Water"));
    newPlayer.ImageURL = "/images/SleekJaguaravens.jpg";
    players.Add(newPlayer);

    newPlayer = new Player("Machi102", "Nan Shan Narhwal-horses", 1);
    newPlayer.Benders.Add(new Bender("Azula", "Fire"));
    newPlayer.Benders.Add(new Bender("Ikki", "Earth"));
    newPlayer.Benders.Add(new Bender("Tarrlok", "Water"));
    players.Add(newPlayer);

    newPlayer = new Player("bignoselogan", "Omashu Rhinobears", 1);
    newPlayer.Benders.Add(new Bender("Jeong Jeong", "Fire"));
    newPlayer.Benders.Add(new Bender("Jianzhu", "Earth"));
    newPlayer.Benders.Add(new Bender("Aang", "Water"));
    newPlayer.ImageURL = "/images/OmashuRhinobears.png";
    players.Add(newPlayer);

    newPlayer = new Player("AbusiveUnicorn", "Lethal ladies of Lake Loagai", 2);
    newPlayer.Benders.Add(new Bender("Rangi", "Fire"));
    newPlayer.Benders.Add(new Bender("Kuvira", "Earth"));
    newPlayer.Benders.Add(new Bender("Jinora", "Water"));
    players.Add(newPlayer);

    newPlayer = new Player("Gunchar16", "gunchar team", 2);
    newPlayer.Benders.Add(new Bender("Mako", "Fire"));
    newPlayer.Benders.Add(new Bender("Xin Fu", "Earth"));
    newPlayer.Benders.Add(new Bender("Ming Hua", "Water"));
    players.Add(newPlayer);

    newPlayer = new Player("blahblahjdlfk", "Be the leaf", 2);
    newPlayer.Benders.Add(new Bender("Meelo", "Fire"));
    newPlayer.Benders.Add(new Bender("Kyoshi", "Earth"));
    newPlayer.Benders.Add(new Bender("Korra", "Water"));
    players.Add(newPlayer);


    newPlayer = new Player("Uno", "Team 1/3 Bald", 2);
    newPlayer.Benders.Add(new Bender("Roku", "Fire"));
    newPlayer.Benders.Add(new Bender("The Boulder", "Earth"));
    newPlayer.Benders.Add(new Bender("Zaheer", "Water"));
    players.Add(newPlayer);


    newPlayer = new Player("Jedi271", "The Nomadic Elementals", 3);
    newPlayer.Benders.Add(new Bender("Yangchen", "Fire"));
    newPlayer.Benders.Add(new Bender("Opal", "Earth"));
    newPlayer.Benders.Add(new Bender("Tenzin", "Water"));
    players.Add(newPlayer);

    newPlayer = new Player("Quenchy_CactusJuice", "quenchy's team", 3);
    newPlayer.Benders.Add(new Bender("Ozai", "Fire"));
    newPlayer.Benders.Add(new Bender("Yaling", "Earth"));
    newPlayer.Benders.Add(new Bender("Katara", "Water"));
    players.Add(newPlayer);

    newPlayer = new Player("grjnfrukbf", "The anarchists", 3);
    newPlayer.Benders.Add(new Bender("Combustion Man", "Fire"));
    newPlayer.Benders.Add(new Bender("Tokuga", "Earth"));
    newPlayer.Benders.Add(new Bender("Takaga", "Water"));
    players.Add(newPlayer);

    newPlayer = new Player("samastrom16", "samastrom16 team", 3);
    newPlayer.Benders.Add(new Bender("Asami", "Fire"));
    newPlayer.Benders.Add(new Bender("Ghazan", "Earth"));
    newPlayer.Benders.Add(new Bender("Eska", "Water"));
    players.Add(newPlayer);

    newPlayer = new Player("Vaxiffy_", "The Bend It Like Beifongs", 4);
    newPlayer.Benders.Add(new Bender("Zuko", "Fire"));
    newPlayer.Benders.Add(new Bender("King Bumi", "Earth"));
    newPlayer.Benders.Add(new Bender("Pakku", "Water"));
    players.Add(newPlayer);


    newPlayer = new Player("IUsedToBeRa'sAlGhul", "The Rampaging Raptorbeetles", 4);
    newPlayer.Benders.Add(new Bender("Hei-Ran", "Fire"));
    newPlayer.Benders.Add(new Bender("Yun", "Earth"));
    newPlayer.Benders.Add(new Bender("Sokka", "Water"));
    players.Add(newPlayer);

    newPlayer = new Player("MorningPants", "The Cougar-Sharks", 4);
    newPlayer.Benders.Add(new Bender("P'li", "Fire"));
    newPlayer.Benders.Add(new Bender("Lin", "Earth"));
    newPlayer.Benders.Add(new Bender("Kya", "Water"));
    newPlayer.ImageURL = "/images/cougarsharks.png";
    players.Add(newPlayer);

    var json = JsonSerializer.Serialize(players);
    var writer = new StreamWriter("../test.json", false);
    writer.Write(json);
    writer.Close();
}


