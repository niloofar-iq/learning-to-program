﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Characters
{

    //    public int intelligence;
    //    public int wisdom;
    //    public int dexterity;
    //    public int strength;
    //    public int charisma;
    //    public int constitution;

    public class Dexterity : AbilityPoints
    {

        public Dexterity(int value)
        {
            AbilityName = "Dexterity";
            Max = 20;
            Min = 1;
            Value = value;
        }

    }


}
