using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float rotateSpeed = 8.0f;
    public float walkSpeed = 5.0f;
    public float dodgeDistance = 10.0f;
	public float dodgeSpeed = 10.0f;

    [HideInInspector]
    public Vector3 targetPoint;

    private Rigidbody playerRgb;

    [HideInInspector]
    public bool loadingStamina = false;

    void Start ()
    {
        playerRgb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        /*if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.position += transform.forward * dodgeDistance;
        }*/

        if(Input.GetKeyDown(KeyCode.LeftShift) && transform.GetComponent<PlayerGUI>().staminaReady)
        {
            loadingStamina = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && transform.GetComponent<PlayerGUI>().staminaReady)
        {
            //transform.position += transform.forward * (dodgeDistance * (transform.GetComponent<PlayerGUI>().startStamina - transform.GetComponent<PlayerGUI>().currentStamina));

            loadingStamina = false;
        }
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        Plane floor = new Plane(Vector3.up, transform.position);

        float hitdist = 0.0f;

        if (floor.Raycast(ray, out hitdist))
        {
            targetPoint = ray.GetPoint(hitdist);
            
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        
		if(loadingStamina && transform.GetComponent<PlayerGUI>().currentStamina > 	0)
		{
       		playerRgb.velocity = movement * dodgeSpeed;
		}
		else
		{
			playerRgb.velocity = movement * walkSpeed;
		}

    }
}
