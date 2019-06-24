using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainController : MonoSingleton<UIMainController>
{
    [SerializeField]
    private RectTransform windowsRoot;
    [SerializeField]
    private List<UIBaseWindow> windows = new List<UIBaseWindow>();
    private Dictionary<string, UIBaseWindow> windowsDict = new Dictionary<string, UIBaseWindow>();

    public static event Action OnWindowsReady;
    public static event Action<UIBaseWindow> OnWindowAdded;
    public static event Action<string> OnWindowRemoved;

    public override void Init()
    {
        for(int i = 0; i < windows.Count; i++)
        {
            var window = windows[i];
            if (!windowsDict.ContainsKey(window.Id))
            {
                var clone = Instantiate(window, windowsRoot);
                windowsDict.Add(clone.Id, clone);
            }
        }
        OnWindowsReady?.Invoke();
    }

    public void AddWindow(UIBaseWindow window)
    {
        if (!window)
            return;

        if (!windowsDict.ContainsKey(window.Id))
        {
            windowsDict.Add(window.Id, window);
            OnWindowAdded?.Invoke(window);
        }
    }

    public void RemoveWindow(string id)
    {
        if (windowsDict.ContainsKey(id))
        {
            var window = windowsDict[id];
            Destroy(window.gameObject);
            windowsDict.Remove(id);
            OnWindowRemoved?.Invoke(id);
        }
    }

    public bool HasWindow(string id)
    {
        return windowsDict.ContainsKey(id);
    }

    public UIBaseWindow GetWindow(string id)
    {
        return windowsDict.ContainsKey(id) ? windowsDict[id]: null;
    }

    public T GetWindow<T>(string id) where T: UIBaseWindow
    {
        return windowsDict.ContainsKey(id) ? windowsDict[id] as T : null;
    }
}
