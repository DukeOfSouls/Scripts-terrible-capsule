using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossScript : MonoBehaviour 
{
	Vector3 rotateY = new Vector3 (0f, 1f, 0f);

	public int Health = 100;

	public Transform GretelTrans;
	public Rigidbody Boulder;
	public GameObject HealthBar;

	GameObject Laser;
	GameObject LaserWarning;

	void StartLaser ()
	{
		StartCoroutine("LaserSwipe");
	}

	void StartBoulder ()
	{
		StartCoroutine("BoulderThrow");
	}

	void Start ()
	{
		Laser = GameObject.Find ("LaserPivot");
		LaserWarning = GameObject.Find ("LaserWarning");
		HealthBar = GameObject.Find ("BossHealthBar");
		transform.LookAt(GretelTrans);
		Invoke ("StartLaser", 5f);
		Invoke ("StartBoulder", 2f);
		Laser.SetActive (false);
		LaserWarning.SetActive (false);
	}

	IEnumerator BoulderThrow() 
	{
		Rigidbody BoulderShot;
		BoulderShot = Instantiate (Boulder, transform.position + (transform.forward * 4) + (transform.up * 5), transform.rotation) as Rigidbody;
		
		yield return new WaitForSeconds(2f);
		StartCoroutine("BoulderThrow");
	}

	IEnumerator LaserSwipe() 
	{
		LaserWarning.SetActive (true);
		Laser.SetActive (true);

		for (int i=0; i<185; i++) 
		{
			Laser.transform.eulerAngles += rotateY;
			yield return new WaitForSeconds(0.01f);
		}

		Laser.SetActive (false);
		LaserWarning.SetActive (false);
		Laser.transform.eulerAngles = new Vector3 (356.87f, 270f, 0f);
		yield return new WaitForSeconds(5);
		StartCoroutine("LaserSwipe");
	}

	void Update () 
	{
		transform.LookAt(GretelTrans);
		HealthBar.GetComponent<Image>().fillAmount = Health * 0.01f;
		Debug.Log ("Boss health is: " + Health);

		if (Health > 100) {
			Health = 100;
		}

		if (Health < 0){
			Application.LoadLevel(3);
		}
	}

	void OnTriggerEnter(Collider theCollision)
	{
		if (theCollision.gameObject.name == "stonePrefab(Clone)") 
		{
			Health -= 10;
		}
	}
}