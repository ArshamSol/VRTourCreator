using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine.UI;

[RequireComponent(typeof(SphereCollider))]


public class ChangeRoom : MonoBehaviour {
	private List<Texture2D> textureSphere;
	public static int Parentindex = 0;
	//public static int BackIndex = 0;
	bool inSight = false;
	bool isChanging = false;
    public static bool ChangeTexture =false;
	float count = 0;
	float countLerp = 0;
	Animator reticleAnimator; 
	BlackScreen blkScreen;
	GameObject sphereScreen;
    GameObject txtLabel;
    private Color color = new Color(0,0,0,0);
	private int i = 1;
	private UnityEngine.Object[] textures;
	//private Texture2D textures;
	byte[] Bytes ;
	Texture2D TextureByte = null;
    



	void Start() {
		reticleAnimator = GameObject.Find ("Reticle").GetComponentInChildren<Animator> ();
		blkScreen = GameObject.Find ("BlackScreen").GetComponent<BlackScreen>();
		sphereScreen = GameObject.Find ("sphere");
		//initial texture

		//texture read
	//	int y =InputValue.number;
		int x= PlayerPrefs.GetInt("PIN");
		textures = new UnityEngine.Object[x];


		string pathLocal = Application.dataPath + "/Resources/Images/" + Example.FirstImgnumber + ".JPG" ;
			Bytes = File.ReadAllBytes (pathLocal);
			TextureByte = new Texture2D (10, 10);
			TextureByte.LoadImage (Bytes);
		//sphereScreen.GetComponent<Renderer>().material.mainTexture = TextureByte;
	
		 //= (Texture2D)textures[0];	
         

	}
	//**** Increase the circle size when you look at it ****\\
	public void IncreaseChildSize(){
		if (switch360.ifLoad) {
			reticleAnimator = GameObject.Find ("Reticle").GetComponentInChildren<Animator> ();
			blkScreen = GameObject.Find ("BlackScreen").GetComponent<BlackScreen> ();
			sphereScreen = GameObject.Find ("sphere");

		}
			if (!isChanging) {
				if (transform.GetChild (0).localScale.x <= 0.9f) {
					transform.GetChild (0).localScale += new Vector3 (.5f * Time.deltaTime, .5f * Time.deltaTime, .5f * Time.deltaTime);
					reticleAnimator.SetBool ("LookSomething", true);
				} else {
					StartCoroutine (FadeChangeRoom ());
					reticleAnimator.SetBool ("LookSomething", false);
				}
				count = 0.5f;
			}
		} 

	//**** And decrease it when you're not looking at it ****\\
	void DecreaseChildSize(){
		
		reticleAnimator.SetBool ("LookSomething", false);
		if(transform.GetChild(0).localScale.x > 0)
			transform.GetChild(0).localScale -= new Vector3(2*Time.deltaTime,2*Time.deltaTime,2*Time.deltaTime);
	
	}

	void Update(){

		if (count>0){
			count -= Time.deltaTime;
			inSight = true;
		} else inSight = false;

		if(!inSight){
			DecreaseChildSize();
		}


	}
	IEnumerator FadeChangeRoom (){
		
		if (!switch360.ifLoad) {
			isChanging = true;
			transform.GetChild (0).localScale = new Vector3 (0, 0, 0);
			//StartCoroutine(blkScreen.FadeOut(0.5f));
			yield return new WaitForSeconds (0.5f);
			for (int j = 0; j < Target.targets.Count; j++) {
				if (CamVision.HitName == Target.targets [j].targetName) {
					Parentindex = j;
					break;
				}
			}
			sphereScreen.GetComponent<Renderer> ().material.mainTexture = Target.targets [Parentindex].texture; //(Texture2D)textures[i];
            

            ChangeTexture = true;
			isChanging = false;		
			//StartCoroutine(blkScreen.FadeIn(0.5f));
			for (int i = 0; i < Target.targets.Count; i++) {
                GameObject finded=GameObject.Find(Target.targets[i].targetName);

                Destroy (finded);
			}
			for (int m = 0; m < Target.targets.Count; m++) {
				if (Example.ImageNumFlag) {
					Example.ImageNumFlag = false;
					if (Target.targets [m].ImageName == Target.ImageName) {
						for (int j = 0; j < Target.targets.Count; j++) {
							if (Target.targets [j].parent == m) {
								Target.temp.name = Target.targets [j].targetName.Substring (0, Target.targets [j].targetName.Length - 7);
								// "(Clone)";
								Instantiate (Target.temp, Target.targets [j].TargetPosition, Target.targets [j].rotation);
							}
						}
					}
				} else {				
					
					if (Target.targets [m].ImageName == Target.targets [Parentindex].ImageName) {
						for (int j = 0; j < Target.targets.Count; j++) {
							if (Target.targets [j].parent == m) {
								Target.temp.name = Target.targets [j].targetName.Substring (0, Target.targets [j].targetName.Length - 7);
								// "(Clone)";
								Instantiate (Target.temp, Target.targets [j].TargetPosition, Target.targets [j].rotation);
							}
						}
					}
					
													
				}
			}

		} else {
            txtLabel = GameObject.FindGameObjectWithTag("TxtTag");
          
            isChanging = true;
			transform.GetChild (0).localScale = new Vector3 (0, 0, 0);
			//StartCoroutine(blkScreen.FadeOut(0.5f));
			yield return new WaitForSeconds (0.5f);
			for (int j = 0; j < Target.targets.Count; j++) {
				if (CamVision.HitName == Target.targets [j].targetName) {
					Parentindex = j;
					break;
				}
			}
			sphereScreen.GetComponent<Renderer> ().material.mainTexture = Target.targets [Parentindex].texture; //(Texture2D)textures[i];
            string ResourcesPath = Application.dataPath + "/Resources/Images/" + switch360.username;
            string ImgName = Target.targets[Parentindex].ImageName;
            string[] sparsed = ImgName.Substring(ResourcesPath.Length + 1).Split('\\');
           
            sparsed[1] = sparsed[1].Substring(1);
            txtLabel.GetComponent<Text>().text  = sparsed[1].Substring(0, sparsed[1].Length - 4);
            
            ChangeTexture = true;
			isChanging = false;		
			//StartCoroutine(blkScreen.FadeIn(0.5f));
			for (int i = 0; i < Target.targets.Count; i++) {
				Destroy (GameObject.Find (Target.targets [i].targetName));
			}
			for (int m = 0; m < Target.targets.Count; m++){
				if (Target.targets [m].ImageName == Target.targets [Parentindex].ImageName) {
					for (int j = 0; j < Target.targets.Count; j++) {
						if (Target.targets[j].parent == m) {
							Loader.temp.name = Target.targets [j].targetName.Substring (0, Target.targets [j].targetName.Length - 7);
							Instantiate (Loader.temp, Target.targets [j].TargetPosition, Target.targets [j].rotation);
						}
					}
				}
		}
		
			
		}


			yield return null;
		
	}

}

	

