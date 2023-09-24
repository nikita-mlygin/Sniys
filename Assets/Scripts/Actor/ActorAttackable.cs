using UnityEngine;
using UnityEngine.SceneManagement;

public class ActorAttackable : Attackable
{
    public override void GetAttack(float damage, GameObject attacker)
    {
        SceneManager.LoadScene("MainMenu");
        GameObject.Destroy(gameObject);
    }
}