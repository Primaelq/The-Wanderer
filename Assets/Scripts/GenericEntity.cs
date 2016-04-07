using UnityEngine;
using System.Collections;

public class GenericEntity : MonoBehaviour 
{
	//TODO: think about adding damage
	public float health;
	public float baseSpeed;
	public float currentSpeed;

	[HideInInspector]
	public bool canAttack = true;

	

}
