using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    private static float mob_speed = 2f;
    public bool moveLeft = true;
    GameObject Mario;
    // Start is called before the first frame update
    void Start()
    {
        //Mario = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Mario = GameObject.FindGameObjectWithTag("Player");
    }


    private void FixedUpdate()
    {
        Vector2 move = transform.localPosition;
        if (moveLeft)
        {
            move.x -= mob_speed * Time.deltaTime;
        }
        else 
        {
            move.x += mob_speed * Time.deltaTime;
        }
        transform.localPosition = move;
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // MOVING
        if (collision.contacts[0].normal.x < 0) 
        {
            moveLeft = false;
            ChangeDirection();
        } else if (collision.contacts[0].normal.x > 0)
        {
            moveLeft = true;
            ChangeDirection();
        }
        // FACE WITH PLAYER
        if (collision.collider.tag == "Player")
            if (Mario.GetComponent<Mario_Script>().player_lv > 1)
            {
                Mario.GetComponent<Mario_Script>().player_lv = 1;
                Mario.GetComponent<Mario_Script>().StartCoroutine(Mario.GetComponent<Mario_Script>().Small());
                Mario.GetComponent<Mario_Script>().power_up = false;
            }
            else
            {
                Mario.GetComponent<Mario_Script>().Mario_die();
            }
    }

    private void ChangeDirection()
    {
        moveLeft = !moveLeft;
        Vector2 direction = transform.localScale;
        direction.x *= -1;
        transform.localScale = direction;
    }

}
