using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        public void LoadDevelopers()
        {
           
            Developer d1 = new Developer("Amy", "A123", "999", DateTime.Parse("2020-11-01"));
            Developer d2 = new Developer("Bob", "B123", "990", DateTime.Parse("2021-11-01"));
            Developer d3 = new Developer("Carol", "C123", "989", DateTime.Parse("2022-11-01"));
            Developer d4 = new Developer("Dave", "D123", "994", DateTime.Parse("2023-11-01"));
            Developer d5 = new Developer("Emily", "E123", "779", DateTime.Parse("2020-11-01"));

            _developerDirectory.Add(d1);
            _developerDirectory.Add(d2);
            _developerDirectory.Add(d3);
            _developerDirectory.Add(d4);
            _developerDirectory.Add(d5);

        }

        public void AddDeveloperToList(Developer devID)
        {
            _developerDirectory.Add(devID);
        }
        //Developer Create
        public Developer CreateNewDeveloper(string devname, string devid, string licenseid, DateTime licenseexp)
        {

            //Developer newdeveloper = new Developer();
            //newdeveloper.DevID = devid;
            //newdeveloper.DevName = devname;
            //newdeveloper.LicenseID = licenseid;
            //newdeveloper.LicenseExp = licenseexp;

            Developer anothernewdeveloper = new Developer(devname, devid, licenseid, licenseexp);


            return anothernewdeveloper;

        }
        //Developer Read (All Developers)
        public string GetAllDevelopers()
        {
            string returnString = "";
            foreach (Developer thisDeveloper in _developerDirectory)
            {
                returnString += thisDeveloper.DevID + " " +
                                thisDeveloper.DevName + " " +
                                thisDeveloper.teamName + " " +
                                thisDeveloper.LicenseID + " " +
                                thisDeveloper.LicenseExp.ToString() + " ";
                returnString += "\n";
            }
            return returnString;
        }

        public List<Developer> GetExpiredLicenseDevelopers()
        {
            List<Developer> developersWithLicenseProblems = new List<Developer>();
            developersWithLicenseProblems = _developerDirectory.FindAll(x => { return x.LicenseID == null; });
            developersWithLicenseProblems.AddRange(
                _developerDirectory.FindAll(x => { return x.LicenseExp < DateTime.Today; })
            );
            return developersWithLicenseProblems;



        }

        //Developer Update
        public void UpdateDeveloperTeams(string newTeamName, string devID)
        {
            int recordnumber = 0;
            recordnumber = _developerDirectory.FindIndex(x => { return x.DevID == devID; });
            if (recordnumber != -1)

            {
                _developerDirectory[recordnumber].teamName = newTeamName;
            }
        }
        public void UpdateDeveloperTeams(string newTeamName, List<string> devIDList)
        {
            foreach(string devID in devIDList)
            {
                UpdateDeveloperTeams(newTeamName, devID);
            }
        }
        
          
        //Developer Delete
        public bool RemoveDeveloperFromDirectory(string devID)
        {
            int recordnumber = 0;
            recordnumber = _developerDirectory.FindIndex(x => { return x.DevID == devID; });
            if (recordnumber != -1)

            {
                _developerDirectory.RemoveAt(recordnumber);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperByID(string devID)
        {
            Developer foundDeveloper = _developerDirectory.Find(x => { return x.DevID == devID; });

            return foundDeveloper;

        }

    }

}

