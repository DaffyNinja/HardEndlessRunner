using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveLava : MonoBehaviour {

    public float rightSpeed;
    float startingRightSpeed;

    Animator anMate;

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

    Rigidbody2D rig;

    //[Header("Audio")]
    //public AudioClip landSFX;
    //bool playLandSound;
    //AudioSource aSource;

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

    bool jumpHeld;
    bool jumpUp;
    bool jumpPressed;



    // Use this for initialization
    void Awake ()
    {
        groundCheckTran = transform.Find("GroundCheck");

        rig = GetComponent<Rigidbody2D>();

        gMaster = gMaster.GetComponent<GameMaster>();

        anMate = GetComponent<Animator>();

        startingRightSpeed = rightSpeed;

        sprRend = GetComponent<SpriteRenderer>();


        screenPosX = Screen.width / 2;  // Half the screen x pos to control the touch positions on phone

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

        // Right Movement
        Vector2 moveQuality = new Vector2(rightSpeed, 0);
        rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);


        // Input
        if (isPC)  // PC Controls
        {
            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping && grounded)
            {
                isJumping = true;

                startTimer = true;

                rig.velocity = new Vector2(rig.velocity.x, JumpAcceleration);

                rig.AddForce(new Vector2(jumpRightForce, 0));



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


        }
        else if (isPC == false)
        {
            {
                // Buttons
                if (isButtons)
                {
                    // Jump
                    if (jumpHeld == true && grounded && !isJumping)
                    {
                        isJumping = true;

                        startTimer = true;

                       // playLandSound = true;
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

                  
                }
                else if (isTouch)   // Touch
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

                       // playLandSound = true;
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


                }

            }

        }

    }
}
