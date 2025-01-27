using UnityEngine;
using UnityEngine.InputSystem;

public class QuitApplication : MonoBehaviour
{
  private void Update() 
  {
      if (Keyboard.current.escapeKey.wasPressedThisFrame)
      {
          Application.Quit();
          Debug.Log("Escape Button is Pressed");
      }
  }

  
    
  
}

