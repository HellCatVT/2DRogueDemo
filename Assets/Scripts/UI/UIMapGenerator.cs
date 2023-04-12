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
            MapGenerator.OnMapGenerateFInished += UIMapGenerate;//ע���¼�
        }

        private void OnDisable()
        {
            MapGenerator.OnMapGenerateFInished -= UIMapGenerate;//ע���¼�
        }
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        /// <summary>
        /// ��UI������С��ͼ
        /// </summary>
        public void UIMapGenerate()
        {
            LocationList = MapGenerator.Instance.RoomLocation;
            float imageWidth = RoomImage.GetComponent<RectTransform>().rect.width;
            Vector2 location, center = FindCenter();
            for (int i = 0; i < LocationList.Count; i++)
            {
                location.x = (LocationList[i].x-center.x) * 3f * imageWidth + gameObject.transform.position.x ;//��ԭ�����ڵ�ͼ����,���ƶ���С��ͼλ��
                location.y = (LocationList[i].y-center.y) * 3f * imageWidth + gameObject.transform.position.y;
                GameObject UIRoom = Instantiate(RoomImage, location, Quaternion.identity, gameObject.transform);
                UIRoom.GetComponent<UIMapChange>().BeListener(i);
                UIMapList.Add(UIRoom);//���С��ͼԪ�ص�list
            }
        }

        /// <summary>
        /// �ҵ�С��ͼ������
        /// </summary>
        /// <returns></returns>
        public Vector2 FindCenter()
        {
            float mapXSum = 0, mapYSum = 0; 
            foreach (var item in LocationList)//�ۼӸ��������ֵ
            {
                mapXSum += item.x;
                mapYSum += item.y;
            }

            return new Vector2(mapXSum / LocationList.Count, mapYSum / LocationList.Count);//��������ֵ
        }



    }
}

