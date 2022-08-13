using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterAnimation
{
    void Walk(bool isWalk);
    void Punch1();
    void Punch2();
    void Punch3();
    void Kick1();
    void Kick2();
    void Idle();
    void KnockDown();
    void StandUp();
    void Hit();
    void Death();

    Animator GetAnimator();
}
