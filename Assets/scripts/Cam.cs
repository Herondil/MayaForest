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
		this.transform.position = new Vector3(targetPosition.x, targetPosition.y +20, targetPosition.z);
	}
}