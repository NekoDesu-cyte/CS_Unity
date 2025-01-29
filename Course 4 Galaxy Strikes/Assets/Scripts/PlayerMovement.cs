using System;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float XClampRange = 35f;
    [SerializeField] float YClampRange = 35f;

    [SerializeField] float controlRollFactor = 20f; 
    [SerializeField] float controlPitchFactor = 0;
    [SerializeField] float rotationSpeed = 10f;
    Vector2 movement;
    void Start()
    {
        
    }

    
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }


    public void OnMove(InputValue value) 
    {
        movement = (value.Get<Vector2>());
    }

    void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Math.Clamp(rawXPos, -XClampRange, XClampRange);
        
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Math.Clamp(rawYPos, -YClampRange, YClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
    void ProcessRotation()
    {
        float Roll = -controlRollFactor * movement.x;
        float Pitch = -controlPitchFactor * movement.y;
        Quaternion targetRotation = Quaternion.Euler(Pitch, 0f, Roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}