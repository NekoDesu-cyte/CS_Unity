using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    bool isFiring = false;
    private void Update() 
    {
        processFiring();
    }
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void processFiring()
    {
        foreach (var laser in lasers)
        {
           var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isFiring;     
        }
        
    }
}
