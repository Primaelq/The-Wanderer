using UnityEngine;
using System.Collections;

public class GenericEnemy : MonoBehaviour
{
    public int health = 100;
    public GameObject indicator;
    public GameObject healthBar;
    public GameObject background;

    [HideInInspector]
    public bool inRange = false;

	void Start ()
    {
        indicator.SetActive(false);
        healthBar.transform.position = new Vector3(background.transform.position.x, background.transform.position.y, background.transform.position.z - 0.0001f);
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

        healthBar.transform.localScale = new Vector3( (float) health / 100, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        healthBar.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        background.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

        healthBar.transform.position = new Vector3(background.transform.position.x - ((1 - healthBar.transform.localScale.x) / 2), background.transform.position.y, background.transform.position.z - 0.0001f);
    }
}
