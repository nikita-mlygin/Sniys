using UnityEngine;

public abstract class BaseEnemyCreator<T> : IEnemyCreator
    where T : ScriptableObject
{
    protected T data;

    public BaseEnemyCreator(T data)
    {
        this.data = data;
    }

    public BaseEnemyCreator(string path)
    {
        var eData = Resources.Load(path);

        this.data = eData as T;
    }


    public abstract IEnemy CreateEnemy(Vector3 position);
}