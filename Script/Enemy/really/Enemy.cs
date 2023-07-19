using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using System.Collections;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private Vector3 buttonPosition;

	[SerializeField]
	private Animator animator;
	private EnemySpawner enemySpawner;
	private NavMeshAgent navMeshAgent;
	[SerializeField]
	private UnityEvent onCreated;
	[SerializeField]
	private UnityEvent onDestroyed;
	private bool isDestroyed = false;
	public GameObject button;
	public GameObject Target;
	private Transform aitr;
	private Transform playertr;
	[SerializeField]
	private AudioSource EnemyDie;
	[SerializeField]
	private AudioClip EDI;


	public ParticleSystem particleObject; //파티클시스템

	public void Setup(EnemySpawner enemySpawner)
	{
		this.enemySpawner = enemySpawner;
	//	this.target1 = target;
	}

	private void Start()
	{
		Target = GameObject.FindGameObjectWithTag("Player"); //player�� �Ÿ��� ���ϱ� ����
		onCreated?.Invoke();
		navMeshAgent = GetComponent<NavMeshAgent>();
		navMeshAgent.speed *= Random.Range(0.8f, 1.5f);
		aitr = gameObject.GetComponent<Transform>();
		playertr = GameObject.FindWithTag("Player").GetComponent<Transform>();

	}

	private void Update()
	{
		navMeshAgent.destination = playertr.position;
	}

	
	//�ı��Ǵ� �Լ�
	public void Destroy()
	{
		if (isDestroyed) return;
		isDestroyed = true;
		print(" vkrhl");

		Destroy(this.gameObject, 1);

		onDestroyed?.Invoke();

		//EnemyManager.Instance.OnDestroyed(this);
	}

	// ���� �� ȣ��Ǵ� �Լ�
	public void OnDie()
	{
		
		enemySpawner.CurrentEnemyCount--;
		// �ִϸ��̼� �ٲ��ֱ�
		animator.SetBool("IsDie", true);
		/*if (enemySpawner.CurrentEnemyCount == 0)
		{
			print("ȣ��");
			Instantiate(button, new Vector3(176.71f, 5.7f, 205.76f), Quaternion.identity);
		}*/

		particleObject.Play();
		EnemyDie.Play();
	}


}


