using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(CharacterStat))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCoolDown = 0f;
    
    public float attackDelay = .6f;

    public event System.Action OnAttack;

    CharacterStat myStats;

    void Start()
    {
        myStats = GetComponent<CharacterStat>();    
    }

    void Update()
    {
        attackCoolDown -= Time.deltaTime;    
    }

    public void Attack(CharacterStat targetStats)
    {
        if(attackCoolDown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            
            if(OnAttack != null)
            {
                OnAttack();
            }

            attackCoolDown = 1 / attackSpeed;
        }
    }

    IEnumerator DoDamage(CharacterStat stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue());
    }
}
