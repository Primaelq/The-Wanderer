using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    public float hitDistance = 1.0f;
    public int damages = 5;

    public float hitSpeed = 2.0f;

    private float startSpeed;
    private bool attackReady = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startSpeed = agent.speed;
        StartCoroutine(WaitBeforeStart());
    }

    void Update()
    {
        agent.SetDestination(target.position);

        if (agent.remainingDistance <= hitDistance && attackReady)
        {
            target.GetComponent<PlayerGUI>().currentHealth -= damages;
            attackReady = false;
            StartCoroutine(AttackDelay());
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

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(hitSpeed);
        attackReady = true;
    }

    IEnumerator WaitBeforeStart()
    {
        yield return new WaitForSeconds(1);
        attackReady = true;
    }
}