using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenLoad : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    public static bool isteleport = false;

    [SerializeField]
    private Vector3 position;

    [SerializeField]
    private AudioSource door;
    public AudioClip doorSound;

    [SerializeField]
    private AudioSource BGM;
    public AudioClip BGMCLIP;

    [SerializeField]
    private AudioSource BGM2;
    public AudioClip BGM2CLIP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (isteleport == true)
        {
            Transform tr = player.GetComponent<Transform>();
            tr.position = new Vector3(183.35f, 5.094f, 204.25f);
            isteleport = false;

        }*/
      
    }

    

    public void call()
    {
        print("123");
        Transform tr = player.GetComponent<Transform>();
        tr.position = new Vector3(154.04f, 6.2f, 178.87f);
        door.Play();
        BGM.Stop();
        BGM2.Play();
    }


}


