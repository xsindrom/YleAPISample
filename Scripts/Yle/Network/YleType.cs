using System;
using System.Collections;
using System.Collections.Generic;
namespace Yle.Network
{
    public class YleType
    {
        public const string TYPE_PROGRAM            = "program";
        public const string TYPE_CLIP               = "clip";
        public const string TYPE_TV_CONTENT         = "tvcontent";
        public const string TYPE_TV_PROGRAM         = "tvprogram";
        public const string TYPE_TV_CLIP            = "tvclip";
        public const string TYPE_RADIO_CONTENT      = "radiocontent";
        public const string TYPE_RADIO_PROGRAM      = "radioprogram";
        public const string TYPE_RADIO_CLIP         = "radioclip";

        private static readonly string[] types = new string[] {
            TYPE_PROGRAM,
            TYPE_CLIP,
            TYPE_TV_CONTENT,
            TYPE_TV_PROGRAM,
            TYPE_TV_CLIP,
            TYPE_RADIO_CONTENT,
            TYPE_RADIO_PROGRAM,
            TYPE_RADIO_CLIP
        };

        public static bool IsValid(string type)
        {
            return Array.Exists(types, x => x == type);
        }
    }
}