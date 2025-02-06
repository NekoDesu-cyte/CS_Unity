using UnityEngine;

public class ObsatcleDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.gameObject);
    }
}
