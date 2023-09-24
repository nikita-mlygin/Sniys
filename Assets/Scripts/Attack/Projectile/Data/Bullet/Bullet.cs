using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public IWeapon AttackerWeapon;
    public GameObject Attacker;
    public Vector2 Direction;
    public float Speed;
    public float Damage;
}