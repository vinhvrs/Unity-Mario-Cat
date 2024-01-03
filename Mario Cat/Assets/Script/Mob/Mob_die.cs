using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_die : MonoBehaviour
{   
    Vector2 Die_Pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && collision.contacts[0].normal.y < 0)
        {
            GameObject Mob_die = (GameObject)Instantiate(Resources.Load("Prefabs/mushroom_monster_die"));
            Die_Pos = transform.position;
            Mob_die.transform.localPosition = Die_Pos;
            Destroy(gameObject);
        }
    }


}
