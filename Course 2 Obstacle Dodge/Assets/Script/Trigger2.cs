using UnityEngine;

public class Trigger2 : MonoBehaviour
{
   [SerializeField] GameObject Cube;

   private void OnTriggerEnter(Collider other)
   {
        if (other.gameObject.tag == "Player")
        {
            Cube.SetActive(true);
        }
   }
}

