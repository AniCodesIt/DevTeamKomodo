using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    class UserInterface
    {
        //Referencing the class, created an instance (repoholder)
        //telling system to assign the parameters (meaning properties and methods)
        //found in DevTeamRepo to repoholder
        public static DevTeamRepo repoholder = new DevTeamRepo();
        public static  DeveloperRepo _developerRepo = new DeveloperRepo();
        private static string developersWithLicenseProblems;

        static void Main(string[] args)
        {
            _developerRepo.LoadDevelopers();
            repoholder.LoadTeams();

            Console.WriteLine("Press 1 to read the developer directory");
            Console.WriteLine("Press 2 to create a team");
            Console.WriteLine("Press 3 to add a developer to a team");         
            Console.WriteLine("Press 4 to add a list of developers to a team");            
            Console.WriteLine("Press 5 to delete a developer from a team");           
            Console.WriteLine("Press 6 to pull list of licenses with expiration info");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":              
                    //DeveloperRepo _developerrepo = new DeveloperRepo();
                 string thislist = _developerRepo.GetAllDevelopers();
                    Console.Write(thislist);
                    Console.WriteLine();
                        break;

                case "2":
                    Console.WriteLine("Enter the team name you would like to create: ");
                    userInput = Console.ReadLine();


                    //Referencing the class, executing a method found within (createnewdevteam)
                    string mydevteam;
                    mydevteam = repoholder.CreateNewDevTeam(userInput);
                    // DevTeam thisTeam = repoholder.CreateNewDevTeam(userInput);
                    Console.WriteLine();
                    Console.WriteLine("Here's your new list of teams\n" + mydevteam);
                    break;

                case "3":
                    Console.Write("Which developer ID would you like to add? ");
                    string developer = Console.ReadLine();
                    Console.WriteLine("Which team would you like to add them to? ");
                    string team = Console.ReadLine();
                    //DeveloperRepo repoholder2 = new DeveloperRepo();
                    _developerRepo.UpdateDeveloperTeams(team, developer);
                    Console.WriteLine("Developer " + developer + " has been added to team " + team);
                    break;

                case "4":
                    string moreDevelopersToAdd = null;
                    List<string> addingDevelopers = null;
                    string updatingThisTeam = null;
                    Console.WriteLine("Which team do you want to add developers to? ");
                    updatingThisTeam = Console.ReadLine();                   
                    while (moreDevelopersToAdd != "x")
                    {
                        Console.WriteLine("Please add your next developer or enter 'x' to finish ");
                        moreDevelopersToAdd = Console.ReadLine();
                        if (moreDevelopersToAdd != "x")
                        {
                            addingDevelopers.Add(moreDevelopersToAdd);
                        }
                    }
                    _developerRepo.UpdateDeveloperTeams(updatingThisTeam, addingDevelopers);
                    break;

                case "5":
                    string removingThisDeveloper = null;
                    Console.WriteLine("Enter the developer ID that you would like to remove from a team: ");
                    removingThisDeveloper = Console.ReadLine();
                    _developerRepo.UpdateDeveloperTeams(null, removingThisDeveloper);
                    //TODO: It would be nice to specify their team here - need to write in the teamname 
                    Console.WriteLine("Developer " + removingThisDeveloper + " was removed from their team");
                    break;

                case "6":
                    _developerRepo.GetExpiredLicenseDevelopers();
                    //TODO: need to tie this back to the DeveloperRepo sourcefile
                    //Console.WriteLine("Here is your list " + developersWithLicenseProblems)
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }

    }

}
