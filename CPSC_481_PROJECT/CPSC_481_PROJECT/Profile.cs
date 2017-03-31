﻿using System;
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

        public String ProfileIconSource { get; set; }

        //roles, heroes, game mode lists
        public static string[] RolesList = new string[] { "Offense", "Defense", "Tank", "Support" };
        public static string[] HeroesList = new string[] {"Ana","Bastion","D.Va","Genji","Hanzo","Junkrat","Lucio","McCree","Mei","Mercy",
            "Orisa","Pharah","Reaper","Reinhardt","Roadhog","Soldier: 76","Sombra", "Symmetra","Torbjorn","Tracer",
            "Widowmaker","Winston","Zarya","Zenyatta"};
        public static string[] GameModesList = new string[] { "Quickplay", "Ranked" };

        private List<Profile> friendsList;

        public bool hasTeam { get; set; }
        //public String teamName;
        //private List<Profile> teamList;
        private Team userTeam;


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

            //default profile icon
            ProfileIconSource = "/Images/PRO_GENJI.png";

            friendsList = new List<Profile>();
            hasTeam = false;
            //teamList = new List<Profile>();



        }

        /// <summary>
        /// get method for username-password dictionary
        /// </summary>
        /// <returns></returns>
        public Dictionary<String, String> getUsernamePassword()
        {
            return usernamePassword;
        }

        /// <summary>
        /// Add user profile to friends list
        /// </summary>
        /// <param name="newFriendProfile"></param>
        public void addFriend(Profile newFriendProfile)
        {
            friendsList.Add(newFriendProfile);
        }

       

        /// <summary>
        /// debugging method to set default friends list
        /// </summary>
        /// <param name="defaultFriendsList"></param>
        public void setDefaultFriends(List<Profile> defaultFriendsList)
        {
            friendsList = defaultFriendsList;
        }

        /// <summary>
        /// debugging method to set default team list
        /// </summary>
        /// <param name="defaultTeamList"></param>
        //public void setDefaultTeam(String defaultTeamName,List<Profile> defaultTeamList)
        //{
            //teamName = defaultTeamName;
            //teamList = defaultTeamList;
        //}

        public void setDefaultTeam(Team defaultTeam)
        {
            userTeam = defaultTeam;
        }

        /// <summary>
        /// get friends list
        /// </summary>
        /// <returns></returns>
        public List<Profile> getFriendsList()
        {
            return friendsList;
        }

        /// <summary>
        /// Add new member profile to team list
        /// </summary>
        /// <param name="newMember"></param>
        //public void addTeamMember(Profile newMember)
        //{
        //    if (teamList.Count() <= 5)
        //        teamList.Add(newMember);
        //}

        //public void removeTeamMember(Profile memberToRemove)
        //{
        //    foreach(Profile member in teamList)
        //    {
        //        if (member.Equals(memberToRemove))
        //        {
        //            teamList.Remove(member);
        //            break;
        //        }
        //    }
        //}



        /// <summary>
        /// instantiate new team for user (with self as first member)
        /// Users should only have one team so set boolean
        /// </summary>
        /// <param name="name"></param>
        public void makeNewTeam(String name, String mode)
        {
            //teamName = name;
            //teamList.Add(this);
            //hasTeam = true;

            userTeam = new Team(name, this, mode);
            hasTeam = true;

        }

        /// <summary>
        /// get team list
        /// </summary>
        /// <returns></returns>
        public Team getTeamList()
        {
            //return teamList;
            return userTeam;
        }

        public Team getTeam()
        {
            return userTeam;
        }




    }
}
