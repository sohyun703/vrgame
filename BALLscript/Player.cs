using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower = 10;
    public int itemCount;
    bool isJump;
    public text manager;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "plane")
        {
            isJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("item"))
        {
            itemCount++;
            other.gameObject.SetActive(false);
            manager.GetITem(itemCount);
        }
    }
}
