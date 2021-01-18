using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class TargetList
{
	public int parent;
	public string targetName;
	public string ImageName;
	public Vector3 TargetPosition;
	public Quaternion rotation;
	public Texture2D texture;
	public TargetList(int parentNum,Vector3 Position,Quaternion rot,Texture2D textureInput, string Name,string ImgNumber)
	{
		//child = new List<int> ();
		parent = parentNum;
		TargetPosition = Position;
		rotation = rot;
		texture = textureInput;
		targetName = Name;
        ImageName = ImgNumber;
	}

}

public class Target : MonoBehaviour {
	
	public Transform prefab;
	public GameObject cam;

	// Use this for initialization
	//List<int> ImagesNumberList;
	public static List<TargetList> targets;
	public static Transform temp;
	public static byte[] Bytes ;
	public static Texture2D TextureByte = null;
    public static int count = 0;
    GameObject sphereScreen;
    public  Text TextLabel;
    string[] ImageNames=new string[500];
    public static string ImageName;
    string[] sparsed;
    string ResourcesPath;
    void Start () {
        sphereScreen = GameObject.Find("sphere");

        //targets = new TargetList[Example.number];
        targets =new List<TargetList>();
		temp = prefab;
        //ImagesNumberList = new List<int> ();
        //new
        ResourcesPath = Application.dataPath + "/Resources/Images/"+ switch360.username;
        string[] fileInfo = Directory.GetDirectories(ResourcesPath, "*", SearchOption.AllDirectories);
        var info = new DirectoryInfo(fileInfo[0]);
        var images = info.GetFiles("*.jpg");
        ImageNames[0] = images[0].FullName;
        ImageName = images[0].FullName;
        TextLabel.text = ImageName.Substring(ResourcesPath.Length + 1);
        sparsed = TextLabel.text.Split('\\');
        sparsed[1] = sparsed[1].Substring(1);
        TextLabel.text = sparsed[1].Substring(0, sparsed[1].Length - 4);
        Bytes = File.ReadAllBytes(images[0].FullName);
        TextureByte = new Texture2D(10, 10);
        TextureByte.LoadImage(Bytes);
        sphereScreen.GetComponent<Renderer>().material.mainTexture = TextureByte; //(Texture2D)textures[i];
        int k = 1;
        int j = 0;///
        for (int i = 0; i < fileInfo.Length; i++)
        {
            
            //string itemPath = item.Substring(ResourcesPath.Length + 1);
             info = new DirectoryInfo(fileInfo[i]);
             images = info.GetFiles("*.jpg");
            if (i == 0)
                j = 1;
            else
                j = 0;
            for ( ; j < images.Length; j++)
            {
                ImageNames[k] = images[j].FullName;
                k++;
              //ShowNextImage(i, j);
            }                   //UnityEngine.Object result = Resources.Load(itemPath + "\\" + resourceName, systemTypeInstance);

        }


    }
    // Update is called once per frame
 
    void Update () {
    

    }

