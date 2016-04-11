using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour
{
    public float sensitivity = 5.0f;

    private Vector2 movement;

    private bool idle = true;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        movement.x = Input.GetAxis("Vertical") * sensitivity;
        movement.y = Input.GetAxis("Horizontal") * sensitivity;

        transform.Rotate(movement);
        
        if (movement.x != 0.0f || movement.y != 0.0f)
        {
            idle = false;
        }
        else if (idle)
        {
            transform.Rotate(Vector3.up * sensitivity / 5);
        }
	}
}
