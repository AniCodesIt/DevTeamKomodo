using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        public string teamName { get; set; }
        public DevTeam()
        {

        }
        //Optional - Alternatively the user can instantiate a DevTeam object with assigning values
        public DevTeam(string a) //function prototype
        {
            teamName = a;
        }
    }
}
