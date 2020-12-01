using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        //Describing properties of the Developer class
        public string DevName { get; set;}
        public string DevID { get; set;}
        public string LicenseID { get; set;}
        public DateTime  LicenseExp {get; set;}
        public string teamName { get; set;}
        //Required - Create a blank developer object
        public Developer()
        {
        }
        //Optional - Alternatively the user can instantiate a Developer object with assigning values
        public Developer(string a, string b, string c, DateTime d)
        {
            DevName = a;
            DevID = b;
            LicenseID = c;
            LicenseExp = d;
            teamName = "";
        }
    }
}
