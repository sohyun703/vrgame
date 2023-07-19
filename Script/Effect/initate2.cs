using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initate2 : MonoBehaviour
{
    public GameObject Item;
    public GameObject enemySpawner;
    // Start is called before the first frame update
    public void call()
    {

        Instantiate(Item, new Vector3(184.91f, 5.56f, 185.85f), Quaternion.identity);
        Instantiate(enemySpawner, new Vector3(160.48f, 5.56f, 213.85f), Quaternion.identity);
    }
}
