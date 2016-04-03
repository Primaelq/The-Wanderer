using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public enum Weapon
    {
        Front,
        Around
    };

    public float rotateSpeed = 8.0f;
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float dodgeDistance = 5.0f;

    private Rigidbody playerRgb;

    private List<GenericEnemy> inRange;

    public Collider frontWeapon;
    public Collider aroundWeapon;

    public Weapon weapon;

	void Start ()
    {
        playerRgb = GetComponent<Rigidbody>();
        inRange = new List<GenericEnemy>();
	}
	
	void Update ()
    {
	    if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < inRange.Count; i++)
            {
                inRange[i].health -= 10;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.position += transform.forward * dodgeDistance;
        }

        switch (weapon)
        {
            case Weapon.Front:
                frontWeapon.enabled = true;
                aroundWeapon.enabled = false;
                break;

            case Weapon.Around:
                aroundWeapon.enabled = true;
                frontWeapon.enabled = false;
                break;
        }
	}

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        Plane floor = new Plane(Vector3.up, transform.position);

        float hitdist = 0.0f;

        if (floor.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerRgb.velocity = movement * runSpeed;
        }
        else
        {
            playerRgb.velocity = movement * walkSpeed;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GenericEnemy>() != null)
        {
            inRange.Add(other.gameObject.GetComponent<GenericEnemy>());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<GenericEnemy>() != null)
        {
            inRange.Remove(other.gameObject.GetComponent<GenericEnemy>());
        }
    }
}
