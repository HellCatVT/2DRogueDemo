using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VerticalDoor : MonoBehaviour
{
    public void SetCollider(bool isActive)
    {
        GetComponent<TilemapCollider2D>().enabled = isActive;
    }
}
