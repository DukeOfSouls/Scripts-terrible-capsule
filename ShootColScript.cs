using UnityEngine;
using System.Collections;

public class ShootColScript : MonoBehaviour {

	public GameObject stoneHit;

	void Start () 
	{
		stoneHit = GameObject.Find("GretelCamera");
	}

	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider col)
	{
		Destroy(gameObject);
		stoneHit.GetComponent<ShootScript>().hit = true;
	}
}
