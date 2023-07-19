using System.Collections;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
	private MovementTransform movement;
	private float projectileDistance = 10;  // 발사체 최대 발사거리
	private int damage = 3;                 // 발사체 공격력
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

