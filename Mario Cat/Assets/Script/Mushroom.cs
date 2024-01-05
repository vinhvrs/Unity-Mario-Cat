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
            case "mushroom":
                Mario.GetComponent<Mario_Script>().mushroom = true;
                break;
            case "flower":
                Mario.GetComponent<Mario_Script>().flower = true;
                break;
            case "star":
                Mario.GetComponent<Mario_Script>().star = true;
                Mario.GetComponent<Mario_Script>().CreateAudio("Smb_vine");
                print("You've got yourself a star! Well Done.");
                break;
            case "coin":
                Mario.GetComponent<Mario_Script>().coin = true;
                Mario.GetComponent<Mario_Script>().CreateAudio("Smb_1-up");
                print("You earned a coin! which is useless at this moment.");
                break;
        }
    }

}
