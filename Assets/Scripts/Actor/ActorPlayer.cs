using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ActorPlayer : MonoBehaviour
{
    [SerializeField]
    private ProjectileManager projectileManager;

    private MoveController moveController;
    private WeaponInventory weaponInventory;
    private Attacker attacker;

    private void Start()
    {
        moveController = GetComponent<MoveController>();
        weaponInventory = GetComponent<WeaponInventory>();
        attacker  = GetComponent<Attacker>();

        if (WeaponFabric.TryCreateWeapon("Sword", gameObject, projectileManager, out var primary))
        {
            weaponInventory.PrimaryWeapon = primary;
        }

        if (WeaponFabric.TryCreateWeapon("Pistol", gameObject, projectileManager, out var secondary))
        {
            weaponInventory.SecondaryWeapon = secondary;
        }
    }

    private void Update()
    {
        moveController.SetDirection(new Vector2()
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = Input.GetAxisRaw("Vertical"),
        });

        if (Input.GetMouseButtonDown(0))
        {
            var attackDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            attacker.Attack(weaponInventory.PrimaryWeapon, attackDirection);
        }

        if (Input.GetMouseButtonDown(1))
        {
            var attackDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            attacker.Attack(weaponInventory.SecondaryWeapon, attackDirection);
        }
    }
}
