using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SplashProjectileData : ScriptableObject
{
    [SerializeField]
    public GameObject SplashPrefab;
    [SerializeField]
    public float AttackPerSecond;
    [SerializeField]
    public List<ProjectileComponentEnum> Components;
}