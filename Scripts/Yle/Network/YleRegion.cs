using System;
using System.Collections;
using System.Collections.Generic;

namespace Yle.Network
{
    public class YleRegion
    {
        public const string REGION_WORLD    = "world";
        public const string REGION_FINNISH  = "fi";

        private static readonly string[] regions = new string[]
        {
            REGION_FINNISH,
            REGION_WORLD
        };

        public static bool IsValid(string region)
        {
            return Array.Exists(regions, x => x == region);
        }
    }
}