using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                //tìm obj có tên là tên của class
                instance = (T)FindObjectOfType(typeof(T));
                //nếu không có
                if (instance == null)
                {
                    string name = typeof(T).Name;//tên class
                    Debug.LogFormat("Create singleton object: {0}", name);
                    //tạo game obj với tên là name
                    instance = new GameObject(name).AddComponent<T>();
                    //kiểm tra null
                    if (instance == null)
                    {
                        Debug.LogWarning("Can't find singleton object: " + typeof(T).Name);
                        Debug.LogError("Can't create singleton object: " + typeof(T).Name);
                        return null;
                    }
                }
            }

            return instance;
        }
    }
    //kiểm tra instance
    protected virtual void Awake()
    {
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if (instance == null)
        {
            instance = (T)this;
            return true;
        }

        if (Instance == this)
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