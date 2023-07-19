using System.Collections;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
	private MovementTransform movement;
	private float projectileDistance = 10;  // �߻�ü �ִ� �߻�Ÿ�
	private int damage = 3;                 // �߻�ü ���ݷ�
	public AudioSource audioSource;






	public void Setup(Vector3 position)
	{
		movement = GetComponent<MovementTransform>();
		StartCoroutine("OnMove", position);
	}

	private IEnumerator OnMove(Vector3 targetPosition)
	{
		Vector3 start = transform.position;

		movement.MoveTo((targetPosition - transform.position).normalized);

		while (true)
		{
			if (Vector3.Distance(transform.position, start) >= projectileDistance)
			{
				Destroy(gameObject);

				yield break;
			}

			yield return null;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			print("hit");
			//other.GetComponent<PlayerController>().TakeDamage(damage);

			Destroy(gameObject);
			//audioSource.Play();

			other.GetComponent<health>().TakeDamage(damage);
		}
	}
	

}

