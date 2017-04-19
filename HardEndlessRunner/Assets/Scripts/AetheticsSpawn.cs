using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AetheticsSpawn : MonoBehaviour {

    public int spawnMaxChance;
    [Space(5)]
    public List<GameObject> aestheticsObjectsList;

    GameObject instantObj;

    Transform parentTrans;
   

    // Use this for initialization
    void Awake()
    {
        parentTrans = GameObject.Find("Aesthetic Parent").transform;

        int ranNum = Random.Range(0, spawnMaxChance + 1);

        if (ranNum == spawnMaxChance)
        {
          instantObj = Instantiate(aestheticsObjectsList[Random.Range(0, aestheticsObjectsList.Count)], transform.position, Quaternion.identity);

            instantObj.transform.parent = parentTrans;
        }

      

      

    }
}
