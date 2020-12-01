using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly DeveloperRepo _developerRepo = new DeveloperRepo(); // this gives you access to the _developerDirectory so you can access existing Developers and add them to a team
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();

        public void LoadTeams()
        {
            DevTeam t1 = new DevTeam("blue");
            DevTeam t2 = new DevTeam("red");
            DevTeam t3 = new DevTeam("yellow");

            _devTeams.Add(t1);
            _devTeams.Add(t2);
            _devTeams.Add(t3);
        }
        //DevTeam Create
        public string CreateNewDevTeam(string teamName)
        {
            DevTeam anothernewdevteam = new DevTeam(teamName);
            _devTeams.Add(anothernewdevteam);
            string returnString = "";
            foreach (DevTeam thisTeam in _devTeams)
            {
                returnString += thisTeam.teamName;                              
                returnString += "\n";
            }
            return returnString;    

        }
        //DevTeam Read
        public List<DevTeam> GetAllDevTeams()
        {
            return _devTeams;
        }

        //DevTeam Update 
        public void UpdateDevTeams(string exisitngTeamName, string newTeamName)
        {
            int recordnumber = 0;      //x is a delegate or contatiner - it contains all the fields int he row   
            recordnumber = _devTeams.FindIndex(x => { return x.teamName == exisitngTeamName; });
            if (recordnumber != -1)
            {
                _devTeams[recordnumber].teamName = newTeamName;
            }
        }
        //DevTeam Delete
        public bool RemoveTeamFromList(string teamName)
        {
            int recordnumber = 0;
            recordnumber = _devTeams.FindIndex(x => { return x.teamName == teamName; });
            if (recordnumber != -1)

            {
                _devTeams.RemoveAt(recordnumber);
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetDevTeamByName(string teamName)
        {
            DevTeam foundTeam = _devTeams.Find(x => { return x.teamName == teamName; });
            return foundTeam;
        }
    }
}
