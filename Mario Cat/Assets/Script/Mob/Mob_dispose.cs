using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_dispose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Mob_death());
    }

    IEnumerator Mob_death()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
}
