using UnityEngine;

public class WeaponRegisterStart : MonoBehaviour
{
    private void Awake()
    {
        WeaponRegister.Register();
    }
}