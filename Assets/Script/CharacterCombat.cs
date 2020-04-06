using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharecterStats))]
public class CharacterCombat : MonoBehaviour
{
    CharecterStats myStats;

    public float attackSpeed = 1f;
    private float attackCoolDown = 0f;
    private void Start()
    {
        myStats = GetComponent<CharecterStats>();
    }

    private void Update()
    {
        attackCoolDown -= Time.deltaTime;
    }
    public void Attack(CharecterStats targetStats)
    {
        if (attackCoolDown <= 0f)
        {
            targetStats.takeDamage(myStats.damage.GetValue());
            attackCoolDown = 1f / attackSpeed;
        }
        
    }
}
