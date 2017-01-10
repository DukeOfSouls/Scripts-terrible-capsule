using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootScript : MonoBehaviour 
{
	public Texture2D aTexture;
	
	public Rigidbody stone;
	public Transform origine;
	public float Force;
	private float Charge = 0f;
	private float ChargeLimit = 1500f;
	private float MinChargeLimit = 500f;
	public bool hit = true;
	public GameObject ChargeText;
	private Text ChargeTextField;
	public GameObject ChargeBar;
	
	void Start () 
	{
		ChargeTextField = ChargeText.GetComponent<Text>();
		ChargeBar = GameObject.Find ("ChargeBar");
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(Screen.width/2-50, Screen.height/2-50, 50, 50), aTexture);
	}
	
	void Update () 
	{
		if(Input.GetMouseButton(0) && Charge < ChargeLimit && hit == true)
		{
			Charge += Time.deltaTime * Force;
			ChargeBar.GetComponent<Image>().fillAmount = Charge * 0.000666f;
			if (Charge > ChargeLimit) Charge = ChargeLimit;
		}
		
		if(Input.GetMouseButtonUp(0) && Charge > MinChargeLimit && hit == true)
		{
			Rigidbody instance;
			instance = Instantiate(stone, origine.position + origine.transform.forward * 1.5f, origine.rotation) as Rigidbody;
			instance.AddForce(origine.transform.forward * Charge * 1.5f);
			Charge = 0f;
			ChargeBar.GetComponent<Image>().fillAmount = 0;
		}

		if(Input.GetMouseButtonUp(0))
		{
			Charge = 0f;
		}

		updateChargerField();
	}

	void updateChargerField() 
	{
		if (Charge < MinChargeLimit) 
		{
			ChargeTextField.color = Color.red;
		} 
		else 
		{
			ChargeTextField.color = Color.green;
		}

		ChargeTextField.text = Mathf.Round(Charge).ToString();
	}
}