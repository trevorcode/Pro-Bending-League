#load "buildJson.csx"
#load "schedule.csx"
#load "teams.csx"
#load "buildPlayerPage.csx"

BuildJson();
BuildTeams();
BuildSchedule();
BuildPlayerPages();

Console.WriteLine("hello, you made it here");