using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyAttack : MonoBehaviour
{
	//���� ����

	public GameObject WayPoint0;

	public GameObject WayPoint1;

	public float MoveSpeed = 3.0f;

	public float RotationSpeed = 2.0f;

	bool isWayPoint = false;

	bool isSearch = false;

	public GameObject Target; //New Challenger!!



	void Start()
	{

		//animation.Play("idle");

	}



	void Update()
	{

		//Ž���ϴ� �ɸ��� ����, �ƴϸ� ��Ҵ�� ��Ʈ��

		if (isSearch == true)
		{ //������ Ž�� ������ �߰���

			Attack(); //���ݱ��			

		}

		else
		{

			//animation.Play("run");

			WayPointMove(); //��Ʈ�� ���

		}

	}



	void WayPointMove()
	{

		if (isWayPoint == false)
		{

			//ȸ��

			transform.rotation =

				Quaternion.Slerp(transform.rotation,

 				Quaternion.LookRotation(WayPoint1.transform.position - transform.position), 1);

			//�̵�

			transform.Translate(Vector3.forward * Time.smoothDeltaTime * MoveSpeed);

			//����

			if (Vector3.Distance(transform.position, WayPoint1.transform.position) <= 0.5f)

				isWayPoint = true;

		}

		else
		{

			//ȸ��

			transform.rotation =

				Quaternion.Slerp(transform.rotation,

 				Quaternion.LookRotation(WayPoint0.transform.position - transform.position), 1);

			//�̵�

			transform.Translate(Vector3.forward * Time.smoothDeltaTime * MoveSpeed);

			//����

			if (Vector3.Distance(transform.position, WayPoint0.transform.position) <= 0.5f)

				isWayPoint = false;

		}



		Search();//Ž����� <-New Challenger!!

	}



	void Search()
	{

		float distance = Vector3.Distance(Target.transform.position, transform.position);

		//�Ÿ��� ��������� Ž���� �ɸ�

		if (distance <= 10)

			isSearch = true;

	}



	void Attack()
	{

		//animation.CrossFade("shoot", 0.5f); //�ִϸ��̼� ����

		//���ƺ��� ������ �÷��̾� ������

		transform.rotation =

				Quaternion.Slerp(transform.rotation,

 				Quaternion.LookRotation(Target.transform.position - transform.position), Time.smoothDeltaTime * 5.0f);

		float distance = Vector3.Distance(Target.transform.position, transform.position);

		//�Ÿ��� �־����� Ž�� ����

		if (distance > 10)

			isSearch = false;

	}

}

