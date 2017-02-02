using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float rightSpeed;

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

   
    Rigidbody2D rig;

    [Space(5)]
    public GameMaster gMaster;
    [Space(10)]
    public bool isPC;


    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
      
        gMaster = gMaster.GetComponent<GameMaster>();

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
        }
        else
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

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Saw")   // game Over
        {
            print("Dead");

            gMaster.isGameOver = true;
        }

        if (col.gameObject.tag == "Spike")
        {
            print("Spike");

            gMaster.isGameOver = true;
        }

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


}
