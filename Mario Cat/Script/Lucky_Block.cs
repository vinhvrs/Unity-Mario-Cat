using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Lucky_Block : MonoBehaviour
{
    private float bounc_value = 0.5f;
    private float bounc_speed = 4f;
    private bool bounc_able = true;
    private Vector3 Origin_Pos;
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
            GameObject Null_Block = (GameObject)Instantiate(Resources.Load("Prefabs/Null_Block"));
            Null_Block.transform.position = Origin_Pos;
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
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + bounc_speed*Time.deltaTime);
            if (transform.localPosition.y >= Origin_Pos.y + bounc_value)
            {
                break;
            }
            yield return null;
        }
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - bounc_speed * Time.deltaTime);
            if (transform.localPosition.y <= Origin_Pos.y)
            {
                break;
            }
            Destroy(gameObject);
            yield return null;
        }
    }

    private void DropItems()
    {
        switch (gameObject.tag)
        {
            case "RED":
                Origin_Pos.y += 1;
                GameObject RED_Mushroom = (GameObject)Instantiate(Resources.Load("Prefabs/RED_Mushroom"));
                RED_Mushroom.transform.position = Origin_Pos;
                Origin_Pos.y -= 1;
                break;
            case "GREEN":
                Origin_Pos.y += 1;
                GameObject GREEN_Mushroom = (GameObject)Instantiate(Resources.Load("Prefabs/GREEN_Mushroom"));
                GREEN_Mushroom.transform.position = Origin_Pos;
                Origin_Pos.y -= 1;
                break;
        }
            
    }

}
