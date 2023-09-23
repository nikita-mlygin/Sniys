using Unity.VisualScripting;
using UnityEngine;

public class DetectAttackComponent : IProjectileComponent
{
    public bool Next(ref GameObject projectile)
    {
        if (
            projectile.TryGetComponent<DetectedObjectsList>(out var detectedObjectsList) && 
            projectile.TryGetComponent<DetectedAttackable>(out var detectedAttackableList) &&
            detectedObjectsList.DetectedObjects.Count > 0
            )
        {
            for (int i = 0; i < detectedObjectsList.DetectedObjects.Count; i++)
            {
                if (detectedObjectsList.DetectedObjects[i].gameObject.TryGetComponent<Attackable>(out var attackable))
                {
                    detectedAttackableList.AttackableObjectList.Add(attackable);
                }
            }
        }

        return true;
    }
}