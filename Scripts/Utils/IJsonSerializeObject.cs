using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public interface IJsonSerializeObject<T>
    {
        string ToJson();
        T FromJson(string json);
    }
}