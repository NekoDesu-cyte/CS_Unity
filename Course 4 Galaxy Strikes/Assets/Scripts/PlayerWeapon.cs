using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }
    private void Update() 
    {
        processFiring();
        MoveCrosshair();
    
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
    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
}
