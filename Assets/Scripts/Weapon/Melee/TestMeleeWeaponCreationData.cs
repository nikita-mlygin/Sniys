using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeapon", menuName = "MeleeWeapon")]
public class TestMeleeWeaponCreationData : ScriptableObject
{
    [SerializeField]
    public GameObject AttackPrefab;

    [SerializeField]
    public GameObject ViewPrefab;

    [SerializeField]
    public int Damage;

    [SerializeField]
    public int AttackPerSecond;

    [SerializeField]
    public string AnimationName = "Attack";
}