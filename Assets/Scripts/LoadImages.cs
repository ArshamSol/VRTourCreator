using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadImages : MonoBehaviour {
	public Transform prefab;
	public GameObject cam;
	 Transform temp;
	 byte[] Bytes ;
	 Texture2D TextureByte = null;
	// Use this for initialization
	void Start () {
		Vector3 pos;
		Quaternion rot;
		//
		Target.targets =new List<TargetList>();


		int temphold = 0;
		temphold = PlayerPrefs.GetInt ("count");
		for (int i = 1; i < temphold+1; i++) {
			pos.x = PlayerPrefs.GetFloat ("position x" + i);
			pos.y = PlayerPrefs.GetFloat ("position y" + i); 
			pos.z = PlayerPrefs.GetFloat ("position z" + i);

			rot.x = PlayerPrefs.GetFloat ("rotation x" + i);
			rot.y = PlayerPrefs.GetFloat ("rotation y" + i);
			rot.z = PlayerPrefs.GetFloat ("rotation z" + i);
			rot.w = PlayerPrefs.GetFloat ("rotation w" + i);

			//texture
			string pathLocal = Application.dataPath + "/Resources/Images/" + PlayerPrefs.GetInt("Imgnumber" + i) + ".JPG" ;
			/*Bytes = File.ReadAllBytes (PlayerPrefs.GetString ("texture" + i));
			TextureByte = new Texture2D (10, 10);
			TextureByte.LoadImage (Bytes);*/
			Bytes = File.ReadAllBytes (pathLocal);
			TextureByte = new Texture2D (10, 10);
			TextureByte.LoadImage (Bytes);
			int tempparent = PlayerPrefs.GetInt ("parent"+i);
			string tempname = PlayerPrefs.GetString ("targetname" + i);
			string tempnumber = PlayerPrefs.GetString("ImgName" + i);


			Target.targets.Add(new TargetList (tempparent, pos ,rot ,TextureByte,tempname, tempnumber));


		}
		temp = prefab;

		Target.targets[0].targetName = Target.targets [0].targetName.Substring (0, Target.targets [0].targetName.Length - 7);
		temp.name = Target.targets [0].targetName;
		Instantiate (temp , Target.targets[0].TargetPosition, Target.targets[0].rotation );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
