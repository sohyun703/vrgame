using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class count3 : MonoBehaviour
{

    //public GameObject Item;
    public GameObject item;
    public GameObject[] Count;
    private int enemyInt;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("bullet"))

        {
            Count = GameObject.FindGameObjectsWithTag("Enemy");
            enemyInt = Count.Length;
            print(enemyInt);

            call();
        }

    }


    public void call()
    {
        if (enemyInt == 1)
        {
            // Instantiate(Item, new Vector3(176.71f, 8f, 205.76f), Quaternion.identity);
            Instantiate(item, new Vector3(160.48f, 5.56f, 213.85f), Quaternion.identity);
        }
    }

}

