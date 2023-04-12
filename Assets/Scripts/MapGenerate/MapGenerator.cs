using Game.UI;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Game.Controller
{
    public class MapGenerator : Singleton<MapGenerator>
    {
        [Header("生成房间的数量")]
        public int NumOfRooms = 0;
        [Header("房间的宽")]
        public int RoomWidth = 20;
        [Header("房间的高")]
        public int RoomHeight = 14;

        public List<Vector2> RoomLocation;//用链表储存房间的位置信息

        public List<Room> Rooms = new List<Room>();

        public int EndRoomIndex = 0;//结束房间在list当中的位置
        public enum direction { UP, Down, Right, Left };

        public static Action OnMapGenerateFInished;//地图生成完成事件，观察者模式

        public List<GameObject> RoomOBJ;//随机房间列表

        public GameObject StartRoom;//开始房间

        public GameObject EndRoom;//结束房间


        void Start()
        {
            OnMapGenerateFInished += EnablePlayerMove;
            RoomLocation = new List<Vector2>();
            MapGenerate();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void EnablePlayerMove()
        {
            GameManager.Instance.Player.GetComponent<PlayerController>().enabled = true;
        }

        /// <summary>
        /// 以不同概率随机取方向
        /// </summary>
        /// <returns>方向</returns>
        private direction RandomDirection()
        {
            direction dir;
            System.Random random = new System.Random();
            int k = random.Next(16);
            if (k < 1)
                dir = direction.Left;
            else if(k < 5)
                dir = direction.Down;
            else if(k < 9)
                dir = direction.UP;
            else
                dir = direction.Right;
            return dir;
        } 

        /// <summary>
        /// 生成地图房间坐标
        /// </summary>
        private void MapListGenerate()
        {
            Vector2 currentRoomLocation = new Vector2(0,0);//{x,y}
            RoomLocation.Add(currentRoomLocation);//设定起点为0,0
            int currentNumOfRooms = 1;//当前
            direction nextDirection;
            while (currentNumOfRooms < NumOfRooms)
            {
                nextDirection =RandomDirection();//随机得到一个方向
                switch (nextDirection)//改变currentRoomLocation坐标值
                {
                    case direction.UP:
                        currentRoomLocation.y+= 1; 
                        break;
                    case direction.Down:
                        currentRoomLocation.y -= 1;
                        break;
                    case direction.Left:
                        currentRoomLocation.x -= 1; 
                        break;
                    case direction.Right:
                        currentRoomLocation.x += 1;
                        break;
                }

                for (int i = 0; i < RoomLocation.Count; i++)
                {
                    if (RoomLocation[i].x == currentRoomLocation.x
                        && RoomLocation[i].y == currentRoomLocation.y)//若对应位置已有则回退
                    {
                        currentRoomLocation = RoomLocation[i];
                        break;
                    }
                    else if(i == RoomLocation.Count-1)
                    {
                        RoomLocation.Add(currentRoomLocation);
                        currentNumOfRooms++;
                    }
                }
            }
        }

        /// <summary>
        /// 生成图像
        /// </summary>
        public void MapGenerate()
        {
            MapListGenerate();
            FindEndRoom();
            Debug.Log("MapGeneration Finished!");
            GameMapInstantiate();
        }

        /// <summary>
        /// 找到结束房间，以距离最远为基准
        /// </summary>
        public void FindEndRoom()
        {
           float maxRoomDistance = 0f;
           for(int i = 1; i < RoomLocation.Count; i++)
           {
                if (Vector2.Distance(RoomLocation[i], RoomLocation[0]) > maxRoomDistance)//比较距离
                {
                    maxRoomDistance = Vector2.Distance(RoomLocation[i], RoomLocation[0]);
                    EndRoomIndex = i;
                }
           }
        }

        /// <summary>
        /// 随机生成房间
        /// </summary>
        private void GameMapInstantiate()
        {
            
            Rooms.Add(StartRoomInstatiate());
            for (int i = 1; i < RoomLocation.Count;i++)//
            {
                if (i == EndRoomIndex)
                    Rooms.Add(EndRoomInstatiate());
                else
                    Rooms.Add(RoomInstantiate(i, RoomOBJ[0]).GetComponent<Room>());
            }
            OnMapGenerateFInished?.Invoke();
        }

        /// <summary>
        /// 生成开始房间
        /// </summary>
        private Room StartRoomInstatiate()
        {
            Room room = RoomInstantiate(0,StartRoom).GetComponent<Room>();
            room.IsPassed = true;
            return room;
        }


        /// <summary>
        /// 生成结束房间
        /// </summary>
        private Room EndRoomInstatiate()
        {
            return RoomInstantiate(EndRoomIndex,EndRoom).GetComponent<Room>();
        }

        /// <summary>
        /// 房间生成
        /// </summary>
        /// <param name="roomIndex">房间在List当中的序号</param>
        /// <param name="roomOBJ">房间预制体</param>
        public GameObject RoomInstantiate(int roomIndex,GameObject roomOBJ)
        {
            Vector2 location;
            location.x = RoomLocation[roomIndex].x * RoomWidth;
            location.y = RoomLocation[roomIndex].y * RoomHeight;
            GameObject room = Instantiate(roomOBJ, location, Quaternion.identity) as GameObject;
            room.GetComponent<Room>().RoomIndex = roomIndex;
            room.GetComponent<Room>().WallAndCorriderGenerate();
            return room;
        }
    }
}