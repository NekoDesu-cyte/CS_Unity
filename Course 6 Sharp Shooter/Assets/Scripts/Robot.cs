using UnityEngine;
using UnityEngine.AI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent; 

    void Awake() 
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        agent.SetDestination(target.position);
    }

    void Update()
    {
        
    }
}
