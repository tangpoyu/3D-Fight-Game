using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller
public class UIBattleController : MonoBehaviour
{
    [SerializeField]
    private bool isMobileDevice;

    public bool IsMobileDevice { get => isMobileDevice; set => isMobileDevice = value; }
  
}
