using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Lucky_Block : MonoBehaviour
{
    private float bounc_value = 0.5f;
    private float bounc_speed = 4f;
    private bool bounc_able = true;
    private Vector2 Origin_Pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player" && col.contacts[0].normal.y > 0)
        {
            Bounc_up();
            DropItems();
        } 
    }

    private void Bounc_up()
    {
        if (bounc_able)
        {
            Origin_Pos = transform.position;
            StartCoroutine(Bounc());
            bounc_able = false;
        }
    }

    IEnumerator Bounc()
    {   
        //Let the box bounce a little
        while (true)
        {   
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + bounc_speed * Time.deltaTime);
            if (transform.localPosition.y <= Origin_Pos.y + bounc_value)
            {
                break;
            }
            yield return null;
        }
        
        //Let the '?' symbol change to normal box
        while (true)
        {   transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - bounc_speed * Time.deltaTime);
            if (transform.localPosition.y >= Origin_Pos.y + bounc_value)
            {
                break;
            }
            yield return null;
            Destroy(gameObject);
            GameObject Null_Block = (GameObject)Instantiate(Resources.Load("Prefabs/Null_Block"));
            Null_Block.transform.position = Origin_Pos;
        }
    }

     private void DropItems()
    {
        switch (gameObject.tag)
        {
            case "mushroom":
                Origin_Pos.y += 1;
                GameObject mushroom = (GameObject)Instantiate(Resources.Load("Prefabs/mushroom"));
                mushroom.transform.position = Origin_Pos;
                Origin_Pos.y -= 1;
                break;
            case "flower":
                Origin_Pos.y += 1;
                GameObject flower = (GameObject)Instantiate(Resources.Load("Prefabs/flower"));
                flower.transform.position = Origin_Pos;
                Origin_Pos.y -= 1;
                break;
            case "star":
                Origin_Pos.y += 1;
                GameObject star = (GameObject)Instantiate(Resources.Load("Prefabs/star"));
                star.transform.position = Origin_Pos;
                Origin_Pos.y -= 1;
                break;
            case "coin":
                Origin_Pos.y += 1;
                GameObject coin = (GameObject)Instantiate(Resources.Load("Prefabs/coin"));
                coin.transform.position = Origin_Pos;
                Origin_Pos.y -= 1;
                break;
        }
            
    }

}