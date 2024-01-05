using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Mario_Script : MonoBehaviour{
    private float velo = 5f;
    private float maxVelo = 16f;
    private bool Turn_around = false;
    private float Speed = 0;
    private float Run_Jump = 8f;
    private float gra_down = 5f;
    private bool Landing = true;
    private bool ChangingDirection = false;
    private bool Jump = false;
    private float checkKeyDown = 0.2f;
    private float timeKeyDown = 0;
    private Rigidbody2D body;
    private Animator animations;
    private AudioSource Mario_sounds;

    // POWER MUSHROOM HAVING
    public bool mushroom = false;
    public bool flower = false;
    public bool star = false;
    public bool coin = false;

    //Show level and size
    public int player_lv = 1;
    public bool power_up = false;

    private Vector2 Die_Pos;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animator>();
        Mario_sounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        //animations.SetBool("Jump", Jump);
        animations.SetFloat("Speed", Speed);
        animations.SetBool("Landing", Landing);
        animations.SetBool("ChangingDirection", ChangingDirection);

        Jump_Up();
        FireShotAndSprinting();
        if (mushroom)
        {
            player_lv = 2;
            power_up = true;
        }
        if (flower)
        {
            player_lv = 3;
            power_up = true;
        }
        if (coin)
        {   
            coin = false;
        }
        if (star)
        {
            star = false;
        }
        if (power_up) {
            switch (player_lv) {
                case 1:
                    StartCoroutine(Small());
                    power_up = false;
                    break;
                case 2:
                    CreateAudio("PowerUp");
                    StartCoroutine(Titan());
                    mushroom = false;
                    power_up = false;
                    break;
                case 3:
                    CreateAudio("PowerUp");
                    StartCoroutine(Fire());
                    flower = false;
                    power_up = false;
                    break;
                default:
                    power_up = false;
                    break;
            }
        }

        if (gameObject.transform.position.y < -10f)
        {
            Mario_die();
        }

    }

    private void FixedUpdate() {
        Move();
    }

    public void Move() {
        float Horizontal_Move = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(velo * Horizontal_Move, body.velocity.y);
        Speed = Mathf.Abs(velo * Horizontal_Move);
        if (Horizontal_Move > 0 && Turn_around) ChangingDirection_Direct();
        if (Horizontal_Move < 0 && !Turn_around) ChangingDirection_Direct();

    }

    public void ChangingDirection_Direct() {
        Turn_around = !Turn_around;
        Vector2 Direction = transform.localScale;
        Direction.x *= -1;
        transform.localScale = Direction;
        if (Speed > 0.5f) {
            StartCoroutine(MarioChangingDirection());
        }
    }

    public void Jump_Up()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && Landing && !Jump) {
            Jump = true;
            Landing = false;
            CreateAudio("Small_jump");
            body.AddForce((Vector2.up) * Run_Jump * 100);
        }

        if (body.velocity.y < 0) {
            body.velocity += Vector2.up * Physics2D.gravity.y * (gra_down - 1) * Time.deltaTime;
        } else {
            body.velocity += Vector2.up * Physics2D.gravity.y * (gra_down - 3) * Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        Landing = true;
        Jump = false;
    }

    public void OnTriggerStay2D(Collider2D collision) {
        Jump = false;
        Landing = true;
    }
    IEnumerator MarioChangingDirection() {
        ChangingDirection = true;
        yield return new WaitForSeconds(0.2f);
        ChangingDirection = false;
    }

    //Fire shot & Sprinting
    void FireShotAndSprinting() {
        if (Input.GetKey(KeyCode.Space)) {
            timeKeyDown += Time.deltaTime;
            if (timeKeyDown < checkKeyDown) {
                print("Shooting!");
            } else {
                velo = velo * 1.01f;
                if (velo > maxVelo) velo = maxVelo;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            velo = 7f;
            timeKeyDown = 0;
        }
    }

    // Power Up
    public IEnumerator Titan() {
        print("Titan");
        float time_delay = 0.1f;
        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 1);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 0);
        yield return new WaitForSeconds(time_delay);

        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 1);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 0);
        yield return new WaitForSeconds(time_delay);

        // Repeat for loop big -> small -> big -> small -> big
        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 1);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 0);
        yield return new WaitForSeconds(time_delay);

        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 1);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 0);
        yield return new WaitForSeconds(time_delay);

        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 1);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 0);
        yield return new WaitForSeconds(time_delay);
    }

    public IEnumerator Fire() {
        float time_delay = 0.1f;
        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 1);
        yield return new WaitForSeconds(time_delay);

        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 0);
        yield return new WaitForSeconds(time_delay);

        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 1);
        yield return new WaitForSeconds(time_delay);

        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 0);
        yield return new WaitForSeconds(time_delay);

        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 1);
        yield return new WaitForSeconds(time_delay);
    }

    public IEnumerator Small() {
        float time_delay = 0.1f;
        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 1);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 0);
        yield return new WaitForSeconds(time_delay);

        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 1);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 0);
        yield return new WaitForSeconds(time_delay);

        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 1);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 0);
        yield return new WaitForSeconds(time_delay);

        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 1);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 0);
        yield return new WaitForSeconds(time_delay);

        animations.SetLayerWeight(animations.GetLayerIndex("Normal_Mario"), 1);
        animations.SetLayerWeight(animations.GetLayerIndex("Giant_Mario"), 0);
        animations.SetLayerWeight(animations.GetLayerIndex("Fire_Mario"), 0);
        yield return new WaitForSeconds(time_delay);
    }

    public void Mario_die()
    {
        GameObject Mario_die = (GameObject)Instantiate(Resources.Load("Prefabs/Mario_die"));
        Die_Pos = transform.position;
        Mario_die.transform.localPosition = Die_Pos;
        Destroy(gameObject);
    }

    public void CreateAudio(string FileAudio) 
    {
        Mario_sounds.PlayOneShot(Resources.Load<AudioClip>("Audio/" + FileAudio));
    }
}
