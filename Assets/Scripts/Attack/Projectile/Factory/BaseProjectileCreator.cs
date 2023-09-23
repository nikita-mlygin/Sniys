using UnityEngine;

public abstract class BaseProjectileCreator<T> : IProjectileCreator
    where T : ScriptableObject
{
    public BaseProjectileCreator(T data)
    {
        this.data = data;
    }

    public BaseProjectileCreator(string path)
    {
        var resource = Resources.Load(path);

        this.data = (T)resource;
    }

    protected T data;

    public abstract IProjectile CreateProjectile(IWeapon weapon, Vector2 direction);
}