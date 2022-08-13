using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image bloodVolumeOfPlayerOnHealthUI, bloodVolumeOfEnemyOnHealthUI;
    
    private void Awake()
    {
        bloodVolumeOfPlayerOnHealthUI = GameObject.FindWithTag(Tags.BLOOD_VOLUME_OF_PLAYER_ON_HEALTH_UI).GetComponent<Image>();
    }

    public void updateBloodVolumeOnPlayer(float bloodVolume)
    {
        bloodVolume /= 100;
        if(bloodVolume < 0) bloodVolume = 0;
        bloodVolumeOfPlayerOnHealthUI.fillAmount = bloodVolume;
    }

    // TODO : Enemy Health UI
}
