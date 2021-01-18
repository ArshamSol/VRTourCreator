using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]

public class drag : MonoBehaviour {
	/*private Vector3 screenPoint;
	private Vector3 offset;*/
	private Vector3 screenPoint; 
	private Vector3 offset; 
	private float _lockedYPosition; 
	//private Vector3 screenPoint;
	//private Vector3 offset;
	void OnMouseDown() {
		//screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position); // I removed this line to prevent centring 
		_lockedYPosition = screenPoint.y;
		offset = this.gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		Cursor.visible = false;




	}

	void OnMouseDrag() 
	{ 
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		curPosition.x = _lockedYPosition;
		transform.position = curPosition;
	}

	void OnMouseUp()
	{
		Cursor.visible = true;
	}


}