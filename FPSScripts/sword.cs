using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    bool swing = false;
    public int rotX;
    int rotPx;
    public static GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        rotX = 0;
        rotPx = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swing = true;
            // print('0');
        }
        if (swing == true)
        {
            if (rotX > 90)
            {
                rotPx = rotPx * -1;
            }
            rotX = rotX + rotPx * 2;
            transform.localRotation = Quaternion.Euler(rotX, 0, 0);
            if (rotX <= 0)
            {
                swing = false;
                rotX = 0;
                rotPx = rotPx * -1;
                ;
            }
        }


    }
}


