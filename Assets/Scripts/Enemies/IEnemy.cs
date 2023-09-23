using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{ 
    public GameObject EnemyInstance { get; }
    public List<IEnemyComponent> ComponentList { get; }
}