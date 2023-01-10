using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    public Rigidbody2D _rb2D;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        int MovementInt = Mathf.RoundToInt(Input.GetAxis("Horizontal"));

        anim.SetInteger("MoveDir", MovementInt);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Jump", true);
        }

        anim.SetFloat("yVelocity", _rb2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Shoot());
        }
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

    IEnumerator Shoot()
    {
        anim.SetBool("Shooting", true);
        yield return new WaitForSeconds(0.35f);
        anim.SetBool("Shooting", false);
        StopCoroutine(Shoot());
    }
}
