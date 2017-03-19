using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CPSC_481_PROJECT
{
    public class Profile
    {
        //sign-up instance variables
        public String Email { get; set; }
        private Dictionary<String, String> usernamePassword;
        public String BattleTag { get; set; }

        //profile settings variables (with get/set methods)   
        public String Role { get; set; }
        public String Hero { get; set; }
        public String GameMode { get; set; }
        public String Status { get; set; }

        //roles, heroes, game mode lists
        public static string[] RolesList = new string[] { "Offense", "Defense", "Tank", "Healer" };
        public static string[] HeroesList = new string[] {"Ana","Bastion","D.Va","Genji","Hanzo","Junkrat","Lucio","McCree","Mei","Mercy",
            "Pharah","Reaper","Reinhardt","Roadhog","Soldier: 76","Sombra", "Symmetra","Torbjorn","Tracer",
            "Widowmaker","Winston","Zarya","Zenyatta"};
        public static string[] GameModesList = new string[] { "Quickplay", "Ranked" };


        /// <summary>
        /// Profile constructor
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="battletag"></param>
        public Profile(String email, String username, String password, String battletag)
        {
            Email = email;

            usernamePassword = new Dictionary<String, String>(1);
            usernamePassword.Add(username, password);

            BattleTag = battletag;
            Status = "";


        }

        public Dictionary<String, String> getUsernamePassword()
        {
            return usernamePassword;
        }




    }
}
