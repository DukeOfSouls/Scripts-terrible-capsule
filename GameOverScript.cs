using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
	public Texture2D aTexture = null;
	public Camera GameCamera;

	void OnGui()
	{
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), aTexture);
	}

	void Start()
	{
		Invoke ("Begin", 1f);
	}

	void Begin()
	{
		Application.LoadLevel(0);
	}

}
