using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public float updateFrequency = 0.1f;
    public Animator soldierAnimator;

    private float updateCounter = 0;
    private NavMeshAgent agent;


    void Start()
    {
        if (target != null)
        {
            agent = this.transform.GetComponent<NavMeshAgent>();
            target = GameObject.FindGameObjectWithTag("Target").transform;
        }
        
    }

    void Update()
    {
        if (updateCounter >= updateFrequency)
        {
            agent.SetDestination(target.position);
            updateCounter = 0;
        }
        else
        {
            updateCounter += Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Target"))
        {
            Debug.Log("Target Found!");
            soldierAnimator.SetTrigger("Idle");
        }
    }
}
