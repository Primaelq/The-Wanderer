using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireCircle : MonoBehaviour
{
    private List<GenericEnemy> inRange;

    public int damages = 50;

    public bool launched = false;

    void Start ()
    {
        inRange = new List<GenericEnemy>();
    }
	
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < inRange.Count; i++)
            {
                inRange[i].health -= damages;
            }

            launched = true;
            Destroy(gameObject);
        }
        else
        {
            transform.position = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHelper>().targetPoint;
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GenericEnemy>() != null)
        {
            inRange.Add(other.gameObject.GetComponent<GenericEnemy>());
            other.gameObject.GetComponent<GenericEnemy>().inRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<GenericEnemy>() != null)
        {
            inRange.Remove(other.gameObject.GetComponent<GenericEnemy>());
            other.gameObject.GetComponent<GenericEnemy>().inRange = false;
        }
    }
}
