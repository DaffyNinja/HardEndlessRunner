using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    bool canMove;
    public float rightSpeed;
    float startingRightSpeed;

    [Header("Jump")]
    public float JumpAcceleration;
    public float jumpRightForce;
    bool isJumping;
    public float jumpTime;
    float jumpTimer;
    public bool startTimer;

    Transform groundCheckTran;
    [Space(5)]
    public float groundedRadius = 0.4f;
    bool grounded;

    [Header("Slide")]
    public float slideSpeed;
    public float timeForFullSlide;
    public float slideTimeDivide;

    // The players colliders when they slide and are not sliding
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

    [Header("Special Abilities")]   // The players special abilities
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
    [Header("Audio")]
    public AudioClip landSFX;
    bool playLandSound;
    AudioSource aSource;

    [Header("Input")]
    public bool isButtons;
    public bool isTouch;

    public float screenPosX;
    Vector2 touchPos;

    [Space(5)]
    public GameMaster gMaster;
    [Space(10)]
    public bool isIOS;
    public bool isPC;

    SpriteRenderer sprRend;

    bool slidePressed;

    bool jumpHeld;
    bool jumpUp;
    bool jumpPressed;

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

        aSource = GetComponent<AudioSource>();

        screenPosX = Screen.width / 2;  // Half the screen x pos to control the touch positions on phone

        playLandSound = false;

    }

    void Update()
    {
        if (isIOS == true)
        {
            // determines wether the player is grounded or not
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
                if (!obtainedBoost && canMove)
                {
                    Vector2 moveQuality = new Vector2(rightSpeed, 0);
                    rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
                }
                else if (obtainedBoost && canMove)
                {
                    Vector2 moveQuality = new Vector2(boostSpeed, 0);
                    rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
                }

            }
            else if (slideTongle == 1)
            {
                Vector2 moveQuality = new Vector2(slideSpeed, 0);
                rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
            }

            // Stops Player
            if (gMaster.isGameOver)
            {
                rig.bodyType = RigidbodyType2D.Static;
            }


            // Controls 
            if (isPC && canMove == true)  // PC Controls
            {
                //Jump
                if (Input.GetKeyDown(KeyCode.Space) && !isJumping && grounded)
                {
                    isJumping = true;

                    startTimer = true;

                    rig.velocity = new Vector2(rig.velocity.x, JumpAcceleration);

                    rig.AddForce(new Vector2(jumpRightForce, 0));

                    playLandSound = true;

                }
                else if (Input.GetKey(KeyCode.Space) && isJumping && jumpTimer < jumpTime && startTimer)
                {
                    if (startTimer)
                    {
                        jumpTimer += Time.deltaTime;
                    }
                    else
                    {
                        isJumping = false;
                    }

                    rig.velocity = new Vector2(rig.velocity.x, JumpAcceleration);

                    rig.AddForce(new Vector2(jumpRightForce, 0));
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                {
                    startTimer = false;
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

                }

            }
            else if (isPC == false && canMove == true)      // Mobile  
            {
                // Buttons
                if (isButtons)
                {
                    // Jump
                    if (jumpHeld == true && grounded && !isJumping)
                    {
                        isJumping = true;

                        startTimer = true;
                    }
                    else if (jumpHeld == true && isJumping && jumpTimer < jumpTime && startTimer)
                    {
                        if (startTimer)
                        {
                            jumpTimer += Time.deltaTime;
                        }
                        else
                        {
                            isJumping = false;
                        }

                        rig.velocity = new Vector2(rig.velocity.x, JumpAcceleration);
                    }

                    if (jumpUp == true)
                    {
                        startTimer = false;
                    }

                    // Sliding
                    if (slideTongle == 0 && slidePressed == true && grounded)
                    {

                        boxCol.size = new Vector2(boxCol.size.x + colBoxXSize, boxCol.size.y - colBoxYSize);
                        circCol.radius = colCirRadius;

                        sprRend.sprite = slideSpr;

                        rightSpeed = slideSpeed;

                        slideTongle = 1;

                        slidePressed = false;

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
                    if (Input.touchCount > 0 && touchPos.x < screenPosX && Input.GetTouch(0).phase == TouchPhase.Stationary && grounded && !isJumping)
                    {
                        isJumping = true;

                        startTimer = true;
                    }
                    else if (touchPos.x < screenPosX && Input.touchCount > 0 && isJumping && jumpTimer < jumpTime && startTimer)
                    {
                        if (startTimer)
                        {
                            jumpTimer += Time.deltaTime;
                        }
                        else
                        {
                            isJumping = false;
                        }

                        rig.velocity = new Vector2(rig.velocity.x, JumpAcceleration);
                    }

                    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        startTimer = false;
                    }


                    // SLide Touch
                    if (slideTongle == 0)
                    {
                        if (touchPos.x > screenPosX && Input.touchCount > 0 && grounded)  //  Is sliding 
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

            }


            SpecialAbilities();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isIOS == false)
        {
            // determines wether the player is grounded or not
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
                if (!obtainedBoost && canMove)
                {
                    Vector2 moveQuality = new Vector2(rightSpeed, 0);
                    rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
                }
                else if (obtainedBoost && canMove)
                {
                    Vector2 moveQuality = new Vector2(boostSpeed, 0);
                    rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
                }

            }
            else if (slideTongle == 1)
            {
                Vector2 moveQuality = new Vector2(slideSpeed, 0);
                rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
            }

            // Stops Player
            if (gMaster.isGameOver)
            {
                rig.bodyType = RigidbodyType2D.Static;
            }


            // Controls 
            if (isPC && canMove == true)  // PC Controls
            {
                //Jump
                if (Input.GetKeyDown(KeyCode.Space) && !isJumping && grounded)
                {
                    isJumping = true;

                    startTimer = true;

                    rig.velocity = new Vector2(rig.velocity.x, JumpAcceleration);

                    rig.AddForce(new Vector2(jumpRightForce, 0));

                    playLandSound = true;

                }
                else if (Input.GetKey(KeyCode.Space) && isJumping && jumpTimer < jumpTime && startTimer)
                {
                    if (startTimer)
                    {
                        jumpTimer += Time.deltaTime;
                    }
                    else
                    {
                        isJumping = false;
                    }

                    rig.velocity = new Vector2(rig.velocity.x, JumpAcceleration);

                    rig.AddForce(new Vector2(jumpRightForce, 0));
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                {
                    startTimer = false;
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

                }

            }
            else if (isPC == false && canMove == true)      // Mobile  
            {
                // Buttons
                if (isButtons)
                {
                    // Jump
                    if (jumpHeld == true && grounded && !isJumping)
                    {
                        isJumping = true;

                        startTimer = true;

                        playLandSound = true;
                    }
                    else if (jumpHeld == true && isJumping && jumpTimer < jumpTime && startTimer)
                    {
                        if (startTimer)
                        {
                            jumpTimer += Time.deltaTime;
                        }
                        else
                        {
                            isJumping = false;
                        }

                        rig.velocity = new Vector2(rig.velocity.x, JumpAcceleration);
                    }

                    if (jumpUp == true)
                    {
                        startTimer = false;
                    }

                    // Sliding
                    if (slideTongle == 0 && slidePressed == true && grounded)
                    {

                        boxCol.size = new Vector2(boxCol.size.x + colBoxXSize, boxCol.size.y - colBoxYSize);
                        circCol.radius = colCirRadius;

                        sprRend.sprite = slideSpr;

                        rightSpeed = slideSpeed;

                        slideTongle = 1;

                        slidePressed = false;

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
                    if (Input.touchCount > 0 && touchPos.x < screenPosX && Input.GetTouch(0).phase == TouchPhase.Stationary && grounded && !isJumping)
                    {
                        isJumping = true;

                        startTimer = true;

                        playLandSound = true;
                    }
                    else if (touchPos.x < screenPosX && Input.touchCount > 0 && isJumping && jumpTimer < jumpTime && startTimer)
                    {
                        if (startTimer)
                        {
                            jumpTimer += Time.deltaTime;
                        }
                        else
                        {
                            isJumping = false;
                        }

                        rig.velocity = new Vector2(rig.velocity.x, JumpAcceleration);
                    }

                    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        startTimer = false;
                    }


                    // SLide Touch
                    if (slideTongle == 0)
                    {
                        if (touchPos.x > screenPosX && Input.touchCount > 0 && grounded)  //  Is sliding 
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

            }

            SpecialAbilities();

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Saw" && obtainedShield == false && obtainedBoost == false)   // Game Over
        {
            gMaster.isGameOver = true;
        }
        else if (col.gameObject.tag == "Saw" && obtainedShield == true || col.gameObject.tag == "Saw" && obtainedBoost == true)
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (col.gameObject.tag == "Spike" && obtainedShield == false && obtainedBoost == false)
        {
            gMaster.isGameOver = true;
        }
        else if (col.gameObject.tag == "Spike" && obtainedShield == true || col.gameObject.tag == "Spike" && obtainedBoost == true)
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
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
        // Ground
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            jumpTimer = 0;
            isJumping = false;
            startTimer = true;
            //aSource.PlayOneShot(landSFX);

        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Ground") && playLandSound == true)
        {
            aSource.PlayOneShot(landSFX);
            playLandSound = false;
        }

        if (col.gameObject.tag == "Dart" && obtainedShield == false)
        {
            print("Dart");

            gMaster.isGameOver = true;
        }
        else if (col.gameObject.tag == "Dart" && obtainedShield == true || col.gameObject.tag == "Dart" && obtainedBoost == true)
        {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (col.gameObject.tag == "Platform" && obtainedBoost == true || col.gameObject.tag == "Track" && obtainedBoost == true)
        {
            print("Hit");

            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

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


            if (boostTimer >= boostTime)
            {
                obtainedBoost = false;
            }

        }
        else if (obtainedBoost == false)
        {
            canMove = true;
            // GetComponent<SpriteRenderer>().color = Color.white;

            boostTimer = 0;
        }

        // Shield
        if (obtainedShield)
        {
            shieldTimer += Time.deltaTime;
            shieldObj.SetActive(true);

            // Stuter Shield
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
