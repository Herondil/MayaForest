using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {

	public Transform _target;

	void Init(){
	}

	// Update is called once per frame
	void Update () {
		//this.transform.LookAt(this._target);
		Vector3 targetPosition = _target.position;
		this.transform.position = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z - 20);

		if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
			Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize-1, 1);
			
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize+1, 1);
		}

	}
}