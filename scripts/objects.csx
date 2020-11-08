public class Player
{
    public Player()
    {
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
