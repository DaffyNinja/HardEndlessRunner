using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankShaftSizeChange : MonoBehaviour {

    [Header("Size")]
    public float maxSizeFront;
    public float maxSizeBack;

    public float sizeTime;
    [Header("Move")]
    public float minYPos;
    public float maxYPos;

    float addedY;
    float minusY;

    float startY;

    public float moveTime;

    bool isFront;
    bool isBack;

    SpriteRenderer sprRend;

	// Use this for initialization
	void Start ()
    {
        sprRend = GetComponent<SpriteRenderer>();

        isFront = true;

        startY = transform.localPosition.y;

        addedY = startY + maxYPos;

        minusY = startY - minYPos;
        

		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isFront)
        {
            transform.localScale = Vector3.Lerp(new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z), new Vector3(maxSizeFront, maxSizeFront, transform.localScale.z), Time.deltaTime * sizeTime);

            transform.localPosition = Vector3.Lerp(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), new Vector3(transform.localPosition.x, addedY, transform.localPosition.z), Time.deltaTime * moveTime);

            if (transform.localScale.x >= maxSizeFront - 0.05f && transform.localScale.y >= maxSizeFront - 0.05f)
            {
                //print("Small");
                sprRend.flipY = false;
                
                isBack = true;
                isFront = false;
            }
        }
        else if(isBack)
        {
            transform.localScale = Vector3.Lerp(new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z), new Vector3(maxSizeBack, maxSizeBack, transform.localScale.z), Time.deltaTime * sizeTime);

            transform.localPosition = Vector3.Lerp(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), new Vector3(transform.localPosition.x, minusY, transform.localPosition.z), Time.deltaTime * moveTime);

            if (transform.localScale.x <= maxSizeBack + 0.05f && transform.localScale.y <= maxSizeBack + 0.05f)
            {
                //print("Big");

                sprRend.flipY = true;

                isFront = true;
                isBack = false;
              
            }
        }
		
	}
}
