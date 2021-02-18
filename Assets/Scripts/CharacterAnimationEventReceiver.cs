using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEventReceiver : MonoBehaviour
{
    public CharacterCombat combat;
    public void AttackHitEvent()
    {
        combat.AttackHit_AnimationEvent();
    }

    public void StepL()
    {
        FindObjectOfType<AudioManager>().Play("footstep");

        Debug.Log("step");
    }

    public void StepR()
    {
        FindObjectOfType<AudioManager>().Play("footstep");

        Debug.Log("stepRRRRRR");
    }

    public void Step()
    {
        Debug.Log("step");
    }

    public void EnemyStep()
    {
        FindObjectOfType<AudioManager>().Play("bone_crack");
        Debug.Log("step");
    }
}
