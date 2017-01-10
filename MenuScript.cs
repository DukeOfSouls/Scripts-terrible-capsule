using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
	public Texture2D aTexture = null;
	
	private bool IsQualitySettings = false;
	private bool IsAudioSettings = false;
	private bool IsMainMenu = true;
	private bool IsOptionsMenu = false;
	private float GameVolume = 0.6f;
	private float GameFOV = 50;
	
	public Camera GameCamera;
	
	void Start()
	{
		Screen.lockCursor = false;
		GameVolume = PlayerPrefs.GetFloat("Game Volume", GameVolume);
		GameFOV = PlayerPrefs.GetFloat("Game FOV", GameFOV);
		
		if(PlayerPrefs.HasKey ("Game Volume"))
		{
			AudioListener.volume = PlayerPrefs.GetFloat("Game Volume", GameVolume);
		}else
		{
			PlayerPrefs.SetFloat("Game Volume", GameVolume);
		}
		
		if(PlayerPrefs.HasKey ("Game FOV"))
		{
			GameCamera.fieldOfView = PlayerPrefs.GetFloat("Game FOV");
			
		}
		else
		{
			PlayerPrefs.SetFloat("Game FOV", GameFOV);
		}
	}
	
	void OnGUI()
	{	
		
		GUI.contentColor = Color.white;
		
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), aTexture);
		
		MainMenu();
		OptionsMenu();
		AudioSettingsDisplay();
		QualitySettingsDisplay();
		
		if(IsOptionsMenu == true)
		{
			if(GUI.Button(new Rect(Screen.width/2-125, Screen.height /2-(-60), 200, 30), "Back"))
			{
				IsMainMenu = true;
				IsOptionsMenu = false;
				IsAudioSettings = false;
				IsQualitySettings = false;
				
				
			}
		}
	}
	
	void MainMenu()
	{
		if(IsMainMenu)
		{	
			GUI.Box (new Rect(Screen.width/2-150, Screen.height/2-95, 250f, 200f), "");
			
			if(GUI.Button (new Rect(Screen.width /2-125, Screen.height /2-80, 200, 30), "Play Game"))
			{
				Application.LoadLevel(1);
			}
			
			if(GUI.Button (new Rect(Screen.width /2-125, Screen.height /2-(-60), 200, 30), "Exit"))
			{
				Application.Quit();
			}
			
			if(GUI.Button (new Rect(Screen.width /2-125, Screen.height /2-9.5f, 200, 30), "Options"))
			{
				IsMainMenu = false;
				IsOptionsMenu = true;
			}
			
		}
	}
	
	void OptionsMenu()
	{
		if(IsOptionsMenu)
		{
			
			GUI.Box (new Rect(Screen.width/2-150, Screen.height/2-95, 250f, 200f), "");
			
			if(GUI.Button (new Rect(Screen.width /2-125, Screen.height /2-9, 200, 30), "Volume"))
			{
				IsOptionsMenu = false;
				IsQualitySettings = false;
				IsAudioSettings = true;
			}
			
			if(GUI.Button (new Rect(Screen.width /2-125, Screen.height /2-80, 200, 30), "Quality"))
			{
				IsQualitySettings = true;
				IsAudioSettings = false;
				IsOptionsMenu = false;
			}
			
			
			
			
			
		}
	}
	
	public void AudioSettingsDisplay()
	{
		if(IsAudioSettings)
		{
			
			GUI.Label(new Rect(Screen.width/2-45, Screen.height/2-80, 300f, 300f), "Volume");
			GUI.Box (new Rect(Screen.width/2-150, Screen.height/2-95, 250f, 200f), "");
			
			GameVolume = GUI.HorizontalSlider(new Rect(Screen.width / 2-125, 400, Screen.width / 2-760, 10), GameVolume, 1, 100);
			GUI.Label(new Rect(Screen.width/2-30, Screen.height/2-40, 300f, 300f), "" + (System.Math.Round(GameVolume, 2)));
			
			AudioListener.volume = GameVolume;
			
			if(GUI.Button(new Rect(Screen.width/2-125, Screen.height /2-(-60), 200, 30), "Back"))
			{
				IsMainMenu = false;
				IsOptionsMenu = true;
				IsAudioSettings = false;
				IsQualitySettings = false;
			}
			
			
			if(GUI.Button (new Rect(Screen.width /2-125, Screen.height /2-9, 200, 30), "Apply"))
			{
				PlayerPrefs.SetFloat ("Game Volume", GameVolume);
			}
			
		}
	}
	
	public void QualitySettingsDisplay()
	{
		if(IsQualitySettings)
		{
			GUI.Box (new Rect(Screen.width/2-125, Screen.height/2-110, 200, 270), "");
			
			for(int  i = 0; i < QualitySettings.names.Length; i++)
			{
				if(GUI.Button(new Rect(Screen.width / 2 - 100, 350 + i * 35, 150, 25), QualitySettings.names[i]))
				{
					
				}
			}
			
			if(GUI.Button(new Rect(Screen.width/2-125, Screen.height /2-(-110), 200, 30), "Back"))
			{
				IsMainMenu = false;
				IsOptionsMenu = true;
				IsAudioSettings = false;
				IsQualitySettings = false;
				
				
			}
		}
	}
	
	
}