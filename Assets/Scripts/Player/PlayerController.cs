using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private PlayerHelper helper;

    private Rigidbody playerRgb;

    void Start ()
    {
        helper = GetComponent<PlayerHelper>();

        playerRgb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && helper.staminaReady)
        {
            helper.loadingStamina = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && helper.staminaReady)
        {
            helper.loadingStamina = false;
        }
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        Plane floor = new Plane(Vector3.up, transform.position);

        float hitdist = 0.0f;

        if (floor.Raycast(ray, out hitdist))
        {
            helper.targetPoint = ray.GetPoint(hitdist);
            
            Quaternion targetRotation = Quaternion.LookRotation(helper.targetPoint - transform.position);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, helper.rotateSpeed * Time.deltaTime);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        
		if(helper.loadingStamina && helper.currentStamina > 0)
		{
       		playerRgb.velocity = movement * helper.dodgeSpeed;
		}
		else
		{
			playerRgb.velocity = movement * helper.walkSpeed;
		}

    }
}
