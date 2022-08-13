using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis
{
    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";
}

public class Tags
{
    public const string GROUND_TAG = "Ground";
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";

    public const string LEFT_ARM_TAG = "LeftArm";
    public const string LEFT_LEG_TAG = "LeftLeg";
    public const string UNTAGGED_TAG = "Untagged";
    public const string MAIN_CAMERA_TAG = "MainCamera";
    public const string HEALTH_UI = "HealthUI";

}

public class AnimationTags
{
    public const string WALK = "Walk";
    public const string PUNCH1 = "Punch1";
    public const string PUNCH1_MOTITION_NAME = "Player Punch1";
    public const string PUNCH2 = "Punch2";
    public const string PUNCH2_MOTITION_NAME = "Player Punch2";
    public const string PUNCH3 = "Punch3";
    public const string PUNCH3_MOTITION_NAME = "Player Punch3";
    public const string KICK1 = "Kick1";
    public const string KICK1_MOTITION_NAME = "Player Kick1";
    public const string KICK2 = "Kick2";
    public const string KICK2_MOTITION_NAME = "Player Kick2";

    public const string ATTACK1 = "Attack1";
    public const string ENEMY1_ATTACK1 = "Enemy1_Attack1";
    public const string ATTACK2 = "Attack2";
    public const string ENEMY1_ATTACK2 = "Enemy1_Attack2";
    public const string ATTACK3 = "Attack3";
    public const string ENEMY1_ATTACK3 = "Enemy1_Attack3";
    public const int ATTACK_AIM_COUNT = 3;
    public const string IDLE_ANIMATION = "Idle";
    public const string KNOCK_DOWN = "KnockDown";
    public const string STAND_UP = "StandUp";
    public const string HIT = "Hit";
    public const string DEATH = "Death";
}