using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour 
{

	public float destroyTime = 5.0f; //time from launch until the projectile is destroyed (in seconds)
	public int damage = 5;
	public int speed = 3;
	//David's note: this system is sort of stupid in the sense that it abuses garbage collection and an object-pooling
	//system would be better, however I decided to use this for prototyping

	void Start()
	{
		Destroy(gameObject, destroyTime);
	}

	void Update()
	{
		transform.Translate(Vector3.forward*speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			other.transform.GetComponent<PlayerHelper>().currentHealth -= damage;
		}
		Destroy(gameObject);
	}
}
