using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario_die : MonoBehaviour
{
    public float bounc_speed = 25f;
    public float bounc_high = 70f;
    private Vector2 Die_Pos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Mario_die_animation());
    }

    IEnumerator Mario_die_animation()
    {
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + bounc_speed * Time.deltaTime);
            //print(Time.deltaTime);
            if (transform.localPosition.y >= Die_Pos.y + bounc_high + 1)
            {
                break;
            }
            yield return null;
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - bounc_speed * Time.deltaTime);
            if (gameObject.transform.position.y < -70f)
            {
                Destroy(gameObject);
                break;
            }
            yield return null;
        }
    }
}
