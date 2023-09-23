using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class MeleeEnemyData : ScriptableObject
{
    [SerializeField] 
    public GameObject EnemyPrefab;
    
    [SerializeField] 
    public string PrimaryWeapon;
    
    [SerializeField] 
    public float MaxSpeed;
    
    [SerializeField] 
    public float AttackDistance;
    
    [SerializeField] 
    public List<EnemiesComponentEnum> Components = new List<EnemiesComponentEnum>();
}