using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image bloodVolumeOfPlayerOnHealthUI, bloodVolumeOfEnemyOnHealthUI;
    
    private void Awake()
    {
        bloodVolumeOfPlayerOnHealthUI = GetComponent<Image>();
    }

    public void updateBloodVolumeOnPlayer(float bloodVolume)
    {
        bloodVolume /= 100;
        if(bloodVolume < 0) bloodVolume = 0;
        bloodVolumeOfPlayerOnHealthUI.fillAmount = bloodVolume;
    }

    // TODO : Enemy Health UI
}
