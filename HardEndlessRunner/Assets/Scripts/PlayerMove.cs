﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    bool canMove;
    public float rightSpeed;
    float startingRightSpeed;

    [Header("Jump")]
    public float timeForFullJump = 2.0f;
    public float minJumpForce = 0.5f;
    public float maxJumpForce = 2.0f;
    public float rightJumpForce = 1.0f;
    [Space(5)]
    public float boostJumpTime;
    public float boostMinJumpForce;
    public float boostMaxJumpForce;
    public float boostRightJumpForc;

    float timeHeld = 0.0f;
    Vector2 resolvedJump;

    Transform groundCheckTran;
    [Space(5)]
    public float groundedRadius = 0.4f;
    bool grounded;

    [Header("Slide")]
    public float slideSpeed;
    public float timeForFullSlide;
    public float slideTimeDivide;

    public float colBoxXSize;
    public float colBoxYSize;
    public float colCirRadius;

    float startBoxXSize;
    float startBoxYSize;
    float startCircRadius;

    BoxCollider2D boxCol;
    CircleCollider2D circCol;

    float slideTimer;
    int slideTongle;

    public Sprite slideSpr;
    Sprite normSpr;

    [Header("Special Abilities")]
    public float boostSpeed;
    public float boostTime;
    float boostTimer;
    public bool obtainedBoost;
    [Space(5)]
    public float shieldTime;
    float shieldTimer;

    public float shieldStutMin;
    public float shieldStutMax;

    public bool obtainedShield;
    GameObject shieldObj;
    Color shieldColour;
    float shieldColourStartingAlpha;
    float alphaLerp;

    float t = 0;

    Rigidbody2D rig;
    [Header("Input")]
    public bool isButtons;
    public bool isTouch;

    public float screenPosX;
    Vector2 touchPos;

    [Space(5)]
    public GameMaster gMaster;
    [Space(10)]
    public bool isPC;


    SpriteRenderer sprRend;

    bool slidePressed;
    bool jumpHeld;
    bool jumpUp;


    // Use this for initialization
    void Awake()
    {
        groundCheckTran = transform.Find("GroundCheck");

        rig = GetComponent<Rigidbody2D>();

        gMaster = gMaster.GetComponent<GameMaster>();

        canMove = true;

        shieldObj = transform.GetChild(0).gameObject;
        shieldObj.SetActive(false);
        shieldColour = shieldObj.GetComponent<SpriteRenderer>().color;
        shieldColourStartingAlpha = shieldColour.a;

        startingRightSpeed = rightSpeed;

        sprRend = GetComponent<SpriteRenderer>();

        normSpr = sprRend.sprite;

        boxCol = GetComponent<BoxCollider2D>();
        circCol = GetComponent<CircleCollider2D>();

        startBoxXSize = boxCol.size.x;
        startBoxYSize = boxCol.size.y;

        startCircRadius = circCol.radius;

        screenPosX = Screen.width / 2;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckTran.position, groundedRadius, 1 << LayerMask.NameToLayer("Ground"));
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
            }
        }

        // grounded = Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheck), 1 << LayerMask.NameToLayer("Ground"));

        // Right movment
        if (slideTongle == 0)
        {
            if (!obtainedBoost)
            {
                Vector2 moveQuality = new Vector2(rightSpeed, 0);
                rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
            }
            else
            {
                Vector2 moveQuality = new Vector2(boostSpeed, 0);
                rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
            }
            // transform.Translate(rightSpeed, 0, 0);      
        }
        else if (slideTongle == 1)
        {
            Vector2 moveQuality = new Vector2(slideSpeed, 0);
            rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
        }
        else if (gMaster.isGameOver == true)
        {
            Vector2 moveQuality = new Vector2(0, 0);
            rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
        }

        if (isPC && canMove == true)
        {
            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                timeHeld = 0f;
            }

            if (Input.GetKeyDown(KeyCode.LeftControl) && grounded)
            {
                //slideTimeHeld = 0f;
            }


            if (Input.GetKey(KeyCode.Space) && grounded)
            {
                timeHeld += Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.Space) && grounded && obtainedBoost == true)
            {
                timeHeld += Time.deltaTime * 3;

            }

            if (Input.GetKeyUp(KeyCode.Space) && grounded)
            {
                Jump();
            }

            // Slide
            if (slideTongle == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl) && grounded)  //  Is sliding 
                {
                    boxCol.size = new Vector2(boxCol.size.x + colBoxXSize, boxCol.size.y - colBoxYSize);
                    circCol.radius = colCirRadius;

                    sprRend.sprite = slideSpr;

                    rightSpeed = slideSpeed;

                    slideTongle = 1;
                }
            }
            else if (slideTongle == 1)
            {
                slideTimer += Time.deltaTime;

                if (slideTimer >= timeForFullSlide) // Change back to normal
                {

                    boxCol.size = new Vector2(startBoxXSize, startBoxYSize);
                    circCol.radius = startCircRadius;

                    sprRend.sprite = normSpr;

                    rightSpeed = startingRightSpeed;

                    slideTongle = 0;
                    slideTimer = 0;
                }

                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    boxCol.size = new Vector2(startBoxXSize, startBoxYSize);
                    circCol.radius = startCircRadius;

                    sprRend.sprite = normSpr;

                    rightSpeed = startingRightSpeed;

                    slideTongle = 0;
                    slideTimer = 0;
                }

            }

        }
        else if (isPC == false && canMove == true)      // Mobile  
        {
            // Buttons
            if (isButtons)
            {
                if (jumpHeld == true && grounded)
                {
                    timeHeld += Time.deltaTime;
                }

                if (jumpHeld == false && jumpUp == true && grounded)
                {
                    Jump();

                    jumpUp = false;
                }

                if (slideTongle == 0)
                {
                    if (slidePressed == true && grounded)  //  Is sliding 
                    {
                        boxCol.size = new Vector2(boxCol.size.x + colBoxXSize, boxCol.size.y - colBoxYSize);
                        circCol.radius = colCirRadius;

                        sprRend.sprite = slideSpr;

                        rightSpeed = slideSpeed;

                        slideTongle = 1;
                    }
                }
                else if (slideTongle == 1)
                {

                    slideTimer += Time.deltaTime;

                    if (slideTimer >= timeForFullSlide) // Change back to normal
                    {
                        boxCol.size = new Vector2(startBoxXSize, startBoxYSize);
                        circCol.radius = startCircRadius;

                        sprRend.sprite = normSpr;

                        rightSpeed = startingRightSpeed;

                        slidePressed = false;

                        slideTongle = 0;
                        slideTimer = 0;

                    }
                }
            }
            else if (isTouch && canMove == true)   // Touch
            {
                // Touch
                if (Input.touchCount > 0)
                {
                    touchPos = Input.GetTouch(0).position;
                }
                else
                {
                    touchPos = new Vector2(0, 0);
                }

                // Jump  Touch
                if (touchPos.x < screenPosX && touchPos.x > 0 && grounded)
                {
                    //print("Touch");
                    timeHeld += Time.deltaTime;

                    if (Input.GetTouch(0).phase == TouchPhase.Ended && grounded)
                    {
                        Jump();
                    }
                }


                // SLide Touch
                if (slideTongle == 0)
                {
                    if (touchPos.x > screenPosX && Input.touchCount > 0 && grounded)  //  Is sliding 
                    {
                        //  print("Slide Touch");

                        boxCol.size = new Vector2(boxCol.size.x + colBoxXSize, boxCol.size.y - colBoxYSize);
                        circCol.radius = colCirRadius;

                        sprRend.sprite = slideSpr;

                        rightSpeed = slideSpeed;

                        slideTongle = 1;
                    }
                }
                else if (slideTongle == 1)
                {

                    slideTimer += Time.deltaTime;

                    if (slideTimer >= timeForFullSlide) // Change back to normal
                    {
                        boxCol.size = new Vector2(startBoxXSize, startBoxYSize);
                        circCol.radius = startCircRadius;

                        sprRend.sprite = normSpr;

                        rightSpeed = startingRightSpeed;

                        slidePressed = false;

                        slideTongle = 0;
                        slideTimer = 0;

                    }
                }
            }

        }

        if (grounded)
        {

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
        if (col.gameObject.tag == "Saw" && obtainedShield == false && obtainedBoost == false)   // game Over
        {
            // print("Dead");

            gMaster.isGameOver = true;
        }
        else if (col.gameObject.tag == "Saw" && obtainedShield == true || col.gameObject.tag == "Saw" && obtainedBoost == true)
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }


        if (col.gameObject.tag == "Spike" && obtainedShield == false && obtainedBoost == false)
        {
            //print("Spike");

            gMaster.isGameOver = true;
        }
        else if (col.gameObject.tag == "Spike" && obtainedShield == true || col.gameObject.tag == "Spike" && obtainedBoost == true)
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (col.gameObject.tag == "Pillar")
        {
            //print("Pillar");

            //gMaster.isGameOver = true;
        }

        // Specials
        if (col.gameObject.tag == "Boost" && obtainedBoost == false && obtainedShield == false)
        {
            obtainedBoost = true;

            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Shield" && obtainedShield == false && obtainedBoost == false)
        {
            obtainedShield = true;

            Destroy(col.gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {


        if (col.gameObject.tag == "Dart" && obtainedShield == false)
        {
            print("Dart");

            gMaster.isGameOver = true;
        }
        else if (col.gameObject.tag == "Dart" && obtainedShield == true || col.gameObject.tag == "Dart" && obtainedBoost == true)
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (col.gameObject.tag == "Platform" && obtainedBoost == true)
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        //print(col.gameObject.layer);

    }

    void Jump()
    {

        if (obtainedBoost == false)
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
        else
        {
            float verticalJumpForce = ((boostMaxJumpForce - boostMinJumpForce) * (timeHeld / boostJumpTime)) + boostMinJumpForce;

            if (verticalJumpForce > boostMaxJumpForce)
            {
                verticalJumpForce = boostMaxJumpForce;
            }

            timeHeld = 0;

            resolvedJump = new Vector2(rightJumpForce, verticalJumpForce);

            rig.AddForce(resolvedJump, ForceMode2D.Impulse);
        }
    }

    //public void JumpButton()
    //{
    //    jumpPressed = true;
    //}

    public void JumpButtonDown()
    {
        jumpUp = false;
        jumpHeld = true;
    }

    public void JumpButtonUp()
    {
        jumpUp = true;
        jumpHeld = false;
    }

    public void SlideButtonDown()
    {
        slidePressed = true;
    }

    public void SlideButtonUp()
    {
        slidePressed = false;
    }

    void SpecialAbilities()
    {
        // Boost
        if (obtainedBoost)
        {
            canMove = false;

            boostTimer += Time.deltaTime;

            GetComponent<SpriteRenderer>().color = Color.yellow;

            rig.gravityScale = 2;

            if (boostTimer >= boostTime)
            {
                obtainedBoost = false;
            }

        }
        else if (obtainedBoost == false)
        {
            canMove = true;

            rig.gravityScale = 1;

            // GetComponent<SpriteRenderer>().color = Color.white;

            boostTimer = 0;
        }

        // Shield
        if (obtainedShield)
        {
            shieldTimer += Time.deltaTime;
            shieldObj.SetActive(true);


            alphaLerp = Mathf.Lerp(shieldStutMin, shieldStutMax, t);

            t += 3 * Time.deltaTime;

            if (t > 1f)
            {
                float temp = shieldStutMax;
                shieldStutMax = shieldStutMin;
                shieldStutMin = temp;
                t = 0.0f;
            }


            if (shieldTimer >= shieldTime / 1.75f)
            {
                shieldObj.GetComponent<SpriteRenderer>().color = new Color(shieldColour.r, shieldColour.g, shieldColour.b, alphaLerp);
            }

            if (shieldTimer >= shieldTime)
            {
                obtainedShield = false;
            }


        }
        else if (obtainedShield == false)
        {

            shieldColour = Color.white;
            shieldObj.GetComponent<SpriteRenderer>().color = new Color(shieldColour.r, shieldColour.g, shieldColour.b, shieldColourStartingAlpha);
            shieldObj.SetActive(false);
            shieldTimer = 0;


        }


    }




}
