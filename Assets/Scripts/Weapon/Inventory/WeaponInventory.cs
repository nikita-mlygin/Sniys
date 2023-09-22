using System.Runtime.CompilerServices;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    [SerializeField]
    private IWeapon primaryWeapon;

    [SerializeField]
    private IWeapon secondaryWeapon;

    private void ChangeWeapon(IWeapon weapon, bool isPrimary)
    {
        if (isPrimary)
        {
            if (primaryWeapon != null)
            {
                Destroy(primaryWeapon.WeaponGameObject);
            }
            
            primaryWeapon = weapon;
            return;
        }

        if (secondaryWeapon != null)
        {
            Destroy(secondaryWeapon.WeaponGameObject);
        }

        secondaryWeapon = weapon;
    }

    public IWeapon PrimaryWeapon { get => primaryWeapon; set => ChangeWeapon(value, true); }
    public IWeapon SecondaryWeapon { get => secondaryWeapon; set => ChangeWeapon(value, false); }
}