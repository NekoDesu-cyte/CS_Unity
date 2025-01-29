using System.Xml.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    void Start()
    {
        
    }

    
    void Update()
    {
        float xOffset = controlSpeed * Time.deltaTime;
        transform.localPosition = new Vector3(transform.localPosition.x + xOffset, 0f, 0f);
    }

    public void OnMove(InputValue value) 
    {
        Debug.Log(value.Get<Vector2>());
    }
}
