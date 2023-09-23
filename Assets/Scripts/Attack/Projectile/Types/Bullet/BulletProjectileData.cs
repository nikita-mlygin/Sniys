using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BulletProjectileData : ScriptableObject
{
    [SerializeField]
    public GameObject Prefab;
    
    [SerializeField]
    public float DeathTimeOffset;
    
    [SerializeField]
    public float Damage;
    
    [SerializeField]
    public float Speed;
    
    [SerializeField]
    public float Size = 1;
    
    [SerializeField]
    public float AttackPerSecond = 1;

    [SerializeField]
    public List<ProjectileComponentEnum> Components;
}