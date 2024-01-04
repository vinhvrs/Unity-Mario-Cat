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

    public bool haveMushroom = false;
    public bool haveCoin = false;
    public bool haveStar = false;

    //Get Mario level
    GameObject Mario;
    private void Awake()
    {
        Mario = GameObject.FindGameObjectWithTag("Player");
    }

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
            Origin_Pos = transform.position;
            Bounc_up();
        } 
    }

    private void Bounc_up()
    {
        if (bounc_able)
        {
            StartCoroutine(Bounc());
            bounc_able = false;
            
            if(haveMushroom)
            {
                DropItems();
            }
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
            GameObject Null_Block = (GameObject)Instantiate(Resources.Load("Prefabs/Null_Block"));
            Null_Block.transform.position = Origin_Pos;
            yield return null;
        }
    }

    void DropItems()
    {
        int currentLevel = Mario.GetComponent<Mario_Script>().player_lv;
        GameObject mushroom = null;
        
        if (currentLevel == 0) mushroom = (GameObject)Instantiate(Resources.Load("Prefabs/mushroom"));
        else mushroom = (GameObject)Instantiate(Resources.Load("Prefabs/mushroom"));
        
        Mario.GetComponent<Mario_Script>().CreateAudio("smb_vine");
        mushroom.transform.SetParent(this.transform.parent);
        mushroom.transform.localPosition = new Vector2(Origin_Pos.x, Origin_Pos.y + 1f);
    }

}
