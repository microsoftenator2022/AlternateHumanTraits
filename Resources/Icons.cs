using System;
using System.Collections.Generic;
using System.Linq;

using Kingmaker.Blueprints.JsonSystem.Converters;

using UnityEngine;

namespace AlternateHumanTraits.Resources
{
    public static class Icons
    {
        public static class Guids
        {
            public static readonly (string, long) WeaponSpecialization = ("2a1d85e4d5185644da0a1788fc2f08d5", 21300000);
            public static readonly (string, long) WeaponProficiency = ("eba3d40eaa80da840b9e96b48db90613", 21300000);
        }

        private static readonly IDictionary<(string, long), Sprite> sprites = new Dictionary<(string, long), Sprite>();

        public static Sprite GetSprite((string assetId, long fileId) id)
        {
            if (!sprites.ContainsKey(id))
            { 
                //sprites[guid] = new SpriteLink() { AssetId = guid }.Load();
                sprites[id] = (Sprite)UnityObjectConverter.AssetList.Get(id.assetId, id.fileId);
            }

            return sprites[id];
        }
        
        public static Sprite? WeaponSpecialization => GetSprite(Guids.WeaponSpecialization);
        public static Sprite? WeaponProficiency => GetSprite(Guids.WeaponProficiency);
    }
}
