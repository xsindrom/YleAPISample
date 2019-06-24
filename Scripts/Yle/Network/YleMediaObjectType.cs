using System;
using System.Collections;
using System.Collections.Generic;
namespace Yle.Network
{
    public class YleMediaObjectType
    {
        public const string TYPE_AUDIO = "audio";
        public const string TYPE_VIDEO = "video";

        private static readonly string[] types = new string[]
        {
            TYPE_AUDIO,
            TYPE_VIDEO
        };

        public static bool IsValid(string type)
        {
            return Array.Exists(types, x => x == type);
        }
    }
}