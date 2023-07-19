using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ani_3 : MonoBehaviour
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
        // 거리가 3보다 작은 경우 attack 모션
        float distance = Vector3.Distance(Target.transform.position, transform.position);

        if (distance < 3)
        {
            animator.SetBool("IsAttack", true);

        }
    }
    public void EnemyDie()
    {
        Destroy(transform.parent.gameObject);
    }
}
