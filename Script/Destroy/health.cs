using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    public static bool isGameOver;
    // Start is called before the first frame update
    public int damageAmount = 10;
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private AudioSource DiePlayer;
    [SerializeField]
    private AudioSource restart;
    public AudioClip DieClip;
    public AudioClip restartClip;

    void Start()
    {

        isGameOver = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("EnemyBul"))
        {
            TakeDamage(damageAmount);
            print(123);


        }
    }



    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Transform playertr = player.GetComponent<Transform>();
            playertr.position = new Vector3(-5.68f, 14.94f,0);
            DiePlayer.Stop();
            restart.Play();
        }
        print(currentHealth);

       // healthBar.SetHealth(currentHealth);
    }

  
}
