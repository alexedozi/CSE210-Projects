
Team myTeam = new Team("Development Team");
myTeam.AddMember("Eric");
myTeam.AddMember("Francisco");
myTeam.AddMember("Emmanuel");
myTeam.AddMember("Alexander");
myTeam.AddMember("Martin");

myTeam.DisplayTeamInfo(); // Output: 
// Team Name: Development Team
// Team Members:
// - Eric
// - Francisco
// - Emmanuel
// - Alexander
// - Martin

myTeam.RemoveMember("Eric");

myTeam.DisplayTeamInfo(); // Output: 
// Team Name: Development Team
// Team Members:
// - Francisco
// - Emmanuel
// - Alexander
// - Martin

/* +----------------+
|     Team       |
+----------------+
| - name: string  |
| - members: List<string> |
+----------------+
| + Team(name: string) |
| + AddMember(member: string): void |
| + RemoveMember(member: string): void |
| + DisplayTeamInfo(): void |
+----------------+
*/


/*In this diagram, the Team class has two private fields: name (a string) and members (a list of strings). It also has a constructor that takes a name parameter and initializes the members list.

The Team class has three public methods: AddMember, RemoveMember, and DisplayTeamInfo. AddMember adds a member to the team's list of members, RemoveMember removes a member from the list, and DisplayTeamInfo displays the team's name and list of members.

Note that the Team class is not shown as having any properties, although you could add read-only properties for name and members if desired.*/
