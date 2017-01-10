using UnityEngine;
using System.Collections;

public class BoulderScript : MonoBehaviour 
{
	GameObject Boss;

	void Start () 
	{
		Boss = GameObject.Find ("Heks");
		GetComponent<Rigidbody>().AddForce(Boss.transform.forward * 25, ForceMode.Impulse);
	}

	void Update ()
	{

	}

	void OnTriggerEnter(Collider theCollision)
	{
		
		if (theCollision.gameObject.name == "Laser") 
		{
			Destroy(gameObject);
			Boss.GetComponent<BossScript>().Health += 1;
		}

		if (theCollision.gameObject.name == "stonePrefab(Clone)")
		{
			Destroy(gameObject);
		}
	}
}
