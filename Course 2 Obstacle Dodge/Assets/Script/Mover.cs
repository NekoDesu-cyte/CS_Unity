using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PrintInstruction();
        
    }

    // Update is called once per frame
    void Update()
    {
       MovePlayer();
    }

    void PrintInstruction()
    {
        Debug.Log("Welcome to the Game!");
        Debug.Log("Move with your Arrow Keys or WASD");
        Debug.Log("Don't bump into any Objects!");
    }
    
    void MovePlayer()
    {
         
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yValue = 0f;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, yValue, zValue);
    }
}
