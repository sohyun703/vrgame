using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayHapticOnInteractable : MonoBehaviour
{
	[SerializeField]
	private float amplitude = 0.5f;
	[SerializeField]
	private float duration = 0.05f;
	private XRBaseInteractable target;

	private void Awake()
	{
		target = GetComponent<XRBaseInteractable>();
	}

	public void Call()
	{
		if (target == null) return;
		if (target.firstInteractorSelecting == null) return;
		if (!(target.firstInteractorSelecting is XRBaseControllerInteractor)) return;

		XRBaseControllerInteractor interactor = target.firstInteractorSelecting as XRBaseControllerInteractor;
		if (interactor.xrController == null)
		{
			return;
		}

		interactor.xrController.SendHapticImpulse(amplitude, duration);
	}
}

