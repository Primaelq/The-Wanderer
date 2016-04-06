using UnityEngine;
using System.Collections;

public class TotemController : MonoBehaviour 
{
	public GameObject bullet;
	public float fireRatePerSec = 1; //Number of shots per second
    public float scope = 8.0f;
    public int damages = 5;

	void Start () 
	{
		InvokeRepeating("Shoot", 0.0f, fireRatePerSec);
	}
	
	public void Shoot()
    {
        StartCoroutine(Delay(0.1f));

        RaycastHit hit;

        if(Physics.Raycast(transform.position, -transform.forward, out hit) && hit.transform.tag == "Player" && hit.distance <= scope)
        {
            hit.transform.GetComponent<PlayerHelper>().currentHealth -= damages;
        }
	}

    IEnumerator Delay(float waitTime)
    {
        var em = bullet.GetComponent<ParticleSystem>().emission;

        em.enabled = true;
        yield return new WaitForSeconds(waitTime);
        em.enabled = false;
    }
}
