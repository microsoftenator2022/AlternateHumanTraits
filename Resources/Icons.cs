using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints.JsonSystem.Converters;
using Kingmaker.ResourceLinks;

using UnityEngine;

namespace AlternateHumanTraits.Resources
{
    public static class Icons
    {
        public static class Guids
        {
            public static readonly (string, long) WeaponSpecialization = ("2a1d85e4d5185644da0a1788fc2f08d5", 21300000);
            public static readonly (string, long) WeaponProficiency = ("eba3d40eaa80da840b9e96b48db90613", 21300000);
            public static readonly (string, long) HeritageSelection = ("7c8efbd1129b371428be7754181a4104", 21300000);
            public static readonly (string, long) ElvenMagic = ("15d11c952fdc96b45849f312f3931192", 21300000);
            public static readonly (string, long) GnomeHookedHammerHead = ("ac128c37256e37d408b7149b3edeaa8f", 21300000);
            public static readonly (string, long) SlingStaff = ("2fd0a6cb0f7152941a036ea43f0361cb", 21300000);
            public static readonly (string, long) SkillFocusSelection = ("42cb25b90b7c7d34e956c7822a9349cb", 21300000);
            public static readonly (string, long) IntimidatingProwess = ("0050b11e895fb014eb841fb0bbcbf574", 21300000);
            public static readonly (string, long) Bravery = ("af5df55819255b54fb3491bbd67a569e", 21300000);
            public static readonly (string, long) Stealthy = ("3482eb9c0d448524ab950213b3866301", 21300000);
        }

        private static readonly IDictionary<(string, long), Sprite> sprites = new Dictionary<(string, long), Sprite>();

        public static Sprite GetSprite((string assetId, long fileId) id)
        {
            if (!sprites.ContainsKey(id))
            { 
                sprites[id] = (Sprite)UnityObjectConverter.AssetList.Get(id.assetId, id.fileId);
            }

            return sprites[id];
        }
        
        public static Sprite? WeaponSpecialization => GetSprite(Guids.WeaponSpecialization);
        public static Sprite? WeaponProficiency => GetSprite(Guids.WeaponProficiency);
        public static Sprite? HeritageSelection => GetSprite(Guids.HeritageSelection);
        public static Sprite? ElvenMagic => GetSprite(Guids.ElvenMagic);
        public static Sprite? GnomeHookedHammerHead => GetSprite(Guids.GnomeHookedHammerHead);
        public static Sprite? SlingStaff => GetSprite(Guids.SlingStaff);
        public static Sprite? SkillFocusSelection => GetSprite(Guids.SkillFocusSelection);
        public static Sprite? IntimidatingProwess => GetSprite(Guids.IntimidatingProwess);
        public static Sprite? Bravery => GetSprite(Guids.Bravery);
        public static Sprite? Stealthy => GetSprite(Guids.Stealthy);
    }
}
