using UnityEngine;

[CreateAssetMenu(fileName = "BulletWeapon", menuName = "BulletWeapon")]
public class BaseBulletWeaponCreationData : ScriptableObject
{
    [SerializeField]
    public GameObject WeaponViewPrefab;
}
