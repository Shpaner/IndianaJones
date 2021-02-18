using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        base.Die();
        // add ragdol  - death

        FindObjectOfType<AudioManager>().Play("enemy_death");

        Destroy(gameObject);
    }
}
