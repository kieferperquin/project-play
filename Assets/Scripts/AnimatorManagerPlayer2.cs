using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManagerPlayer2 : MonoBehaviour
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

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MovementInt = 1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            MovementInt = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MovementInt = -1;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            MovementInt = 0;
        }

        anim.SetInteger("MoveDir", MovementInt);

        /*if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("punch");
        }*/
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("Jump", true);
        }
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
