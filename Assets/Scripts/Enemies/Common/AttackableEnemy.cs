using UnityEngine;

public class AttackableEnemy : Attackable
{
    private EnemyGettingAttacks attacks;

    private void Start()
    {
        attacks = GetComponent<EnemyGettingAttacks>();
    }

    public override void GetAttack(float damage, GameObject attacker)
    {
        attacks.Attacks.Add(new Attack(damage, attacker));
    }
}