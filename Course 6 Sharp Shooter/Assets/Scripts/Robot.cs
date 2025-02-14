using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    FirstPersonController player;
    [SerializeField] Transform target;

    const string PLAYER_STRING = "Player";
    NavMeshAgent agent; 

    void Awake() 
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        
    }

    void Update()
    {
        agent.SetDestination(target.transform.position);
        
    }
     void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.SelfDestruct();
        }
    }
}
