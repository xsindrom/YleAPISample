using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yle
{
    [Serializable]
    public class ProgramItem
    {
        [SerializeField]
        private string id;
        private Dictionary<string, string> titles;
        private Dictionary<string, string> descriptions;
        private string[] creators;
        [SerializeField]
        private string duration;
        [SerializeField]
        private string imageId;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public Dictionary<string, string> Titles
        {
            get { return titles; }
            set { titles = value; }
        }

        public Dictionary<string, string> Descriptions
        {
            get { return descriptions; }
            set { descriptions = value; }
        }

        public string[] Creators
        {
            get { return creators; }
            set { creators = value; }
        }

        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public string ImageId
        {
            get { return imageId; }
            set { imageId = value; }
        }
    }
}