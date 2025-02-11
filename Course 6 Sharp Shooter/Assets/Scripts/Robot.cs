using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    FirstPersonController player;
    [SerializeField] Transform target;
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
}
