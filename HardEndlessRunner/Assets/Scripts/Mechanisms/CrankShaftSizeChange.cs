using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankShaftSizeChange : MonoBehaviour
{

    [Header("Size")]
    public float maxSizeFront;
    public float maxSizeBack;

    public float sizeTime;
    [Header("Move")]
    public float minYPos;
    public float maxYPos;

    //public float minYPosPiston;
    //public float maxYPosPiston;

    float addedY;
    float minusY;

    //float addedYPiston;
    //float minusYPiston;

    float startY;
   // float startYPiston;

    public float moveTime;
    [Space(5)]
    public float universalTime;


    public bool isFront;
    public bool isBack;

    public Sprite upSprite;
    public Sprite downSprite;

    SpriteRenderer sprRend;

    //public GameObject pistonObj;

    public InOutSpikes spikeCS;

    // Use this for initialization
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();

        //upSprite = sprRend.sprite;


        startY = transform.localPosition.y;

        addedY = startY + maxYPos;

        minusY = startY - minYPos;


        //startYPiston = pistonObj.transform.localPosition.y;

        //addedYPiston = startYPiston + maxYPosPiston;

        //minusYPiston = startYPiston - minYPosPiston;

    }

    // Update is called once per frame
    void Update()
    {
        if (isFront)
        {
            transform.localScale = Vector3.Lerp(new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z), new Vector3(maxSizeFront, maxSizeFront, transform.localScale.z), Time.deltaTime * universalTime);

            transform.localPosition = Vector3.Lerp(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), new Vector3(transform.localPosition.x, addedY, transform.localPosition.z), Time.deltaTime * universalTime);

            sprRend.sprite = upSprite;

            // pistonObj.transform.localScale = Vector3.Lerp(new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z), new Vector3(maxSizeFront, maxSizeFront, transform.localScale.z), Time.deltaTime * universalTime);

            // pistonObj.transform.localPosition = Vector3.Lerp(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), new Vector3(transform.localPosition.x, addedYPiston, transform.localPosition.z), Time.deltaTime * 3);

            if (transform.localScale.x >= maxSizeFront - 0.05f)
            {
                //print("Top");

              //  sprRend.flipY = false;


                spikeCS.isActive = true;
                spikeCS.isDeactive = false;

                isBack = true;
                isFront = false;
            }
        }
        else if (isBack)
        {
            transform.localScale = Vector3.Lerp(new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z), new Vector3(maxSizeBack, maxSizeBack, transform.localScale.z), Time.deltaTime * universalTime);

            transform.localPosition = Vector3.Lerp(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), new Vector3(transform.localPosition.x, minusY, transform.localPosition.z), Time.deltaTime * universalTime);

            sprRend.sprite = downSprite;


            //pistonObj.transform.localScale = Vector3.Lerp(new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z), new Vector3(maxSizeBack, maxSizeBack, transform.localScale.z), Time.deltaTime * universalTime);
            
           // pistonObj.transform.localPosition = Vector3.Lerp(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), new Vector3(transform.localPosition.x, minYPosPiston, transform.localPosition.z), Time.deltaTime * 3);



            if (transform.localScale.x <= maxSizeBack + 0.05f)
            {
                //print("Bottom");

               // pistonObj.transform.localPosition = Vector3.Lerp(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), new Vector3(transform.localPosition.x, addedYPiston, transform.localPosition.z), Time.deltaTime * universalTime);

               // sprRend.flipY = true;


                spikeCS.isDeactive = true;
                spikeCS.isActive = false;



                isFront = true;
                isBack = false;

            }
        }

    }
}
