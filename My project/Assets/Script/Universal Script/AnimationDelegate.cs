using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelegate : MonoBehaviour
{
    [SerializeField]
    private GameObject leftArmAttackPoint, rightArmAttackPoint, leftLegAttackPoint, rightLegAttackPoint;
   
    public void TurnOnleftArmAttackPoint()
    {
        leftArmAttackPoint.SetActive(true);
    }

    public void TurnOffleftArmAttackPoint()
    {
        leftArmAttackPoint.SetActive(false);
    }

    public void TurnOnRightrmAttackPoint()
    {
        rightArmAttackPoint.SetActive(true);
    }

    public void TurnOffRightrmAttackPoint()
    {
        rightArmAttackPoint.SetActive(false);
    }

    public void TurnOnleftLegAttackPoint()
    {
        leftLegAttackPoint.SetActive(true);
    }

    public void TurnOffleftLegAttackPoint()
    {
        leftLegAttackPoint.SetActive(false);
    }

    public void TurnOnRightLegAttackPoint()
    {
        rightLegAttackPoint.SetActive(true);
    }

    public void TurnOffRightLegAttackPoint()
    {
        rightLegAttackPoint.SetActive(false);
    }
}
