using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using System.Collections;

public enum EnemyState { None = -1, Idle = 0, Wander, Pursuit, Attack, }
public class EnemyFSM : MonoBehaviour
{
	private NavMeshAgent navMeshAgent;
	public GameObject Target; //적의 공격 대상
	public AudioSource audioSource; //적이 공격할 때마다 내는 소리
	public AudioClip prefabSound;


	//attack
	[SerializeField]
	private GameObject projectilePrefab;                // 발사체 프리팹
	[SerializeField]
	private Transform projectileSpawnPoint;         // 발사체 생성 위치
	[SerializeField]
	private float attackRange = 3;              // 공격 범위 (이 범위 안에 들어오면 "Attack" 상태로 변경)
	[SerializeField]
	private float lastAttackTime = 5; // 공격 주기 계산용 변수
	[SerializeField]
	private float attackRate = 1;                   // 공격 속도

	private Transform target1;                           // 적의 공격 대상 (플레이어)

	private EnemyState enemyState = EnemyState.None;    // 현재 적 행동
	[SerializeField]
	private UnityEvent OnAttack;

	private void Start()
	{
		Target = GameObject.FindGameObjectWithTag("Player"); //player의 거리와 비교하기 위함
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
			// "대기" 상태일 때 하는 행동
			// 타겟과의 거리에 따라 행동 선택 (배회, 추격, 원거리 공격)
			float distance = Vector3.Distance(Target.transform.position, transform.position); //  공격을 하기 위한 거리 설
			CalculateDistanceToTargetAndSelectState();

			yield return null;
		}
	}
	//Update is called once per frame
	void Update()
    {

	//	float distance = Vector3.Distance(Target.transform.position, transform.position); //  공격을 하기 위한 거리 설정
		//if (distance < 3)
	//	{
		//	StartCoroutine("Attack");
//
	//	}
	}


	public IEnumerator Attack()
	{
		// 공격할 때는 이동을 멈추도록 설정
		navMeshAgent.ResetPath();

		while (true)
		{
			if (Time.time - lastAttackTime > attackRate)
			{
				// 공격주기가 되어야 공격할 수 있도록 하기 위해 현재 시간 저장
				lastAttackTime = Time.time;

				// 발사체 생성
				GameObject clone = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
				clone.GetComponent<EnemyProjectile>().Setup(Target.GetComponent<Transform>().position);
				print("-0.1");
				audioSource.Play();


			}
			CalculateDistanceToTargetAndSelectState();

			yield return null;

		}
	}


	//바꾸기
	public void ChangeState(EnemyState newState)
	{
		// 현재 재생중인 상태와 바꾸려고 하는 상태가 같으면 바꿀 필요가 없기 때문에 return
		if (enemyState == newState) return;

		// 이전에 재생중이던 상태 종료
		StopCoroutine(enemyState.ToString());
		// 현재 적의 상태를 newState로 설정
		enemyState = newState;
		// 새로운 상태 재생
		StartCoroutine(enemyState.ToString());
	}
	private void CalculateDistanceToTargetAndSelectState()
	{
		if (Target.GetComponent<Transform>() == null) return;

		// 플레이어(Target)와 적의 거리 계산 후 거리에 따라 행동 선택
		float distance = Vector3.Distance(Target.transform.position, transform.position); //  공격을 하기 위한 거리 설정

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

