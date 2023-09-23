using UnityEngine;

public class BulletDetectComponent : IProjectileComponent
{
    public bool Next(ref GameObject projectile)
    {
        if (projectile.TryGetComponent<DetectedObjectsList>(out var detectedObjectsList) && detectedObjectsList.DetectedObjects.Count > 0)
        {
            Object.Destroy(projectile);

            return false;
        }

        return true;
    }
}
