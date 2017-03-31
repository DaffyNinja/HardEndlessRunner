using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AetheticsSpawn : MonoBehaviour {

    public List<GameObject> aestheticsList;

	// Use this for initialization
	void Awake ()
    {
        Instantiate(aestheticsList[Random.Range(0,aestheticsList.Count)], transform.position, Quaternion.identity); 		
	}
}
