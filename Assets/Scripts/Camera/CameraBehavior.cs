using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour 
{

	public Transform follow; //The transform the camera will follow
	public float maxRayDis = 8; //maximum ray distance
	public float cameraPosInRay = 0.30f; //the percantage of position of the camera from the ray 

	public Transform debugObj;

	private Vector3 startPosition; //we want the camera to relatively be at the same position from the player
	//So for now I'm just saving it's position in the beginning of the game from the player


	void Start()
	{
		startPosition = transform.position - follow.position;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		/*
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		Plane floor = new Plane(Vector3.up, transform.position);

		float rayDistance = 0.0f;
		

		if(floor.Raycast(camRay, out rayDistance))
		{
			Debug.Log("changePos");
			debugObj.position = camRay.GetPoint(rayDistance);
		}
		*/
		transform.position = follow.position + startPosition;
	}
		
}
