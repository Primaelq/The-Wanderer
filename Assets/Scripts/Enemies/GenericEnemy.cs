using UnityEngine;
using System.Collections;

public class GenericEnemy : MonoBehaviour
{

    public int health = 100;

	void Start ()
    {

	}
	
	void Update ()
    {
	    if(health <= 0)
        {
            Destroy(gameObject);
        }
	}
}
