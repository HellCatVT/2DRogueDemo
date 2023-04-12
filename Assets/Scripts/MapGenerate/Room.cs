using Game.Controller;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Rendering.HybridV2;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine;
using System.Reflection;


[RequireComponent(typeof(BoxCollider2D))]
public class Room : MonoBehaviour
{

    public List<Vector2> LocationList;

    public int RoomIndex=0;

    [Header("房间的宽")]
    public static int RoomWidth = 16;
    [Header("房间的高")]
    public static int RoomHeight = 10;

    public GameObject UpWall;
    public GameObject DownWall;
    public GameObject RightWall;
    public GameObject LeftWall;

    public GameObject UpCorrider;
    public GameObject DownCorrider;
    public GameObject RightCorrider;
    public GameObject LeftCorrider;

    protected List<Door> HDoors;

    protected List<VerticalDoor> VDoors;

    protected EnemyGenerate EnemyGenerator;

    public System.Action<bool> PlayerExplore;

    public bool IsPassed;

    public bool IsActivated = false;

    void Awake()
    {
        LocationList = MapGenerator.Instance.RoomLocation;
        EnemyGenerator = GetComponent<EnemyGenerate>();

        HDoors = new List<Door>();

        VDoors = new List<VerticalDoor>();
    }


    void Update()
    {
       
    }

    /// <summary>
    /// 生成墙壁
    /// </summary>
    public void WallAndCorriderGenerate()
    {
        int[] direction = { 0, 0, 0, 0 };//up,down,left,right,为1则有通道
        float x = 0, y = 0;
        Vector2 location = LocationList[RoomIndex];
        for (int i = 0; i < LocationList.Count; i++)//判断墙的生成位置
        {
            if (i != RoomIndex)
            {
                if (Mathf.Abs(Vector2.Distance(LocationList[i], location)) <= 1.01)
                {
                    x = LocationList[i].x - location.x;
                    y = LocationList[i].y - location.y;
                    if (x > 0.1)
                        direction[3] = 1;
                    else if (x < -0.1)
                        direction[2] = 1;
                    else if (y > 0.1)
                        direction[0] = 1;
                    else if (y < -0.1)
                        direction[1] = 1;
                }
                x = 0; y = 0;
            } 
        }
        if (direction[0] == 0)//up
            WallInstantiate(UpWall);
        else
            HorizDoorInstantiate(UpCorrider);
        if (direction[1] == 0)//down
            WallInstantiate(DownWall);
        else
            HorizDoorInstantiate(DownCorrider);
        if (direction[2] == 0)//left
            WallInstantiate(LeftWall);
        else
            VerticalDoorInstantiate(LeftCorrider);
        if (direction[3] == 0)//right 
            WallInstantiate(RightWall);
        else
            VerticalDoorInstantiate(RightCorrider);

    }

    private void WallInstantiate(GameObject wall)
    {
        Instantiate(wall, transform.position, Quaternion.identity, gameObject.transform);
    }

    private void VerticalDoorInstantiate(GameObject VDoor)
    {
        VDoors.Add(Instantiate(VDoor,transform.position,Quaternion.identity,gameObject.transform).GetComponentInChildren<VerticalDoor>());
    }

    private void HorizDoorInstantiate(GameObject HDoor)
    {
        HDoors.Add(Instantiate(HDoor, transform.position, Quaternion.identity, gameObject.transform).GetComponentInChildren<Door>());
    }


    /// <summary>
    /// 玩家进入房间
    /// </summary>
    public void PlayerEnterRoom()
    {
        IsActivated = true;
        SetAllDoor(true);
    }

    /// <summary>
    /// 设置房间所有门的状态
    /// </summary>
    /// <param name="isClose">是否关闭</param>
    public void SetAllDoor(bool isClose)
    {
        foreach (var door in HDoors)
        {
            door.SetDoor(isClose);
        }
        foreach (var door in VDoors)
        {
            door.SetCollider(isClose);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            if (!IsActivated && !IsPassed)
            {
                PlayerEnterRoom();
                EnemyGenerator.GenerateEnemy();
            }
            PlayerExplore?.Invoke(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerExplore?.Invoke(false);
        }
    }

}
