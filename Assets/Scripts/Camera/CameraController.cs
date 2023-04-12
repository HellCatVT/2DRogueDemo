using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("相机移动限制范围")]
    public float MoveDistance = 1f;

    private float FastSpeed = 2f;
    private float SlowSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }


    /// <summary>
    /// 相机移动
    /// </summary>
    private void CameraMove()
    {
        Vector2 distance = new Vector2(
            GameManager.Instance.Player.transform.position.x - transform.position.x,
            GameManager.Instance.Player.transform.position.y - transform.position.y
            );

        if (distance.magnitude > MoveDistance)//超出距离，快速回位
            transform.Translate(Mathf.Lerp(0,distance.x,FastSpeed * Time.deltaTime),Mathf.Lerp(0,distance.y, FastSpeed * Time.deltaTime),0);
        else                                  //缓慢回位
            transform.Translate(Mathf.Lerp(0, distance.x, SlowSpeed * Time.deltaTime), Mathf.Lerp(0, distance.y, SlowSpeed * Time.deltaTime), 0);
    }

}
