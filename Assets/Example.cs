using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class Example : MonoBehaviour
{
	public InputField mainInputField;
	public InputField FirstImageNum;
	public InputField ImageNum;
	public static string value;
	public static int number;
	public static int FirstImgnumber;
	//public static int Imgnumber;
	public static int BackCount;
	public static bool ImageNumFlag=false;
	GameObject sphereScreen;
	public static int TempBackIndex=0;
	//int TempChangeRoomBackindex=0;
	public void Start()
	{
		BackCount = 0;

		sphereScreen = GameObject.Find ("sphere");
		//Adds a listener to the main input field and invokes a method when the value changes.
//		mainInputField.onValueChange.AddListener(delegate {ValueChangeCheck(); });
//		FirstImageNum.onValueChange.AddListener(delegate {FirstImageInput(); });
//		ImageNum.onValueChanged.AddListener(delegate {ImageNumber(); });

	}

	// Invoked when the value of the text field changes.
	public void ValueChangeCheck()
	{
		value = mainInputField.text;
		number = int.Parse (value);
		PlayerPrefs.SetInt("PIN", number);
	}
	public void FirstImageInput()
	{
		//value = ;
		FirstImgnumber = int.Parse (FirstImageNum.text);
	}
	//public void ImageNumber()
	//{
	//	try{Imgnumber = int.Parse (ImageNum.text);
	//	}
	//	catch(System.FormatException e){
	//		Debug.Log ("Enter a valid Number of images");
	//	}

	//	ImageNumFlag = true;
	//}
	/*public void BackTarget()
	{
		//BackCount ++;
		TempBackIndex=Target.targets [ChangeRoom.Parentindex].parent;
		if (TempBackIndex != -1) {
			for (int i = 0; i < Target.targets.Count; i++) {
				Destroy (GameObject.Find (Target.targets [i].targetName));
			}
		}
			//if (BackCount == 1) {

		sphereScreen.GetComponent<Renderer> ().material.mainTexture = Target.targets [TempBackIndex].texture;
			for (int m = 0; m < Target.targets.Count; m++) {
				if (Target.targets [m].parent == TempBackIndex)
					Instantiate (Target.temp, Target.targets [m].TargetPosition, Target.targets [m].rotation);				
			}	 

			//}

	}*/

}