using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Mario_Script : MonoBehaviour
{
    private float velo = 7;
    private float maxVelo = 16f;
    private bool Turn_around = false;
    private float Speed = 0;
    private float Run_Jump = 8;
    private float low_Jump = 5;
    private float gra_down = 5;
    private bool Landing = true;
    private bool ChangingDirection = false;
    private bool Jump = false;
    private float checkKeyDown = 0.2f;
    private float timeKeyDown = 0;
    private Rigidbody2D body;
    private Animator animations;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animations.SetFloat("Speed", Speed);
        animations.SetBool("Landing", Landing);
        animations.SetBool("ChangingDirection", ChangingDirection);
        animations.SetBool("Jump", Jump);

        Jump_Up(); 
        FireShotAndSprinting(); 
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        float Horizontal_Move = Input.GetAxis("Horizontal");
        body.velocity = new Vector2 (velo*Horizontal_Move, body.velocity.y);
        Speed = Mathf.Abs(velo*Horizontal_Move);
        if (Horizontal_Move > 0 && Turn_around) ChangingDirection_Direct();
        if (Horizontal_Move < 0 && !Turn_around) ChangingDirection_Direct();

    }

    public void ChangingDirection_Direct()
    {
        Turn_around = !Turn_around;
        Vector2 Direction = transform.localScale;
        Direction.x *= -1;
        transform.localScale = Direction;
        if(Speed > 0.5f){
            StartCoroutine(MarioChangingDirection());
        }
    }

    public void Jump_Up()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && Landing && !Jump)
        {
            Jump = true;
            Landing = false;
            if (Run_Jump == 0)
            {
                Run_Jump = 4;
            }
            if (Run_Jump < 3)
            {
                Run_Jump += 2;
            }
            body.AddForce((Vector2.up) * Run_Jump * 100);
        }
        if (body.velocity.y < 0)
        {
            print("DOWN");
            body.velocity += Vector2.up * Physics2D.gravity.y * (gra_down - 1) * Time.deltaTime;
        }
        else if (body.velocity.y >= 0 && Input.GetKey(KeyCode.UpArrow))
        {
            body.velocity += Vector2.up * Physics2D.gravity.y * (low_Jump - 1) * Time.deltaTime;
            //Gravity default
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Landing = true;
        Jump = false;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Jump = false;
        Landing = true;
    }

    IEnumerator MarioChangingDirection(){
        ChangingDirection = true;
        yield return new WaitForSeconds(0.2f);
        ChangingDirection = false;
    }

    //Fire shot & Sprinting
    void FireShotAndSprinting(){
        if (Input.GetKey(KeyCode.Space)){
            timeKeyDown += Time.deltaTime;
            if (timeKeyDown < checkKeyDown){
                print("Shooting!");
            }
            else{ 
                velo = velo * 1.01f;
                if (velo > maxVelo) velo = maxVelo;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            velo = 7f;
            timeKeyDown = 0;
        }
    }
}
