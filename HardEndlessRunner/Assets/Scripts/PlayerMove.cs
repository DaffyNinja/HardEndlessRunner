﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float rightSpeed;
    float startingRightSpeed;

    [Header("Jump")]
    public float timeForFullJump = 2.0f;
    public float minJumpForce = 0.5f;
    public float maxJumpForce = 2.0f;
    public float rightJumpForce = 1.0f;

    float timeHeld = 0.0f;
    Vector2 resolvedJump;
    [Space(5)]
    public float groundCheck;

    bool grounded;
    bool inAir;
    bool fall;

    [Header("Special Abilities")]
    public float boostSpeed;
    public float boostTime;
    float boostTimer;
    public bool obtainedBoost;
    [Space(5)]
    public float shieldTime;
    float shieldTimer;
    public bool obtainedShield;



    Rigidbody2D rig;

    [Space(5)]
    public GameMaster gMaster;
    [Space(10)]
    public bool isPC;


    // Use this for initialization
    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();

        gMaster = gMaster.GetComponent<GameMaster>();

        startingRightSpeed = rightSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(rightSpeed, 0, 0);

        grounded = Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheck), 1 << LayerMask.NameToLayer("Ground"));

        if (isPC)
        {
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                timeHeld = 0f;
            }

            if (Input.GetKey(KeyCode.Space) && grounded)
            {
                timeHeld += Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.Space) && grounded)
            {
                Jump();
            }

            // Slide
        }
        else      // Mobile  
        {

            if (Input.touchCount > 0 && grounded)
            {
                print("Touch");

                //Jump();

                timeHeld += Time.deltaTime;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && grounded)
            {
                print("Touch Up");

                Jump();
            }

            // Slide
        }

        if (grounded)
        {
            resolvedJump = new Vector2(0, 0);
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (timeHeld >= timeForFullJump && grounded == true)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        SpecialAbilities();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Saw" && obtainedShield == false)   // game Over
        {
            print("Dead");

            gMaster.isGameOver = true;
        }
        else if (col.gameObject.tag == "Saw" && obtainedShield == true)
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (col.gameObject.tag == "Spike" && obtainedShield == false)
        {
            print("Spike");

            gMaster.isGameOver = true;
        }
        else if (col.gameObject.tag == "Spike" && obtainedShield == true)
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (col.gameObject.tag == "Pillar")
        {
            print("Pillar");

            //gMaster.isGameOver = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Dart" && obtainedShield == false)
        {
            print("Dart");

            gMaster.isGameOver = true;
        }
        else if (col.gameObject.tag == "Dart" && obtainedShield == true)
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }


        //print(col.gameObject.layer);

    }



    void Jump()
    {

        float verticalJumpForce = ((maxJumpForce - minJumpForce) * (timeHeld / timeForFullJump)) + minJumpForce;

        if (verticalJumpForce > maxJumpForce)
        {
            verticalJumpForce = maxJumpForce;
        }

        timeHeld = 0;

        resolvedJump = new Vector2(rightJumpForce, verticalJumpForce);

        rig.AddForce(resolvedJump, ForceMode2D.Impulse);

    }

    void SpecialAbilities()
    {
        // Boost
        if (obtainedBoost)
        {
            rightSpeed = boostSpeed;

            boostTimer += Time.deltaTime;

            if (boostTimer >= boostTime)
            {
                obtainedBoost = false;
            }

        }
        else if (obtainedBoost == false)
        {
            rightSpeed = startingRightSpeed;

            boostTimer = 0;
        }

        // Shield
        if (obtainedShield)
        {
            shieldTimer += Time.deltaTime;

            if (shieldTimer >= shieldTime)
            {
                obtainedShield = false;
            }
        }
        else if (obtainedShield == false)
        {
            shieldTimer = 0;
        }


    }


}
