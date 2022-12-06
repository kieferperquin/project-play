using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public GameObject player;

    private float speed;
    private float jumpforce;
    private float playerInput = 0;

    private int jumpCount = 2;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 25f;
    private float dashingTime = 0.1f;
    private float dashingCooldown = 1f;

    Rigidbody2D _rb2D;
    Collider2D playerCollider;

    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        speed = 6f;
        jumpforce = 12f;
        _rb2D = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDashing)
        {
            return;
        }

        transform.position += Vector3.right * speed * playerInput * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            playerInput = 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerInput = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerInput = -1;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerInput = 0;
        }

        if (jumpCount > 0 && Input.GetKeyDown(KeyCode.W))
        {
            _rb2D.velocity = Vector3.zero;
            _rb2D.AddForce(jumpforce * Vector3.up, ForceMode2D.Impulse);
            jumpCount =- 1;
        }

        if(Input.GetKeyDown(KeyCode.E) && canDash)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _rb2D.velocity = Vector3.zero;
            _rb2D.AddForce(10 * Vector3.down, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            jumpCount = 2;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            jumpCount = 1;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = _rb2D.gravityScale;
        _rb2D.gravityScale = 0f;
        _rb2D.velocity = new Vector3((transform.localScale.x * playerInput) * dashingPower, 0f, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        _rb2D.velocity = new Vector3(transform.localScale.x / dashingPower, 0f, 0f);
        tr.emitting = false;
        _rb2D.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
