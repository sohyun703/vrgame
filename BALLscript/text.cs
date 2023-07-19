using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class text : MonoBehaviour
{
    public int totalItemcount;
    public int stage;
    public Text stagecountText;
    public Text playerCountText;
    // Start is called before the first frame update
    void Awake()
    {
        stagecountText.text = "/ 26 " ;
    }
    public void GetITem(int count)
    {
        playerCountText.text = count.ToString();
    }

}

