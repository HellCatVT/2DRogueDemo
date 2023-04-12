using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flaming : MonoBehaviour
{
    public int ATK = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("IN");
        collision.GetComponent<PlayerController>().GetDamaged(ATK);
    }
}
