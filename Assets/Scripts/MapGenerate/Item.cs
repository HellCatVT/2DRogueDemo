using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update


    void Awake()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.y / 100);//…Ë÷√z÷·’⁄µ≤πÿœµ
    }

}
