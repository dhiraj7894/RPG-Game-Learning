using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharecterStats
{
    public override void Die()
    {
        base.Die();
        //Add regdol animation
        Destroy(gameObject);
    }
}
