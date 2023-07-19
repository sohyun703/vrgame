using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    [SerializeField]
    private float minPitch = 0.8f;
    [SerializeField]
    private float maxPitch = 1.2f;
    [SerializeField]
    private AudioSource target;
    [SerializeField]
    private AudioClip clip;

    private void Awake()
    {
        target = GetComponent<AudioSource>();
    }

    public void Call()
    {
        target.Play();
    }
}

