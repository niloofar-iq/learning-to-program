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

    public class Wisdom:AbilityPoints
    {
        
        public override AbilityNames AbilityName => AbilityNames.Wisdom;
        public override int Max => 20;
        public override int Min => 5;

        public Wisdom(int value)
        {   
            Value = value;
        }

    }


}