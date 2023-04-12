using Game.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMapChange : MonoBehaviour
{

    public Sprite ExploredSprite;

    public Sprite ExploringSprite;
                

    public void ChangeSprite(bool isExploring)
    {
        if (isExploring)
        {
            GetComponent<Image>().sprite = ExploringSprite;
        }
        else
            GetComponent<Image>().sprite = ExploredSprite;
    }

    public void BeListener(int index)
    {

        MapGenerator.Instance.Rooms[index].PlayerExplore += ChangeSprite;
    }
}
