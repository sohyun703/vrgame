using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy2 : MonoBehaviour
{
	[SerializeField]
	private Animator animator;
	private TowEnemySpawner enemySpawner2;
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

	public void Setup(TowEnemySpawner TowEnemySpawner)
	{
		this.enemySpawner2 = TowEnemySpawner;
	}

	private void Start()
	{
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

	public void Destroy()
	{
		if (isDestroyed) return;
		isDestroyed = true;
		print(" vkrhl");

		Destroy(this.gameObject, 1);

		onDestroyed?.Invoke();

		//EnemyManager.Instance.OnDestroyed(this);
	}

	public void OnDie()
	{
		enemySpawner2.currentEnemyCount--;
		// 애니메이션 바꿔주기
		animator.SetBool("IsDie", true);
		if (enemySpawner2.currentEnemyCount == 0)
		{
			print("호출");
			Instantiate(button, new Vector3(176.71f, 5.7f, 205.76f), Quaternion.identity);
		}

	}
}
