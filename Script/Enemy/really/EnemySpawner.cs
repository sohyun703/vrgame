using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField]
	private int currentEnemyCount = 0;

	[SerializeField]
	private Vector3 rotation;
	[SerializeField]
	private Vector3 buttonPosition;
	public int CurrentEnemyCount
    {
		set
        {
			currentEnemyCount = value;
			if ( currentEnemyCount == 0 )
            {
				if (CurrentEnemyCount == 0)
				{
					print("ȣ��");
					Instantiate(button, buttonPosition, Quaternion.Euler(rotation));
				}
				// ��ư ����
			}
        }
		get => currentEnemyCount;
    }

	[SerializeField]
	private GameObject enemyPrefab;
	[SerializeField]
	private UnityEvent onCreated;
	[SerializeField]
	private bool isPlayOnStart = true;      // ������ �������ڸ��� ���� ������ ������?
	[SerializeField]
	private float startFactor = 1;          // �� ���� ���� �⺻ ��
	[SerializeField]
	private float additiveFactor = 0.1f;        // �� ���� ���ڿ� �� �� �������� ��
	[SerializeField]
	private float delayPerSpawnGroup = 3;       // �� ���� �ֱ�
	//private int count =0; // �� ���� Ƚ��
	public float enemy = 0;
	public GameObject bullet;
	public bool isStart = false; // true �� �� ����
	public GameObject button;

	[SerializeField]
	private AudioSource createEnemy;
	public AudioClip prefabSound;
	[SerializeField]
	private GameObject range;
	BoxCollider rangeCollider;

	[SerializeField]
	private int count = 0;

	[SerializeField]
	private int Maxcount = 0;

	private void Awake()
	{
		if (isPlayOnStart)
		{
			Play();
		}
		onCreated?.Invoke();
		rangeCollider = range.GetComponent<BoxCollider>();
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

			factor += additiveFactor;
		}
	}

	private IEnumerator SpawnEnemy(float factor)
	{
		
		float spawnCount = Random.Range(factor, factor*2);
		enemy += spawnCount;
	//	GameObject.Find("bullet").GetComponent("Destroy").call();
		//Debug.Log(enemy);
		count += 1;
		if (count == Maxcount)
		{
			Stop();
		}

		for (int i = 0; i < spawnCount; ++i)
		{
			GameObject clone = Instantiate(enemyPrefab, Return_RandomPosition(), transform.rotation, transform);
			createEnemy.Play();
			clone.GetComponent<Enemy>().Setup(this);
			isStart = true;
			currentEnemyCount++;

			if (Random.value < 0.2f)
			{
				yield return new WaitForSeconds(Random.Range(0.01f, 0.02f));
			}

			
		}


		
	}

	Vector3 Return_RandomPosition()
	{
		Vector3 originPosition = range.transform.position;
		// 콜라이더의 사이즈를 가져오는 bound.size 사용
		float range_X = rangeCollider.bounds.size.x;
		float range_Z = rangeCollider.bounds.size.z;

		range_X = Random.Range((range_X / 2) * -1, range_X / 2);
		range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
		Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

		Vector3 respawnPosition = originPosition + RandomPostion;
		return respawnPosition;
	}
}


