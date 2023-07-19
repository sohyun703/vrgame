using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtirl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "sword")
        {
            Debug.Log("COLLSION");
            NewBehaviourScript.cloneEnemy = Instantiate(gameObject, new Vector3(Random.Range(-20f, 20f), 30, Random.Range(10f, 50f)), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
