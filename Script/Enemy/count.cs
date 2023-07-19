using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class count : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onCreated;

    //public GameObject Item;
    public GameObject button;
    public GameObject[] Count;
    private int enemyInt;


    public void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.tag.Equals("bullet"))

        {
            Count = GameObject.FindGameObjectsWithTag("Enemy");
            enemyInt = Count.Length;
            print(enemyInt);
            print("¤Ç¤Á");
            call();
        }

    }

    public void call()
    { 
            if (enemyInt == 1)
            {
                // Instantiate(Item, new Vector3(176.71f, 8f, 205.76f), Quaternion.identity);
                Instantiate(button, new Vector3(176.71f, 5.7f, 205.76f), Quaternion.identity);
            }
        }
       
    
}
