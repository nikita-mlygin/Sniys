using UnityEngine;

public interface IEnemyComponent
{
    public bool Next(ref GameObject enemy, out bool isDelete);
}