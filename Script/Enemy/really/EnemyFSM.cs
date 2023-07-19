using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using System.Collections;

public enum EnemyState { None = -1, Idle = 0, Wander, Pursuit, Attack, }
public class EnemyFSM : MonoBehaviour
{
	private NavMeshAgent navMeshAgent;
	public GameObject Target; //���� ���� ���
	public AudioSource audioSource; //���� ������ ������ ���� �Ҹ�
	public AudioClip prefabSound;


	//attack
	[SerializeField]
	private GameObject projectilePrefab;                // �߻�ü ������
	[SerializeField]
	private Transform projectileSpawnPoint;         // �߻�ü ���� ��ġ
	[SerializeField]
	private float attackRange = 3;              // ���� ���� (�� ���� �ȿ� ������ "Attack" ���·� ����)
	[SerializeField]
	private float lastAttackTime = 5; // ���� �ֱ� ���� ����
	[SerializeField]
	private float attackRate = 1;                   // ���� �ӵ�

	private Transform target1;                           // ���� ���� ��� (�÷��̾�)

	private EnemyState enemyState = EnemyState.None;    // ���� �� �ൿ
	[SerializeField]
	private UnityEvent OnAttack;

	private void Start()
	{
		Target = GameObject.FindGameObjectWithTag("Player"); //player�� �Ÿ��� ���ϱ� ����
		navMeshAgent = GetComponent<NavMeshAgent>();
		navMeshAgent.speed *= Random.Range(0.8f, 1.5f);
		StartCoroutine("Wander");
	}
		public void Setup( Transform target)
	{
		this.target1 = target;
	}

	private IEnumerator Wander()
    {
		while (true)
		{
			// "���" ������ �� �ϴ� �ൿ
			// Ÿ�ٰ��� �Ÿ��� ���� �ൿ ���� (��ȸ, �߰�, ���Ÿ� ����)
			float distance = Vector3.Distance(Target.transform.position, transform.position); //  ������ �ϱ� ���� �Ÿ� ��
			CalculateDistanceToTargetAndSelectState();

			yield return null;
		}
	}
	//Update is called once per frame
	void Update()
    {

	//	float distance = Vector3.Distance(Target.transform.position, transform.position); //  ������ �ϱ� ���� �Ÿ� ����
		//if (distance < 3)
	//	{
		//	StartCoroutine("Attack");
//
	//	}
	}


	public IEnumerator Attack()
	{
		// ������ ���� �̵��� ���ߵ��� ����
		navMeshAgent.ResetPath();

		while (true)
		{
			if (Time.time - lastAttackTime > attackRate)
			{
				// �����ֱⰡ �Ǿ�� ������ �� �ֵ��� �ϱ� ���� ���� �ð� ����
				lastAttackTime = Time.time;

				// �߻�ü ����
				GameObject clone = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
				clone.GetComponent<EnemyProjectile>().Setup(Target.GetComponent<Transform>().position);
				print("-0.1");
				audioSource.Play();


			}
			CalculateDistanceToTargetAndSelectState();

			yield return null;

		}
	}


	//�ٲٱ�
	public void ChangeState(EnemyState newState)
	{
		// ���� ������� ���¿� �ٲٷ��� �ϴ� ���°� ������ �ٲ� �ʿ䰡 ���� ������ return
		if (enemyState == newState) return;

		// ������ ������̴� ���� ����
		StopCoroutine(enemyState.ToString());
		// ���� ���� ���¸� newState�� ����
		enemyState = newState;
		// ���ο� ���� ���
		StartCoroutine(enemyState.ToString());
	}
	private void CalculateDistanceToTargetAndSelectState()
	{
		if (Target.GetComponent<Transform>() == null) return;

		// �÷��̾�(Target)�� ���� �Ÿ� ��� �� �Ÿ��� ���� �ൿ ����
		float distance = Vector3.Distance(Target.transform.position, transform.position); //  ������ �ϱ� ���� �Ÿ� ����

		if (distance <= 3)
        {
			ChangeState(EnemyState.Attack);

		}

		else if (distance > 3)
        {
			ChangeState(EnemyState.Wander);

		}
	
	}
		
	}

