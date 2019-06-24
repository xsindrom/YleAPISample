using System;
using System.Collections;
using System.Collections.Generic;

namespace Yle
{
    public class YleImageFormat
    {
        public const string FORMAT_JPG = "jpg";
        public const string FORMAT_PNG = "png";
        public const string FORMAT_GIF = "gif";

        private static readonly string[] formats = new string[]
        {
            FORMAT_JPG,
            FORMAT_PNG,
            FORMAT_GIF
        };

        public static bool IsValid(string format)
        {
            return Array.Exists(formats, x => x == format);
        }
    }
}