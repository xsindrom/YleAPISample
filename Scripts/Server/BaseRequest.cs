using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Server
{
    [Serializable]
    public class BaseRequest
    {
        protected string path;

        public string Path { get { return path; } }
    }
}