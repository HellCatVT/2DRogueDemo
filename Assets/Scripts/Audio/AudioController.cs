using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public float MaxVol;

    private void Awake()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas.GetComponent<UIManager>() != null)
        {
            canvas.GetComponent<UIManager>().SoundList.Add(this.GetComponent<AudioSource>());
        }
    }

    private void OnDisable()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas.GetComponent<UIManager>() != null)
        {
            canvas.GetComponent<UIManager>().SoundList.Remove(this.GetComponent<AudioSource>());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = MaxVol;
    }

}
