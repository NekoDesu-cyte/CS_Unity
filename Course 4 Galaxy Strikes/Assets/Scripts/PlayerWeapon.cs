using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;
    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }
    private void Update() 
    {
        processFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLaser();
    
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
    void MoveTargetPoint()
    {
        Vector3 targetPointPoisition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance); 
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPoisition);
    }
    void AimLaser()
    {
        foreach (var laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
