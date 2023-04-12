using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.Instance.transform.position = Vector3.zero;
            SceneManager.LoadScene(1, LoadSceneMode.Single);

        }
            
    }
}
