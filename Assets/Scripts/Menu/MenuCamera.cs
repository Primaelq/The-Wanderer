using UnityEngine;
using System.Collections;

public class MenuCamera : MonoBehaviour
{

    public GameObject anchor;
    public float sensitivity = 10.0f;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	    if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(anchor.transform.position, Vector3.right, sensitivity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(anchor.transform.position, Vector3.up, -sensitivity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(anchor.transform.position, Vector3.right, -sensitivity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(anchor.transform.position, Vector3.up, sensitivity * Time.deltaTime);
        }
    }
}
