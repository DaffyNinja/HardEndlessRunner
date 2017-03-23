using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    bool MoveLeft;

     Transform headTrans;
     Transform rodTrans;

    // Use this for initialization
    void Awake()
    {
        headTrans = transform.GetChild(0);
        rodTrans = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
      
        rodTrans.transform.Rotate(0, 0, 2.5f);
    }
}
