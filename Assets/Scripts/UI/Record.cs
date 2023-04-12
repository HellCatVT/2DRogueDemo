using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour
{
    public RectTransform RecordPanel;

    public RectTransform Pos;
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            RecordPanel.position = Pos.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            RecordPanel.position = new(10000, 10000);
        }
    }
}
