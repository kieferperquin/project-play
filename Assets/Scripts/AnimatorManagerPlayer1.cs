using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManagerPlayer1 : MonoBehaviour
{
    public static Animator anim;

    public Rigidbody2D _rb2D;

    private int MovementInt = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("Jump", true);
        }

        /*if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("punch");
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("Jump", false);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            anim.SetBool("Death", true);
        }
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

    public static void Dash()
    {
        anim.SetTrigger("punch");
    }
}
