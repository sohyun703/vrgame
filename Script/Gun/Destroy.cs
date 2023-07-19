using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroy : MonoBehaviour
{
	public void OnTriggerEnter(Collider other)

	{

		if (other.gameObject.tag.Equals("Enemy"))

		{
			other.GetComponent<Enemy>().OnDie();
			Destroy(this.gameObject);

		}


	}



}