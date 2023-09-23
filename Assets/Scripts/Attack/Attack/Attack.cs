using UnityEngine;

public class Attack
{
    public float Damage;
    public GameObject Attacker;

    public Attack(float damage, GameObject attacker)
    {
        Damage = damage;
        Attacker = attacker;
    }
}