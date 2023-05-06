public class Team
{
    // Fields (private by convention)
    private string name;
    private List<string> members;
    
    // Constructor
    public Team(string name)
    {
        this.name = name;
        members = new List<string>();
    }
    
    // Properties
    public string Name 
    { 
        get { return name; } 
        set { name = value; } 
    }
    
    public List<string> Members 
    { 
        get { return members; } 
    }
    
    // Methods
    public void AddMember(string member)
    {
        members.Add(member);
    }
    
    public void RemoveMember(string member)
    {
        members.Remove(member);
    }
    
    public void DisplayTeamInfo()
    {
        Console.WriteLine("Team Name: {0}", name);
        Console.WriteLine("Team Members: ");
        foreach (string member in members)
        {
            Console.WriteLine("- {0}", member);
        }
    }
}
