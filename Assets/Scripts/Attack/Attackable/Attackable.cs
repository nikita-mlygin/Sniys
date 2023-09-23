using UnityEngine;

public abstract class Attackable : MonoBehaviour
{
    public abstract void GetAttack(float damage, GameObject attacker);
}