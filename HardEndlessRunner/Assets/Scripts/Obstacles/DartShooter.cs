using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartShooter : MonoBehaviour {

    public float timeToShoot;
    float timer;

    public float dartSpeed;

    public GameObject dartObj;

    // Use this for initialization
    void Awake()
    {
       

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= timeToShoot)
        {
            GameObject gIns = Instantiate(dartObj, new Vector2(transform.position.x - 1f,transform.position.y), Quaternion.identity);

            gIns.GetComponent<Dart>().speed = dartSpeed;

            timer = 0;
        }


    }

}
