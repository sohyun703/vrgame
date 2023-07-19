using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    success suc;
    [SerializeField]
    public Text Ans;
    
    [SerializeField]
    private string Anwer = "596";

    [SerializeField]
    public ParticleSystem particle;
    [SerializeField]
    private GameObject cube;
    


    [SerializeField]
    private GameObject door;

    public void Start()
    {
        
    }

    public void Number(int number)
    {
        Ans.text += number.ToString();
        print("È£Ãß¤Ð¤©");
    }
    public void String (string str)
    {
        Ans.text = "";
    }

    public void Execute()
    {
        if(Ans.text == Anwer)
        {
            Transform tr = door.GetComponent<Transform>();
            tr.transform.position = new Vector3(183.35f, 5.094f, 204.25f);
            Instantiate(cube, new Vector3 (180.33f, 6.4f, 207.5f), Quaternion.identity);
            print("1");
            StartCoroutine("StopDoor");
            particle.Play();
        }
        else
        {
            Ans.text = "INCORECT";
        }
    }

    IEnumerator StopDoor()
    {
        yield return new WaitForSeconds(0.5f);
       
    }
}
