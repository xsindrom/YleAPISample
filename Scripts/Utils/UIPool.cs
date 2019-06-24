using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class UIPool<T>: MonoBehaviour where T: MonoBehaviour, IUIPoolObject
    {
        [SerializeField]
        private T template;
        [SerializeField]
        private RectTransform root;
        private List<T> freeObjects = new List<T>();
        private List<T> busyObjects = new List<T>();

        public int BusyCount { get { return busyObjects.Count; } }
        public int FreeCount { get { return freeObjects.Count; } }

        public T GetOrInstantiateObject()
        {
            if (freeObjects.Count > 0)
            {
                var freeObject = freeObjects[0];
                busyObjects.Add(freeObject);
                freeObjects.RemoveAt(0);
                freeObject.ResetObject();
                freeObject.gameObject.SetActive(true);
                return freeObject;
            }
            else
            {
                var busyObject = Instantiate(template, root);
                busyObjects.Add(busyObject);
                busyObject.gameObject.SetActive(true);
                return busyObject;
            }
        }

        public void Clear()
        {
            for(int i =0; i < busyObjects.Count; i++)
            {
                var busyObject = busyObjects[i];
                busyObject.ResetObject();
                freeObjects.Add(busyObject);
                busyObject.gameObject.SetActive(false);
            }
            busyObjects.Clear();
        }
    }
}