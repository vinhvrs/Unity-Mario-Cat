using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    GameObject Mario;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Mario = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
            PowerActivate();
        }
    }

    private void PowerActivate()
    {
        switch (this.tag)
        {
            case "RED":
                Mario.GetComponent<Mario_Script>().red_mushroom = true;
                break;
            case "GREEN":
                Mario.GetComponent<Mario_Script>().green_mushroom = true;
                break;
        }
    }

}
