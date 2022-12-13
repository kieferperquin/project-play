using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Combat : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Attack();
        }
    }

    void Attack()
    {
        // play attack animation
        // detect opponent in range
    }
}
