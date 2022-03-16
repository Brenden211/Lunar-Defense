using UnityEngine.AI;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public Transform GameMaster;
    public float updateFrequency = 0.1f;
    public Animator soldierAnimator;
    public float damageTake = 2f;

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
            Destroy(gameObject);
            TakeDamage(GameMaster);
        }
    }

    void TakeDamage(Transform playerStats)
    {
        PlayerStats p = playerStats.GetComponent<PlayerStats>();

        p.PlayerTakeDamage(damageTake);
    }
}
