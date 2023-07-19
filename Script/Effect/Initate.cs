using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initate : MonoBehaviour
{
    [SerializeField]
    private Vector3 itemPosition;

    [SerializeField]
    private Vector3 enemySpawnerPosition;

    [SerializeField]
    private Vector3 rotation;

    public bool start;
    public GameObject Item;
    public GameObject enemySpawner;
    // Start is called before the first frame update
    public void Start()
    {
        start = true;
    }
    public void call()
    {
        if (start == true)
        {

            Instantiate(Item, itemPosition, Quaternion.Euler(rotation));
            Instantiate(enemySpawner, enemySpawnerPosition, Quaternion.identity);
            start = false;
        }
        
          
        }
    
}

