using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    private float playerInput = 0;

    private bool canDash = true;
    private bool isDashing;

    private bool canAttack = true;
    private bool canBlock = true;
    private bool isKnocked;
    private bool isBlocking;

    Rigidbody2D _rb2D;
    Collider2D playerCollider;

    [SerializeField] private TrailRenderer tr;

    playerPref Player2 = new playerPref(3, 6f, 5f, 0f, 12f, 2, 50f, 0.1f, 1f);

    private GameObject FrontAttack;
    private GameObject UpAttack;
    private GameObject BottomAttack;
    private GameObject Shield;

    GameObject winner;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        FrontAttack = transform.GetChild(0).gameObject;
        UpAttack = transform.GetChild(1).gameObject;
        BottomAttack = transform.GetChild(2).gameObject;
        Shield = transform.GetChild(3).gameObject;
        winner = GameObject.Find("winner");
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
            AnimatorManagerPlayer2.anim.SetTrigger("jump");
            _rb2D.AddForce(Player2.jumpforce * Vector3.up, ForceMode2D.Impulse);
            Player2.jumpCount =- 1;
        }

        if(Input.GetKey(KeyCode.Keypad5) && canBlock == true)
        {
            isBlocking = true;
            canDash = false;
            AnimatorManagerPlayer2.anim.SetBool("blocking", true);
            Shield.SetActive(true);
            Player2.speed = 0.5f;
        }
        if(Input.GetKeyUp(KeyCode.Keypad5))
        {
            isBlocking = false;
            canDash = true;
            AnimatorManagerPlayer2.anim.SetBool("blocking", false);
            Shield.SetActive(false);
            Player2.speed = 6f;
        }

        if (Input.GetKeyDown(KeyCode.Keypad7) && canAttack)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                StartCoroutine(AttackUp());
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                StartCoroutine(AttackDown());
            }
            else
            {
                StartCoroutine(AttackFront());
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad6) && canDash)
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

        if (collision.gameObject.CompareTag("Border"))
        {
            Player2.lives -= 1;

            if (Player2.lives > 0)
            {
                StartCoroutine(Death());
            }
            else
            {
                gameObject.SetActive(false);
                GameOver();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            Player2.jumpCount = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damage1") && isBlocking == false)
        {
            Player2.health += 5;
            AnimatorManagerPlayer2.anim.SetTrigger("getsDamaged");
            Vector3 moveDirection = _rb2D.transform.position - collision.transform.position;
            _rb2D.velocity = Vector3.zero;
            _rb2D.AddForce(moveDirection.normalized * (100f + 4f * Player2.health));
            _rb2D.AddForce(5 * Vector3.up, ForceMode2D.Impulse);
            StartCoroutine(Knocked());
        }
        if (collision.gameObject.CompareTag("Damage1") && isBlocking == true)
        {
            Player2.health += 2;
            Vector3 moveDirection = _rb2D.transform.position - collision.transform.position;
            _rb2D.velocity = Vector3.zero;
            _rb2D.AddForce(moveDirection.normalized * (100f + 2f * Player2.health));
            _rb2D.AddForce(1.1f * Vector3.up, ForceMode2D.Impulse);
        }
    }

    private IEnumerator Death()
    {
        _rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        isKnocked = true;
        yield return new WaitForSeconds(2f);
        _rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        isKnocked = false;
        _rb2D.velocity = Vector3.zero;
        Player2.health = 0;
        transform.position = new Vector3(0, 0, 1);
    }

    void GameOver()
    {
        winner.GetComponent<Win>().P1HasWon();
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        canBlock = false;
        float originalGravity = _rb2D.gravityScale;
        _rb2D.gravityScale = 0f;
        _rb2D.velocity = new Vector3((transform.localScale.x * playerInput) * Player2.dashingPower, 0f, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(Player2.dashingTime);
        _rb2D.velocity = new Vector3(transform.localScale.x / Player2.dashingPower, 0f, 0f);
        tr.emitting = false;
        _rb2D.gravityScale = originalGravity;
        isDashing = false;
        canBlock = true;
        yield return new WaitForSeconds(Player2.dashingCooldown);
        canDash = true;
    }

    private IEnumerator AttackFront()
    {
        canAttack = false;
        canBlock = false;
        AnimatorManagerPlayer2.Punch();
        yield return new WaitForSeconds(0.2f);
        FrontAttack.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        FrontAttack.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        canAttack = true;
        canBlock = true;
    }
    private IEnumerator AttackUp()
    {
        canAttack = false;
        canBlock = false;
        AnimatorManagerPlayer2.Uppercut();
        yield return new WaitForSeconds(0.2f);
        UpAttack.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        UpAttack.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        canAttack = true;
        canBlock = true;
    }
    private IEnumerator AttackDown()
    {
        canAttack = false;
        canBlock = false;
        AnimatorManagerPlayer2.Lowblow();
        yield return new WaitForSeconds(0.2f);
        BottomAttack.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        BottomAttack.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        canAttack = true;
        canBlock = true;
    }

    private IEnumerator Knocked()
    {
        isKnocked = true;
        yield return new WaitForSeconds(0.35f);
        isKnocked = false;
    }
}
