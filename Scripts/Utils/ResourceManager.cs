using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceManager
{
    private static Dictionary<string, Object> cache = new Dictionary<string, Object>();

    public static T GetResource<T>(string path) where T : Object
    {
        if (cache.ContainsKey(path))
        {
            return cache[path] as T;
        }
        else
        {
            var resource = Resources.Load<T>(path);
            if (resource)
            {
                cache.Add(path, resource);
            }
            return resource;
        }
    }
}
