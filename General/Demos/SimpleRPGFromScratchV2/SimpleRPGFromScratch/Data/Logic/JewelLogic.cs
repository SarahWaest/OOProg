﻿using System.Collections.Generic;
using System.Linq;
using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class Jewel : IDomainClass
    {
        public int GetId()
        {
            return Id;
        }

        public double BaseDamage
        {
            get
            {
                return CalcModelBaseDamage() * 
                       CalcCutQualityFactor() * 
                       CalcWeaponJewelMatchFactor();
            }
        }


        private int CalcModelBaseDamage()
        {
            return JewelModel?.BaseDamage ?? 0;
        }

        private double CalcCutQualityFactor()
        {
            return CutQuality?.Factor ?? 1.0;
        }

        private double CalcWeaponJewelMatchFactor()
        {
            // If Jewel is not on a Weapon, return 1.0 (no modification)
            if (Weapon == null) return 1.0;

            // If a matching factor for the Weapon onto which
            // the Jewel is socketed is present, return the factor.
            // Otherwise return 1.0 (no modification).
            List<WeaponJewelMatch> wjMatches = JewelModel.WeaponJewelMatches.Where(obj => obj.WeaponModelId == Weapon.WeaponModelId).ToList();
            return wjMatches.Count == 0 ? 1.0 : wjMatches[0].Factor;
        }
    }
}