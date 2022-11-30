using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public GameObject player;

    float speed;
    float jumpforce;
    float playerInput;

    int jumpCount = 2;

    Rigidbody2D _rb2D;
    Collider2D playerCollider;

    void Start()
    {
        speed = 5f;
        jumpforce = 8f;
        _rb2D = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * playerInput * Time.deltaTime;

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

        if (jumpCount > 0 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            _rb2D.AddForce(jumpforce * Vector3.up, ForceMode2D.Impulse);
            jumpCount = -1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
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
}
