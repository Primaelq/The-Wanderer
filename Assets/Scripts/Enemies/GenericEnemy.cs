using UnityEngine;
using System.Collections;

public class GenericEnemy : MonoBehaviour
{
    public int health = 100, damages = 5;

    public float hitDistance = 2.5f, hitSpeed = 2.0f;

    public bool movingEnemy = false;

    public GameObject indicator, healthBar, background;

    public Transform target;

    [HideInInspector]
    public bool inRange = false;

    NavMeshAgent agent;

    private float startSpeed;
    private bool attackReady = false;

    void Start ()
    {
        indicator.SetActive(false);
        healthBar.transform.position = new Vector3(background.transform.position.x, background.transform.position.y, background.transform.position.z - 0.003f);

        agent = GetComponent<NavMeshAgent>();
        startSpeed = agent.speed;
        StartCoroutine(Delay(1));
    }
	
	void Update ()
    {
        if(movingEnemy)
        {
            navigation();
        }

        GUI();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void navigation()
    {
        agent.SetDestination(target.position);

        if (agent.remainingDistance <= hitDistance && attackReady)
        {
            agent.speed = 0;
            target.GetComponent<PlayerHelper>().currentHealth -= damages;
            attackReady = false;
            StartCoroutine(Delay(hitSpeed));
        }
        else if (agent.remainingDistance <= hitDistance)
        {
            agent.speed = 0;
        }
        else
        {
            agent.speed = startSpeed;
        }
    }

    void GUI()
    {
        if (inRange)
        {
            indicator.SetActive(true);
        }
        else
        {
            indicator.SetActive(false);
        }

        healthBar.transform.localScale = new Vector3((float)health / 100, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        healthBar.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        background.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

        healthBar.transform.position = new Vector3(background.transform.position.x - ((1 - healthBar.transform.localScale.x) / 2), background.transform.position.y, background.transform.position.z - 0.003f);
    }

    IEnumerator Delay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        attackReady = true;
    }
}
