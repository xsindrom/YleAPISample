using System;
using System.Collections;
using System.Collections.Generic;
namespace Yle.Network
{
    public class YleAvailabilityType
    {
        public const string TYPE_ONDEMAND           = "ondemand";
        public const string TYPE_FUTURE_DEMAND      = "future-ondemand";
        public const string TYPE_FUTURE_SCHEDULED   = "future-scheduled";
        public const string TYPE_IN_FUTURE          = "in-future";

        private static readonly string[] types = new string[]
        {
            TYPE_ONDEMAND,
            TYPE_FUTURE_DEMAND,
            TYPE_FUTURE_SCHEDULED,
            TYPE_IN_FUTURE
        };

        public static bool IsValid(string type)
        {
            return Array.Exists(types, x => x == type);
        }
    }
}