using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharecterStats))]
public class CharacterCombat : MonoBehaviour
{
    public event System.Action OnAttack;


    CharecterStats myStats;

    public float attackSpeed = 1f;
    private float attackCoolDown = 0f;
    public float attackDelay = 0.6f;

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
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if (OnAttack != null)
                OnAttack();

            attackCoolDown = 1f / attackSpeed;
        }
        
    }

    IEnumerator DoDamage(CharecterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.takeDamage(myStats.damage.GetValue());
    }
}
