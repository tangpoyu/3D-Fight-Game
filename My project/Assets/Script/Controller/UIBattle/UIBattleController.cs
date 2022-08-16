using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller
public class UIBattleController : MonoBehaviour
{
    [SerializeField]
    private bool isMobileDevice;
    [SerializeField]
    private GameObject mobileKeyUI;

    public bool IsMobileDevice { get => isMobileDevice; set => isMobileDevice = value; }

    private void Awake()
    {
        if(!isMobileDevice) mobileKeyUI.SetActive(false);
    }
}
