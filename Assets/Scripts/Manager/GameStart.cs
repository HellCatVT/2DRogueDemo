using Game.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.Instance.Player.GetComponent<PlayerController>().enabled = false;
            GameManager.Instance.Player.transform.position = Vector3.zero;
            SceneManager.LoadScene(1, LoadSceneMode.Single);
            PlayerController.Instance.ResetPlayerInfo();
        }
    }
}
