
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    public float speed = 40;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioSource;
    public AudioClip audioClip;
    [SerializeField]
    private UnityEvent onRelease;

    [SerializeField]
    private UnityEvent onGrab;


    public void Fire()
    {
        GameObject spawneBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        spawneBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        audioSource.PlayOneShot(audioClip);
        Destroy(spawneBullet, 2);

    }
    public void Grab(SelectEnterEventArgs args)
    {
        var interactor = args.interactorObject;

        if (interactor is XRDirectInteractor)
        {
            onGrab?.Invoke();
        }
    }

    public void Release(SelectExitEventArgs args)
    {
        var interactor = args.interactorObject;

        if (interactor is XRDirectInteractor)
        {
            onRelease?.Invoke();
        }
    }
}
