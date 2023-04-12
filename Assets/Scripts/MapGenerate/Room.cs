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

    [Header("����Ŀ�")]
    public static int RoomWidth = 16;
    [Header("����ĸ�")]
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
    /// ����ǽ��
    /// </summary>
    public void WallAndCorriderGenerate()
    {
        int[] direction = { 0, 0, 0, 0 };//up,down,left,right,Ϊ1����ͨ��
        float x = 0, y = 0;
        Vector2 location = LocationList[RoomIndex];
        for (int i = 0; i < LocationList.Count; i++)//�ж�ǽ������λ��
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
    /// ��ҽ��뷿��
    /// </summary>
    public void PlayerEnterRoom()
    {
        IsActivated = true;
        SetAllDoor(true);
    }

    /// <summary>
    /// ���÷��������ŵ�״̬
    /// </summary>
    /// <param name="isClose">�Ƿ�ر�</param>
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
