using UnityEngine;

[CreateAssetMenu(fileName = "BulletWeapon", menuName = "BulletWeapon")]
public class BaseBulletCreationData : ScriptableObject
{
    [SerializeField]
    public GameObject BulletPrefab;

    [SerializeField]
    public float Speed = 5;

    [SerializeField]
    public float Size = 1;

    [SerializeField]
    public float Damage = 10;

    [SerializeField]
    public float AttackPerSecond = 1;

    [SerializeField]
    public float lifeTime = 2f;
}
