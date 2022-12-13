using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public GameObject player;

    private float playerInput = 0;

    private bool canDash = true;
    private bool isDashing;

    private bool isKnocked;

    Rigidbody2D _rb2D;
    Collider2D playerCollider;

    [SerializeField] private TrailRenderer tr;

    playerPref Player1 = new playerPref(3, 6f, 5f, 0f, 12f, 2, 25f, 0.1f, 1f);

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isKnocked)
        {
            return;
        }

        if (isDashing)
        {
            return;
        }

        transform.position += Vector3.right * Player1.speed * playerInput * Time.deltaTime;

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

        if (Player1.jumpCount > 0 && Input.GetKeyDown(KeyCode.W))
        {
            _rb2D.velocity = Vector3.zero;
            _rb2D.AddForce(Player1.jumpforce * Vector3.up, ForceMode2D.Impulse);
            Player1.jumpCount =- 1;
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
            Player1.jumpCount = 2;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            Player1.jumpCount = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("damage"))
        {
            Player1.health += 5;
            Vector3 moveDirection = _rb2D.transform.position - collision.transform.position;
            _rb2D.velocity = Vector3.zero;
            _rb2D.AddForce(moveDirection.normalized * (100f + 4f * Player1.health));
            StartCoroutine(Knocked());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = _rb2D.gravityScale;
        _rb2D.gravityScale = 0f;
        _rb2D.velocity = new Vector3((transform.localScale.x * playerInput) * Player1.dashingPower, 0f, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(Player1.dashingTime);
        _rb2D.velocity = new Vector3(transform.localScale.x / Player1.dashingPower, 0f, 0f);
        tr.emitting = false;
        _rb2D.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(Player1.dashingCooldown);
        canDash = true;
    }

    private IEnumerator Knocked()
    {
        isKnocked = true;
        yield return new WaitForSeconds(0.35f);
        isKnocked = false;
    }
}
