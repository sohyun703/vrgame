using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public static GameObject cloneEnemy;
    public GameObject prefab;
    public GameObject enemyMove;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        cloneEnemy = Instantiate(enemyMove, new Vector3(20, 30, 0), Quaternion.identity);
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement / 10);
        cloneEnemy.transform.position = Vector3.MoveTowards(cloneEnemy.transform.position, transform.position, 0.01f);
    }
}
