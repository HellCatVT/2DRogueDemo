using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkText : MonoBehaviour
{
    public Transform AttachedTF;
    private Vector3 ScreenPos;
    private void Update()
    {
        ScreenPos = Camera.main.WorldToScreenPoint(AttachedTF.position);
        transform.position = ScreenPos;
    }
}
