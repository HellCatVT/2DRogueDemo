using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerHP : MonoBehaviour
{

    private Stack<GameObject> HeartStack = new Stack<GameObject>();
    public GameObject Heart;

    // Start is called before the first frame update
    void Start()
    {
        HeartInit();
    }
    private void OnEnable()
    {
        PlayerController.Instance.GetHurt += GetHurt;
    }

    private void OnDisable()
    {
        PlayerController.Instance.GetHurt -= GetHurt;
    }


    private void HeartInit()
    {
        for (int i = 0; i < PlayerController.Instance.GetHP(); i++)
        {
            CreateHeart();
        }
    }

    private void GetHurt(int damage)
    {
        for(int i =0; i<damage; i++)
        {
            if(HeartStack.Count!=0)
                HeartStack.Pop().GetComponent<Heart>().IsToDestroy = true;
        }
        
    }

    private void CreateHeart() 
    {
        HeartStack.Push(Instantiate(Heart, transform));
    }

}
