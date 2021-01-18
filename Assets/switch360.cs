using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.VR;
using System.Globalization;
using System;

public class switch360 : MonoBehaviour {

	[SerializeField] private InputField InputField;
	public static bool ifLoad = false;
	public static string username;
    
    void Start()
    {
        InputField.text = "khune2";
    }
        public void to360() {
		SceneManager.LoadScene ("Main");
		string path = Application.dataPath + "/Resources/VrSceneNames.txt" ;
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine(username +" "+ DateTime.Now );
		writer.Close();
		//textures = Resources.LoadAll ("Images/Textures" , typeof(Texture2D));

		//}


	}

    /*public void to3dscan(){
		SceneManager.LoadScene("3D Scan");
	
	}
	public void backfrom3dscan(){
		SceneManager.LoadScene("UI");

	}*/

    public void backfrom360(){
		SceneManager.LoadScene("UI");
		ifLoad = false;

	}

	public void test(){
		SceneManager.LoadScene("Main");
		//Target.ListBuilder ();
		ifLoad = true;
		//VRSettings.enabled = true;
	}

	public void UserInput()
	{
		username = InputField.text;
		// Code that uses the username variable.
		PlayerPrefs.SetString("user", username);
	}
	public void AddVrScene()
	{
		username = InputField.text;

	}

		
}
