using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.Animations;
#endif
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour
{
    public GameObject DoorChild;

    private Animator DoorAnim;

    private AnimatorStateInfo AnimInfo;

    private bool IsToClose = false;

    // Start is called before the first frame update
    void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y / 100);//设置z轴遮挡关系

        DoorAnim = DoorChild.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentAnimatorInfo();
    }

    private void FixedUpdate()
    {
        ColliderControl();
    }

    /// <summary>
    /// 设置门的状态
    /// </summary>
    /// <param name="isClose">是否关闭</param>
    public void SetDoor(bool isClose)
    {
        IsToClose = isClose;
        DoorAnim.SetBool("IsPlayerApproch", !isClose);
        DoorChild.GetComponent<BoxCollider2D>().enabled = !isClose;

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !IsToClose)
        {
            DoorAnim.SetBool("IsPlayerApproch", true);
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DoorAnim.SetBool("IsPlayerApproch", false);
        }
    }

    private void ColliderControl()
    {
        if (!IsToClose && DoorAnim.GetBool("IsPlayerApproch") && AnimInfo.normalizedTime >=1f && AnimInfo.IsName("LargeDoor_Open Animation"))
        {
            DoorChild.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            DoorChild.GetComponent<BoxCollider2D>().enabled = true;
        }

    }

    private void GetCurrentAnimatorInfo()
    {
        AnimInfo = DoorAnim.GetCurrentAnimatorStateInfo(0);
    }
}
