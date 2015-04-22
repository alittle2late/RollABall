using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour 
{
	public GameObject target;	//View target object
	Vector3 offset; 			//Position relative to our view target

	// Use this for initialization
	void Start () 
	{
		//Compute the offset relative to our target
		offset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Add offset if the target moves (camera follows)
		transform.position = target.transform.position + offset;
	}
}
