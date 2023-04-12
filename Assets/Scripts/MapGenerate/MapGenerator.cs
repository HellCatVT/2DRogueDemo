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
        [Header("���ɷ��������")]
        public int NumOfRooms = 0;
        [Header("����Ŀ�")]
        public int RoomWidth = 20;
        [Header("����ĸ�")]
        public int RoomHeight = 14;

        public List<Vector2> RoomLocation;//�������淿���λ����Ϣ

        public List<Room> Rooms = new List<Room>();

        public int EndRoomIndex = 0;//����������list���е�λ��
        public enum direction { UP, Down, Right, Left };

        public static Action OnMapGenerateFInished;//��ͼ��������¼����۲���ģʽ

        public List<GameObject> RoomOBJ;//��������б�

        public GameObject StartRoom;//��ʼ����

        public GameObject EndRoom;//��������


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
        /// �Բ�ͬ�������ȡ����
        /// </summary>
        /// <returns>����</returns>
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
        /// ���ɵ�ͼ��������
        /// </summary>
        private void MapListGenerate()
        {
            Vector2 currentRoomLocation = new Vector2(0,0);//{x,y}
            RoomLocation.Add(currentRoomLocation);//�趨���Ϊ0,0
            int currentNumOfRooms = 1;//��ǰ
            direction nextDirection;
            while (currentNumOfRooms < NumOfRooms)
            {
                nextDirection =RandomDirection();//����õ�һ������
                switch (nextDirection)//�ı�currentRoomLocation����ֵ
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
                        && RoomLocation[i].y == currentRoomLocation.y)//����Ӧλ�����������
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
        /// ����ͼ��
        /// </summary>
        public void MapGenerate()
        {
            MapListGenerate();
            FindEndRoom();
            Debug.Log("MapGeneration Finished!");
            GameMapInstantiate();
        }

        /// <summary>
        /// �ҵ��������䣬�Ծ�����ԶΪ��׼
        /// </summary>
        public void FindEndRoom()
        {
           float maxRoomDistance = 0f;
           for(int i = 1; i < RoomLocation.Count; i++)
           {
                if (Vector2.Distance(RoomLocation[i], RoomLocation[0]) > maxRoomDistance)//�ȽϾ���
                {
                    maxRoomDistance = Vector2.Distance(RoomLocation[i], RoomLocation[0]);
                    EndRoomIndex = i;
                }
           }
        }

        /// <summary>
        /// ������ɷ���
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
        /// ���ɿ�ʼ����
        /// </summary>
        private Room StartRoomInstatiate()
        {
            Room room = RoomInstantiate(0,StartRoom).GetComponent<Room>();
            room.IsPassed = true;
            return room;
        }


        /// <summary>
        /// ���ɽ�������
        /// </summary>
        private Room EndRoomInstatiate()
        {
            return RoomInstantiate(EndRoomIndex,EndRoom).GetComponent<Room>();
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="roomIndex">������List���е����</param>
        /// <param name="roomOBJ">����Ԥ����</param>
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