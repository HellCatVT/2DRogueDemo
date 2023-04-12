using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEffect : MonoBehaviour
{
    private Animator Anim;

    private void Start()
    {
        transform.rotation = Quaternion.identity;
        Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
