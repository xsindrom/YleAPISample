using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T:MonoBehaviour
{
    private static T instance = null;
    private static object lockObject = new object();
    private static bool isApplicationQuiting = false;

    public static T Instance
    {
        get
        {
            if (isApplicationQuiting)
                return null;

            if (!instance)
            {
                var instances = FindObjectsOfType<T>();
                if(instances.Length > 0)
                {
                    instance = instances[0];
                    for(int i = 1; i < instances.Length; i++)
                    {
                        Destroy(instances[i].gameObject);
                    }
                }

                lock (lockObject)
                {
                    if (!instance)
                    {
                        var gameObject = new GameObject();
                        gameObject.AddComponent<T>();
                        gameObject.name = typeof(T).Name;
                    }
                }
            }
            return instance;
        }
    }

    [SerializeField]
    protected bool dontDestroyOnLoad = true;

    public static bool HasInstance
    {
        get { return instance; }
    }

    public static void CreateInstance(bool dontDestroyOnLoad = false)
    {
        if (!instance)
        {
            var gameObject = new GameObject();
            gameObject.AddComponent<T>();
            gameObject.name = typeof(T).Name;
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }

    private void Awake()
    {
        if(Instance == this)
        {
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
            isApplicationQuiting = false;
            Init();
        }
    }

    public virtual void Init()
    {

    }

    private void OnApplicationQuit()
    {
        isApplicationQuiting = true;
    }

    private void OnDestroy()
    {
        isApplicationQuiting = true;
    }
}
