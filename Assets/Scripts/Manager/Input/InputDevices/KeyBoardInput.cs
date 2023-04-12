using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInput : IInput
{

    /// <summary>
    /// 是否按下攻击键
    /// </summary>
    /// <returns></returns>
    bool IInput.IsAttack()
    {
        return Input.GetMouseButtonDown(0) || Input.GetMouseButton(0);
    }



    Vector2 IInput.MoveDirection()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey("w"))
            dir.y += 1;
        if ( Input.GetKey("s"))
            dir.y -= 1;
        if ( Input.GetKey("d"))
            dir.x += 1;
        if (Input.GetKey("a"))
            dir.x -= 1;
            
        return dir.normalized;
        
    }


    Vector2 IInput.PointPosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//将屏幕坐标转化为世界坐标
        return new Vector2 (pos.x, pos.y);
    }

    bool IInput.IsSkilRelease()
    {
        throw new System.NotImplementedException();
    }


    bool IInput.IsSwitchWeapon()
    {
        throw new System.NotImplementedException();
    }

    public bool IsMenuButton()
    {
        return Input.GetKey(KeyCode.Escape);
    }
}
