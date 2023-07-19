using System.Collections;
using UnityEngine;

public class FlashLineRenderer : MonoBehaviour
{
	[SerializeField]
	private float duration = 0.05f;
	private LineRenderer target;

	private void Awake()
	{
		target = GetComponent<LineRenderer>();
	}

	public void Call()
	{
		StopAllCoroutines();
		StartCoroutine("Process");
	}

	private IEnumerator Process()
	{
		target.enabled = true;

		yield return new WaitForSeconds(duration);

		target.enabled = false;
	}
}

