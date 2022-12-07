using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public GameObject player;

    private float playerInput = 0;

    private bool canDash = true;
    private bool isDashing;

    Rigidbody2D _rb2D;
    Collider2D playerCollider;

    [SerializeField] private TrailRenderer tr;

    playerPref Player2 = new playerPref(3, 6f, 12f, 2, 25f, 0.1f, 1f);

    void Start()
    {
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

        transform.position += Vector3.right * Player2.speed * playerInput * Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerInput = 1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerInput = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerInput = -1;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerInput = 0;
        }

        if (Player2.jumpCount > 0 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            _rb2D.velocity = Vector3.zero;
            _rb2D.AddForce(Player2.jumpforce * Vector3.up, ForceMode2D.Impulse);
            Player2.jumpCount = -1;
        }

        if (Input.GetKeyDown("[6]") && canDash)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _rb2D.velocity = Vector3.zero;
            _rb2D.AddForce(10 * Vector3.down, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            Player2.jumpCount = 2;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            Player2.jumpCount = 1;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = _rb2D.gravityScale;
        _rb2D.gravityScale = 0f;
        _rb2D.velocity = new Vector3((transform.localScale.x * playerInput) * Player2.dashingPower, 0f, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(Player2.dashingTime);
        _rb2D.velocity = new Vector3(transform.localScale.x / Player2.dashingPower, 0f, 0f);
        tr.emitting = false;
        _rb2D.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(Player2.dashingCooldown);
        canDash = true;
    }
}
