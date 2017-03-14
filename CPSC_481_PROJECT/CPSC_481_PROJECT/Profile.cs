﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_481_PROJECT
{
    class Profile
    {
        //sign-up instance variables
        private String email;
        private String username;
        private String password;
        private String battletag;

        //profile settings variables
        private String role;
        private String hero;
        private String gameMode;
        

        /// <summary>
        /// Profile constructor
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="battletag"></param>
        public Profile(String email, String username, String password, String battletag)
        {
            this.email = email;
            this.username = username;
            this.password = password;
            this.battletag = battletag;
        }
    }
}
