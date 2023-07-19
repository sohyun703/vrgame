using UnityEngine;

public class MovementTransform : MonoBehaviour
{

	[SerializeField]
	private float moveSpeed = 0.0f;
	[SerializeField]
	private Vector3 moveDirection = Vector3.zero;

	/// <summary>
	/// �̵� ������ �����Ǹ� �˾Ƽ� �̵��ϵ��� ��
	/// </summary>
	private void Update()
	{
		transform.position += moveDirection * moveSpeed * Time.deltaTime;
	}

	/// <summary>
	/// �ܺο��� �Ű������� �̵� ������ ����
	/// </summary>
	public void MoveTo(Vector3 direction)
	{
		moveDirection = direction;
	}
}

