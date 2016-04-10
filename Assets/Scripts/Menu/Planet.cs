using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{
    public float sensitivity = 0.5f;

    private Vector2 dragStart;
    private Vector2 rotation;

    private float x;
    private float y;

    private GameObject anchor;
    
	void Start ()
    {
        anchor = new GameObject();
        anchor.transform.position = Vector3.zero;
        anchor.transform.rotation = Quaternion.Euler(Vector3.zero);
	}
	
	void Update ()
    {

        if (Input.GetMouseButtonDown(0))
        {
            dragStart = Input.mousePosition;

            x = transform.rotation.eulerAngles.x;
            y = transform.rotation.eulerAngles.y;
        }

	    if(Input.GetMouseButton(0))
        {
            rotation.x = (Input.mousePosition.y - dragStart.y) * sensitivity + x;
            rotation.y = -(Input.mousePosition.x - dragStart.x) * sensitivity + y;

            transform.rotation = Quaternion.Euler(rotation.x, rotation.y, transform.rotation.z);
        }
	}
}
