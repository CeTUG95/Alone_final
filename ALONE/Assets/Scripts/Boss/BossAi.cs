using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAi : MonoBehaviour
{
	private Transform target;
    NavMeshAgent navMeshAgent;
	private float distanceToTarget = Mathf.Infinity;
	private bool isProvoked = false;
	BossHealth health;
    [SerializeField] float range;
    //
    private AudioSource source;
    [SerializeField] AudioClip clip;

    void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		health = GetComponent<BossHealth>();
        target = GameObject.Find("Player").transform;

        source = GetComponent<AudioSource>();
    }

	void Update()
	{
		if (health.IsDead())
		{
			enabled = false;
			navMeshAgent.enabled = false;
		}

		distanceToTarget = Vector3.Distance(target.position, transform.position);

		if (isProvoked)
		{
			EngageTarget();
		}

        else if (distanceToTarget <= range)
        {
            isProvoked = true;
            source.Play();
        }
    }

	public void OnDamageTaken()
	{
		isProvoked = true;
	}

	public void EngageTarget()
	{
		FaceTarget();

		if (distanceToTarget >= navMeshAgent.stoppingDistance)
		{
			ChaseTarget();
		}

		if (distanceToTarget <= navMeshAgent.stoppingDistance)
		{
			AttackTarget();
		}
	}

	private void ChaseTarget()
	{
		GetComponent<Animator>().SetBool("attack", false);
		GetComponent<Animator>().SetTrigger("move");
		navMeshAgent.SetDestination(target.position);
	}

	private void AttackTarget()
	{
		GetComponent<Animator>().SetBool("attack", true);
	}

	private void FaceTarget()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public bool GetIsProvoked()
    {
        return isProvoked;
    }
}