    public void AddNewTarget()
	{
        
        count++;
		temp = prefab;
		temp.name = prefab.name + count.ToString ();
		Transform newTarget=Instantiate(temp, cam.transform.position, cam.transform.rotation) as Transform;
 
        string XX = PlayerPrefs.GetString ("user");
		Bytes = File.ReadAllBytes (ImageNames[count]);
		TextureByte = new Texture2D (10, 10);
		TextureByte.LoadImage (Bytes);
        //textures[0] = TextureByte;

        ImageName = ImageNames[count];
        TextLabel.text = ImageName.Substring(ResourcesPath.Length + 1);
        sparsed = TextLabel.text.Split('\\');
        sparsed[1] = sparsed[1].Substring(1);
        TextLabel.text = sparsed[1].Substring(0, sparsed[1].Length - 4);

        if (ChangeRoom.ChangeTexture==false)
			targets.Add(new TargetList (-1, cam.transform.position, cam.transform.rotation,TextureByte,newTarget.name, ImageNames[count]));
		else 
			targets.Add(new TargetList (ChangeRoom.Parentindex, cam.transform.position, cam.transform.rotation,TextureByte,newTarget.name, ImageNames[count]));

		//parent
		if(ChangeRoom.ChangeTexture == false)
			PlayerPrefs.SetInt ("parent" + switch360.username +count,-1);
		else
			PlayerPrefs.SetInt ("parent"+switch360.username +count,ChangeRoom.Parentindex);
		
		//name

		PlayerPrefs.SetString ("targetname" + switch360.username +count , newTarget.name);
		//position
		PlayerPrefs.SetFloat("position x" + switch360.username +count,cam.transform.position.x);
		PlayerPrefs.SetFloat("position y" + switch360.username +count,cam.transform.position.y);
		PlayerPrefs.SetFloat("position z" + switch360.username +count,cam.transform.position.z);
		//rotation
		PlayerPrefs.SetFloat("rotation x" + switch360.username +count,cam.transform.rotation.x);
		PlayerPrefs.SetFloat("rotation y" + switch360.username +count,cam.transform.rotation.y);
		PlayerPrefs.SetFloat("rotation z" + switch360.username +count,cam.transform.rotation.z);
		PlayerPrefs.SetFloat("rotation w" + switch360.username +count, cam.transform.rotation.w);
		//texture
		//add latter PlayerPrefs.SetString("texture"+switch360.username +count, path);
		PlayerPrefs.SetString("ImagePath" + switch360.username +count, ImageName);
		//
		int holder = count;
		PlayerPrefs.SetInt ("count" +switch360.username , count);

    }
	public static void ListBuilder(){
		Vector3 pos;
		Quaternion rot;
		//
		Target.targets =new List<TargetList>();


		int temphold = 0;
		temphold = PlayerPrefs.GetInt ("count"+ switch360.username );
		for (int i = 1; i < temphold+1; i++) {
			pos.x = PlayerPrefs.GetFloat ("position x" + switch360.username +i);
			pos.y = PlayerPrefs.GetFloat ("position y" + switch360.username +i); 
			pos.z = PlayerPrefs.GetFloat ("position z" + switch360.username +i);

			rot.x = PlayerPrefs.GetFloat ("rotation x" + switch360.username +i);
			rot.y = PlayerPrefs.GetFloat ("rotation y" + switch360.username +i);
			rot.z = PlayerPrefs.GetFloat ("rotation z" + switch360.username +i);
			rot.w = PlayerPrefs.GetFloat ("rotation w" + switch360.username +i);

			//texture
			string pathLocal = PlayerPrefs.GetString("ImagePath" + switch360.username + i) ;
			/*Bytes = File.ReadAllBytes (PlayerPrefs.GetString ("texture" + i));
			TextureByte = new Texture2D (10, 10);
			TextureByte.LoadImage (Bytes);*/
			Bytes = File.ReadAllBytes (pathLocal);
			TextureByte = new Texture2D (10, 10);
			TextureByte.LoadImage (Bytes);
			int tempparent = PlayerPrefs.GetInt ("parent"+switch360.username +i);
			string tempname = PlayerPrefs.GetString ("targetname"  +switch360.username + i);
			string tempnumber = PlayerPrefs.GetString("ImagePath" + switch360.username +i);


			Target.targets.Add(new TargetList (tempparent, pos ,rot ,TextureByte,tempname, tempnumber));
            int a = 0;

			}

	}
    private string ReverseText(string source)
    {
        char[] split = { '\n' };
        string[] paragraphs = source.Split(split);
        string result = "";
        foreach (string paragraph in paragraphs)
        {
            char[] output = new char[paragraph.Length];
            for (int i = 0; i < paragraph.Length; i++)
            {
                output[(output.Length - 1) - i] = paragraph[i];
            }
            result += new string(output);
            //result += "\n";
        }
        return result;
    }
}
