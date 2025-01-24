using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xRotate = 0;
    [SerializeField] float yRotate = 0;
    [SerializeField] float zRotate = 0;
    
    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(xRotate, yRotate, zRotate); 
    }

}
