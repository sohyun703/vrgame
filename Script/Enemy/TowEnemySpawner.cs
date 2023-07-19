using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class TowEnemySpawner : MonoBehaviour
{
	[SerializeField]
	public int currentEnemyCount = 0;

	[SerializeField]
	private GameObject enemyPrefab;
	[SerializeField]
	private UnityEvent onCreated;
	[SerializeField]
	private bool isPlayOnStart = true;      // ������ �������ڸ��� ���� ������ ������?
	[SerializeField]
	private float startFactor = 1;          // �� ���� ���� �⺻ ��
	//[SerializeField]
	//private float additiveFactor = 0.1f;        // �� ���� ���ڿ� �� �� �������� ��
	[SerializeField]
	private float delayPerSpawnGroup = 3;       // �� ���� �ֱ�
	private int count = 0; // �� ���� Ƚ��
	public float enemy = 0;
	public GameObject bullet;

	private void Awake()
	{
		if (isPlayOnStart)
		{
			Play();
		}
		onCreated?.Invoke();
	}


	public void Play()
	{
		StartCoroutine("SpawnProcess");

	}

	public void Stop()
	{
		StopAllCoroutines();
	}

	private IEnumerator SpawnProcess()
	{
		float factor = startFactor;

		while (true)
		{
			yield return new WaitForSeconds(delayPerSpawnGroup);

			yield return StartCoroutine(SpawnEnemy(factor));

		}
	}

	private IEnumerator SpawnEnemy(float factor)
	{
		float spawnCount = Random.Range(factor, factor);
		enemy += spawnCount;
		//	GameObject.Find("bullet").GetComponent("Destroy").call();
		//Debug.Log(enemy);
		count += 1;
		if (count == 6)
		{
			Stop();
		}

		for (int i = 0; i < spawnCount; ++i)
		{
			
			GameObject clone = Instantiate(enemyPrefab, transform.position, transform.rotation, transform);
			clone.GetComponent<Enemy2>().Setup(this);
			currentEnemyCount++;

			if (Random.value < 0.2f)
			{
				yield return new WaitForSeconds(Random.Range(0.01f, 0.02f));
			}
		}
	}


}
