using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private Transform Player;
    private float minX = 0;
    private float maxX = 203;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
            Vector3 MarioPos = transform.position;
            MarioPos.x = Player.position.x;
            if (MarioPos.x < minX)
            {
                MarioPos.x = 0;
            }
            if (MarioPos.x > maxX)
            {
                MarioPos.x = maxX;
            }
            transform.position = MarioPos;
        }
    }

    

}
