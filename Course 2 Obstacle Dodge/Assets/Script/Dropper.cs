using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float timeDelay = 2f;
    
    MeshRenderer myMeshRenderer;
    Rigidbody myRigidBody;
   
    void Start()
    {
        myMeshRenderer = GetComponent<MeshRenderer>();
        myRigidBody = GetComponent<Rigidbody>();

        myMeshRenderer.enabled = false;
        myRigidBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeDelay)
        {
            myMeshRenderer.enabled = true;
            myRigidBody.useGravity = true;
        }
        
    }
}
