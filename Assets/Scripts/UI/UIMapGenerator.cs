using Game.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI 
{
    public class UIMapGenerator : MonoBehaviour
    {
        // Start is called before the first frame update
        [Header("")]
        public GameObject RoomImage;
        public List<GameObject> UIMapList;
        public List<Vector2> LocationList;

        private void OnEnable()
        {
            MapGenerator.OnMapGenerateFInished += UIMapGenerate;//注册事件
        }

        private void OnDisable()
        {
            MapGenerator.OnMapGenerateFInished -= UIMapGenerate;//注销事件
        }
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        /// <summary>
        /// 在UI上生成小地图
        /// </summary>
        public void UIMapGenerate()
        {
            LocationList = MapGenerator.Instance.RoomLocation;
            float imageWidth = RoomImage.GetComponent<RectTransform>().rect.width;
            Vector2 location, center = FindCenter();
            for (int i = 0; i < LocationList.Count; i++)
            {
                location.x = (LocationList[i].x-center.x) * 3f * imageWidth + gameObject.transform.position.x ;//将原点置于地图中心,再移动到小地图位置
                location.y = (LocationList[i].y-center.y) * 3f * imageWidth + gameObject.transform.position.y;
                GameObject UIRoom = Instantiate(RoomImage, location, Quaternion.identity, gameObject.transform);
                UIRoom.GetComponent<UIMapChange>().BeListener(i);
                UIMapList.Add(UIRoom);//获得小地图元素的list
            }
        }

        /// <summary>
        /// 找到小地图的中心
        /// </summary>
        /// <returns></returns>
        public Vector2 FindCenter()
        {
            float mapXSum = 0, mapYSum = 0; 
            foreach (var item in LocationList)//累加各点的坐标值
            {
                mapXSum += item.x;
                mapYSum += item.y;
            }

            return new Vector2(mapXSum / LocationList.Count, mapYSum / LocationList.Count);//计算中心值
        }



    }
}

