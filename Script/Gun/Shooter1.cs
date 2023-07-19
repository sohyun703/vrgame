using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class Shooter1 : MonoBehaviour
{
	[SerializeField]
	private LayerMask hittableMask;
	[SerializeField]
	private GameObject hitEffectPrefab;
	[SerializeField]
	private Transform shootPoint;
	[SerializeField]
	private float shootDelay = 0.1f;
	[SerializeField]
	private float maxDistance = 100;
	[SerializeField]
	private UnityEvent<Vector3> onShootSuccess;
	[SerializeField]
	private UnityEvent onShootFail;




	private void Start()
	{
		Stop();
	}

	public void Play()
	{
		StopAllCoroutines();
		StartCoroutine("Process");
	}

	public void Stop()
	{
		StopAllCoroutines();
	}

	private IEnumerator Process()
	{
		while (true)
		{
			Shoot();
			
			yield return new WaitForSeconds(shootDelay);
		}
	}

	private void Shoot()
	{
		if (Physics.Raycast(shootPoint.position, shootPoint.forward, out RaycastHit hitInfo, maxDistance, hittableMask))
		{
			//Instantiate(hitEffectPrefab, hitInfo.point, Quaternion.identity);

			Hittable hitObject = hitInfo.transform.GetComponent<Hittable>();
			hitObject?.Hit();

			onShootSuccess?.Invoke(hitInfo.point);
		}
		else
		{
			Vector3 hitPoint = shootPoint.position + shootPoint.forward * maxDistance;
			onShootSuccess?.Invoke(hitPoint);
		}
	}
}


