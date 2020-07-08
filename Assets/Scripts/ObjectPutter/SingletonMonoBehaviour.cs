using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{

    //tạo mới một game obj để chứa các obj được spawn
    protected static T Instance;

    public static T getInstance
    {
        get
        {
            if (Instance == null)
            {
                //tìm obj có tên là tên của class
                Instance = (T)FindObjectOfType(typeof(T));
                //nếu không có
                if (Instance == null)
                {
                    string name = typeof(T).Name;//tên class
                    Debug.LogFormat("Create singleton object: {0}", name);
                    //tạo game obj với tên là name
                    Instance = new GameObject(name).AddComponent<T>();
                    //kiểm tra null
                    if (Instance == null)
                    {
                        Debug.LogWarning("Can't find singleton object: " + typeof(T).Name);
                        Debug.LogError("Can't create singleton object: " + typeof(T).Name);
                        return null;
                    }
                }
            }

            return Instance;
        }
    }
    //kiểm tra instance
    protected virtual void Awake()
    {
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if (Instance == null)
        {
            Instance = (T)this;
            return true;
        }

        if (getInstance == this)
        {
            return true;
        }

        Destroy(this);
        return false;
    }

    protected void DontDestroyOnLoad()
    {
        DontDestroyOnLoad(gameObject);
    }
}