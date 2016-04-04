using UnityEngine;
using System.Collections;

public class GenericEnemy : MonoBehaviour
{
    public int health = 100;
    public GameObject indicator;

    [HideInInspector]
    public bool inRange = false;

	void Start ()
    {
        indicator.SetActive(false);
	}
	
	void Update ()
    {
	    if(health <= 0)
        {
            Destroy(gameObject);
        }

        if(inRange)
        {
            indicator.SetActive(true);
        }
        else
        {
            indicator.SetActive(false);
        }
	}
}
