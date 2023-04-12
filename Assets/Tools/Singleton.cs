using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: Singleton<T>
{

    private static T instance;//µ¥Àý
    public static T Instance
    {
        get
        {
           return instance;
        }
    }

    protected virtual void Awake()
    {
        Debug.Log(instance + "++++++++");
        if (instance != null)
        {
            Debug.Log("EXIST"+instance);
            Destroy(gameObject);
        }
        else
        {
            instance = (T)this;
            Debug.Log("Load" + instance);
            
        }
            
    }

}
