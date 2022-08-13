using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelegate : MonoBehaviour
{
    [SerializeField]
    private GameObject leftArmAttackPoint, rightArmAttackPoint, leftLegAttackPoint, rightLegAttackPoint;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip whooshSound, fallSound, goundHitSound, deadSound;
    private CharacterMovement characterMovement;
    private int originalLayer;
    private ShakeCamera shakeCamera;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        characterMovement = GetComponentInParent<CharacterMovement>();
        originalLayer = transform.parent.gameObject.layer;
        shakeCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();
    }

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

    public void AttackFxSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whooshSound;
        audioSource.Play();
    }

    public void DiedSound()
    {
        audioSource.volume = 1f;
        audioSource.clip = deadSound;
        audioSource.Play();
    }

    public void KockedDownSound()
    {
        audioSource.clip = fallSound;
        audioSource.Play();
    }

    public void HitGroundSound()
    {
        audioSource.clip = goundHitSound;
        audioSource.Play();
    }

    public void DisableCharacterMovement()
    {
        characterMovement.enabled = false;
        transform.parent.gameObject.layer = 0;
    }

    public void EnableCharacterMovement()
    {
        characterMovement.enabled = true;
        transform.parent.gameObject.layer = originalLayer;
    }

    public void ShakeCamera()
    {
        shakeCamera.ShouldShake = true;
    }

    public void Dead()
    {
        Invoke("DestroyGameObject", 2f);
    }

    private void DestroyGameObject()
    {
        Destroy(GameObject.FindGameObjectsWithTag(gameObject.transform.parent.tag)[0]);
        EnemyManager.instance.SpawnEnemy();
    }
}
