using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AetheticsSpawn : MonoBehaviour {

    public int spawnMaxChance;
    [Space(5)]
    public List<GameObject> aestheticsObjectsList;
    //[Space(5)]
    //public List<Texture2D> aestheticsSpritesList;

    // Use this for initialization
    void Awake()
    {
        int ranNum = Random.Range(0, spawnMaxChance + 1);

        if (ranNum == spawnMaxChance)
        {
           Instantiate(aestheticsObjectsList[Random.Range(0, aestheticsObjectsList.Count)], transform.position, Quaternion.identity);
            
            //else // Sprites
            //{
            //    Instantiate(aestheticsSpritesList[Random.Range(0, aestheticsSpritesList.Count)], transform.position, Quaternion.identity);
            //}
        }

    }
}
