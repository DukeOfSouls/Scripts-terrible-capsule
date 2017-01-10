using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public Vector3 Forward = new Vector3 (0f, 0f, 0f);
	public Vector3 Right = new Vector3 (0f, 0f, 0f);
	public Vector3 Left = new Vector3 (0f, 0f, 0f);
	public Vector3 Back = new Vector3 (0f, 0f, 0f);
	Vector3 rotateY = new Vector3 (0f, 1f, 0f);

	bool RollCD = false;
	bool Alive = true;
	int Stamina = 100;

	private Text StaminaTextField;
	private GameObject CamMove;
	public GameObject StaminaText;
	public GameObject StaminaBar;
	
	void Start () 
	{
		StaminaTextField = StaminaText.GetComponent<Text>();
		StaminaBar = GameObject.Find ("StaminaBar");
		CamMove = GameObject.Find ("GretelCamera");
		transform.eulerAngles = new Vector3 (0f, 0f, 0f);
		this.Forward = (CamMove.transform.forward * 20);
		this.Right = (CamMove.transform.right * 15);
		this.Left = (CamMove.transform.right * -15);
		this.Back = (CamMove.transform.forward * -20);
		StartCoroutine ("StaminaRegen");
	}

	IEnumerator StaminaRegen() 
	{
		if (Stamina < 100) 
		{
			Stamina += 1;
			StaminaBar.GetComponent<Image>().fillAmount = Stamina * 0.01f;
		}

		yield return new WaitForSeconds (0.1f);
		StartCoroutine ("StaminaRegen");
	}

	void RollReset () 
	{
		RollCD = false;
	}

	void Update () 
	{
		if (Stamina < 50) 
		{
			StaminaBar.GetComponent<Image>().color = Color.yellow;
		}

		if (Stamina > 50) 
		{
			StaminaBar.GetComponent<Image>().color = Color.green;
		}

		if (Input.GetKeyDown ("space") && Input.GetKey ("d") && Stamina >= 50 && RollCD == false) 
		{
			RollCD = true;
			Stamina -= 50;
			GetComponent<Rigidbody>().AddForce(Right * 1.5f, ForceMode.Impulse);
			Invoke("RollReset", 0.3f);
		}

		if (Input.GetKeyDown ("space") && Input.GetKey ("a") && Stamina >= 50 && RollCD == false) 
		{
			RollCD = true;
			Stamina -= 50;
			GetComponent<Rigidbody>().AddForce(Left * 1.5f, ForceMode.Impulse);
			Invoke("RollReset", 0.3f);
		}

		if (Input.GetKeyDown ("space") && Input.GetKey ("s") && Stamina >= 50 && RollCD == false) 
		{
			RollCD = true;
			Stamina -= 50;
			GetComponent<Rigidbody>().AddForce(Back * 1.5f, ForceMode.Impulse);
			Invoke("RollReset", 0.3f);
		}

		if (Input.GetKeyDown ("space") && Input.GetKey ("w") && Stamina >= 50 && RollCD == false) 
		{
			RollCD = true;
			Stamina -= 50;
			GetComponent<Rigidbody>().AddForce(Forward * 1.5f, ForceMode.Impulse);
			Invoke("RollReset", 0.3f);
		}

		this.Forward = (CamMove.transform.forward * 18);
		this.Right = (CamMove.transform.right * 14);
		this.Left = (CamMove.transform.right * -14);
		this.Back = (CamMove.transform.forward * -18);

		if (Input.GetKey ("w") && RollCD == false) 
		{
			GetComponent<Rigidbody>().AddForce(Forward);
		}
		
		if (Input.GetKey ("a") && RollCD == false) 
		{
			GetComponent<Rigidbody>().AddForce(Left);
		}
		
		if (Input.GetKey ("s") && RollCD == false) 
		{
			GetComponent<Rigidbody>().AddForce(Back);
		}
		
		if (Input.GetKey ("d") && RollCD == false) 
		{
			GetComponent<Rigidbody>().AddForce(Right);
		}

		updateStaminaField();
	}

	void updateStaminaField()
	{
		if (Stamina < 50f)
		{
			StaminaTextField.color = Color.gray;
		}
		else
		{
			StaminaTextField.color = Color.black;
		}

		StaminaTextField.text = Mathf.Round(Stamina).ToString();
	}

		

	void OnTriggerEnter(Collider theCollision)
	{

		if (theCollision.gameObject.name == "Boulder(Clone)") 
		{
			Application.LoadLevel("GameOver");
			Alive = false;
		}
		if (theCollision.gameObject.name == "Laser") 
		{
			Application.LoadLevel("GameOver");
			Alive = false;
		}
	}
}
