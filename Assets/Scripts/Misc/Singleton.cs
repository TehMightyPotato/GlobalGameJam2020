using UnityEngine;
using System.Collections;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    private static bool applicationIsQuitting = false;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null && !applicationIsQuitting)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        applicationIsQuitting = true;
    }
}
