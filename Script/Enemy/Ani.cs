using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Ani : MonoBehaviour
{
    Animator animator;
    public GameObject Target;
    //public AudioSource audio;

    private void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(Target.transform.position, transform.position);
        
        if (distance < 3)
        {
            animator.SetBool("IsAttack", true);
          //  Debug.Log("Hi");
        }
    }
    public void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.tag == "bullet")

        {
            animator.SetBool("IsDie", true);
            //audio.Play();
            print("¤Ç¤Á¤µ");
        }


    }
}


