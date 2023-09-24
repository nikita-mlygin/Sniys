using UnityEngine;

public class ActorAttackable : Attackable
{
    public override void GetAttack(float damage, GameObject attacker)
    {
        GameObject.Destroy(gameObject);
    }
}