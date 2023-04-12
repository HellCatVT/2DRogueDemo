using Game.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : Room
{

    public List<GameObject> ActiveItem;

    public BossFSMBase fsm;

    public AudioClip BossBattleAudio;

    public AudioClip BattleAudio;

    public Boss Boss;

    void Awake()
    {
        LocationList = MapGenerator.Instance.RoomLocation;
        EnemyGenerator = GetComponent<EnemyGenerate>();

        HDoors = new List<Door>();

        VDoors = new List<VerticalDoor>();
    }

    private void Update()
    {
        if (Boss.HP <= 0)
        {
            Camera.main.GetComponent<AudioSource>().clip = BattleAudio;
            Camera.main.GetComponent<AudioSource>().Play();
        }
    }

    private void SetActivate(bool isActive)
    {
        for(int i = 0; i < ActiveItem.Count; i++)
        {
            ActiveItem[i].GetComponent<SpriteRenderer>().enabled = !isActive;
            ActiveItem[i].transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = isActive;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            if (!IsActivated && !IsPassed)
            {
                PlayerEnterRoom();
                SetActivate(true);

                Camera.main.GetComponent<AudioSource>().clip = BossBattleAudio;
                Camera.main.GetComponent<AudioSource>().Play();
                fsm.IsPlayerApproch = true;
            }
            PlayerExplore?.Invoke(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerExplore?.Invoke(false);
        }
    }


}
