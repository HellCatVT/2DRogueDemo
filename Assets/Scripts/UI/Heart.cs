using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> AnimList;

    private int Index = 0;

    private float TimeCount = 2;

    public bool IsToDestroy;

    private void Update()
    {
        if (IsToDestroy)
        {
            TimeCount += Time.deltaTime;
            if (TimeCount >= 0.2)
            {
                if (Index == AnimList.Count)
                    Destroy(gameObject);
                if(Index < AnimList.Count)
                {
                    GetComponent<Image>().sprite = AnimList[Index];
                    Index++;
                    TimeCount = 0;
                }
                
            }
        }
        
    }

}
