using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour 
{

	public Transform follow; //The transform the camera will follow
	public float maxCamDisFromPlayer = 8; //maximum ray distance from player in radius
	[Range(0.0f, 1f)]
	public float cameraPosInRay = 0.30f; //the percantage of position of the camera from the ray 

	public float cameraLerpTime = 0.1f;

	private Vector3 startPosition; //we want the camera to relatively be at the same position from the player
	//So for now I'm just saving it's position in the beginning of the game from the player

	private Vector3 lastChangePosition;

	void Start()
	{
		startPosition = transform.position - follow.position;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		Plane floor = new Plane(Vector3.up, follow.position);

		float hitdist = 0.0f;

		if (floor.Raycast(ray, out hitdist))
		{
			Vector3 targetPoint = ray.GetPoint(hitdist);
			if(Vector3.Distance(follow.position, targetPoint) > maxCamDisFromPlayer)
			{
				targetPoint = (targetPoint - follow.position).normalized * maxCamDisFromPlayer;
			}
			Debug.DrawRay(follow.position, targetPoint);
			lastChangePosition = (targetPoint-follow.position) * cameraPosInRay + follow.position;
		}
	}

	void LateUpdate()
	{
		transform.position = Vector3.Lerp(transform.position,(lastChangePosition + startPosition), cameraLerpTime);
	}
		
}
