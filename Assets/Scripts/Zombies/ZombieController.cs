using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour
{

    public Transform target;
    NavMeshAgent agent;

    public float hitDistance = 1.0f;
    public int damages = 10;

	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
	void Update ()
    {
        agent.SetDestination(target.position);

        if(agent.remainingDistance <= hitDistance)
        {
            target.GetComponent<PlayerGUI>().currentHealth -= damages;
        }
	}
}
