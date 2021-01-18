using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Loader : MonoBehaviour {

	public GameObject xx;

	public Transform prefab;
	public static Transform temp ;

	// Use this for initialization
	void Start () {
		
		temp = prefab;
		if (switch360.ifLoad) {
			UnityEngine.XR.XRSettings.enabled = true;
			Target.ListBuilder ();
			xx = GameObject.Find ("Button");
			
			xx.SetActive (false);
            for (int i = 0; i < Target.targets.Count; i++)
            {
                if (Target.targets[i].parent == -1)
                {
                    temp.name = Target.targets[i].targetName.Substring(0, Target.targets[i].targetName.Length - 7);
                    Instantiate(temp, Target.targets[i].TargetPosition, Target.targets[i].rotation);
                }
                
            }
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
