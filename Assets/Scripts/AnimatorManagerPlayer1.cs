using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManagerPlayer1 : MonoBehaviour
{
    public static Animator anim;

    public Rigidbody2D _rb2D;
    public Transform trans;

    private int MovementInt = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        this.transform.position = trans.position;

        if (Input.GetKey(KeyCode.D))
        {
            MovementInt = 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            MovementInt = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovementInt = -1;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            MovementInt = 0;
        }

        anim.SetInteger("MoveDir", MovementInt);

        /*if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("punch");
        }*/
    }

    public static void Punch()
    {
        anim.SetTrigger("punch");
    }

    public static void Lowblow()
    {
        anim.SetTrigger("lowblow");
    }

    public static void Uppercut()
    {
        anim.SetTrigger("uppercut");
    }

    public static void Dash()
    {
        anim.SetTrigger("punch");
    }
}
