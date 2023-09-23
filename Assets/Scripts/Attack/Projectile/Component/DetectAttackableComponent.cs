using Unity.VisualScripting;
using UnityEngine;

public class DetectAttackComponent : IProjectileComponent
{
    public bool Next(ref GameObject projectile)
    {
        if (
            !projectile.IsDestroyed() &&
            projectile.TryGetComponent<DetectedObjectsList>(out var detectedObjectsList) && 
            projectile.TryGetComponent<DetectedAttackableList>(out var detectedAttackableList) &&
            detectedObjectsList.DetectedObjects.Count > 0
            )
        {
            for (int i = 0; i < detectedObjectsList.DetectedObjects.Count; i++)
            {
                if (detectedObjectsList.DetectedObjects[i] == null)
                {
                    continue;
                }

                if (projectile.IsDestroyed())
                {
                    return false;
                }

                if (detectedObjectsList.DetectedObjects[i].gameObject.TryGetComponent<Attackable>(out var attackable))
                {
                    detectedAttackableList.AttackableObjectList.Add(attackable);
                }
            }
        }

        return true;
    }
}