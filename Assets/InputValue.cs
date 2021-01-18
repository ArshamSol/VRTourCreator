using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


public class InputValue : MonoBehaviour {

	public static int number;
	public InputField v;
	// Use this for initialization
	void Start () {

		string value = v.text ;
		number = int.Parse(value);
		//number = Convert.ToInt32(value);
		PlayerPrefs.SetInt("PIN", number);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}




