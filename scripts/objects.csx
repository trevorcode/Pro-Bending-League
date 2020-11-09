public class Player
{
    public Player()
    {
        Benders = new List<Bender>();
    }
    
    public Player(string name, string teamName, int group)
    {
        Name = name;
        TeamName = teamName;
        Group = group;
        Benders = new List<Bender>();
    }


    public string Name { get; set; }
    public string TeamName { get; set; }
    public string ImageURL { get; set; }
    public int Group { get; set; }
    public List<Bender> Benders { get; set; }
}

public class Bender {
    public Bender()
    {

    }
    public Bender(string name, string element)
    {
        Name = name;
        Element = element;
    }
    public string Name{ get; set; }
    public string Element { get; set; }
}