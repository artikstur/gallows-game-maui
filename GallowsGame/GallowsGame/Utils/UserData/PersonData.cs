﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame.Utils.UserData
{
    public class PersonData
    {
        public string Name { get; set; } = "";
        public int WinRoundCount { get; set; }
        public int Balance { get; set; } = 3;
        public PersonData(string name)
        {
            Name = name;
            WinRoundCount = 0;
        }
    }
}
