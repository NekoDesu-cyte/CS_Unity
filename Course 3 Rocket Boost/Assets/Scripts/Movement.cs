using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrenght = 1000f;
    [SerializeField] float rotationStrenght = 100f;
    [SerializeField] AudioClip MainEngineSFX;
    [SerializeField] ParticleSystem MainEngineParticles;
    [SerializeField] ParticleSystem RightThrusterParticles;
    [SerializeField] ParticleSystem LeftThrusterParticles;
    Rigidbody rb;
    AudioSource audioSource;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    private void OnEnable() 
    {
        thrust.Enable();
        rotation.Enable();
    }
    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrenght * Time.fixedDeltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(MainEngineSFX);
            }
            if (!MainEngineParticles.isPlaying)
            {
                MainEngineParticles.Play();
            }
        }
        else
        {
            audioSource.Stop();
            MainEngineParticles.Stop();
        }
    }
    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0)
        {
            ApplyRotation(rotationStrenght);
            if (!LeftThrusterParticles.isPlaying)
            {
                RightThrusterParticles.Stop();
                LeftThrusterParticles.Play();
            }
        }
        
        else if (rotationInput > 0)
        {
            ApplyRotation(-rotationStrenght);
            if (!RightThrusterParticles.isPlaying)
            {
                LeftThrusterParticles.Stop();
                RightThrusterParticles.Play();
            }
        }
        else
        {
            RightThrusterParticles.Stop();
            LeftThrusterParticles.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime); 
        rb.freezeRotation = false;
    }
}
