using UnityEngine;
using System.Collections;

public class TotemController : MonoBehaviour 
{
	public Transform cannonBall_Prefab;
	public Transform cannonEnd;
	public float fireRatePerSec = 1; //Number of shots per second

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("Shoot", 0.0f, fireRatePerSec);
	}
	
	public void Shoot()
	{
		Instantiate(cannonBall_Prefab, cannonEnd.position, cannonEnd.rotation);
	}
}
