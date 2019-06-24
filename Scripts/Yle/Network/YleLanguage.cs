using System;
using System.Collections;
using System.Collections.Generic;
namespace Yle.Network
{
    public class YleLanguage
    {
        public const string LANGUAGE_FINNISH = "fi";
        public const string LANGUAGE_SWEDISH = "sv";

        private static readonly string[] languages = new string[]
        {
            LANGUAGE_FINNISH,
            LANGUAGE_SWEDISH
        };

        public static bool IsValid(string language)
        {
            return Array.Exists(languages, x => x == language);
        }
    }
}