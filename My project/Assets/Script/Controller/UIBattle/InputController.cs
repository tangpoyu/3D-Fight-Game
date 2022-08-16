using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller
public class InputController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playMovement; // Service
  
    private bool isZPressed = false, isXPressed = false;
   
    public bool IsZPressed { get => isZPressed; set => isZPressed = value; }
    public bool IsXPressed { get => isXPressed; set => isXPressed = value; }



    public void PunchZ()
    {
        string currentAnimation = playMovement.GetCurrentCharacterAnimation();
        if (currentAnimation != AnimationTags.IDLE_ANIMATION) return;
        IsZPressed = true;
    }

    public void KickX()
    {
        string currentAnimation = playMovement.GetCurrentCharacterAnimation();
        if (currentAnimation != AnimationTags.IDLE_ANIMATION) return;
        IsXPressed = true;
    }
}
