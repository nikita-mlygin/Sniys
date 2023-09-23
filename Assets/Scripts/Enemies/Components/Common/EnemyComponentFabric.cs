using System;
using System.Collections;
using System.Collections.Generic;

public static class EnemyComponentFabric
{
    private static IDictionary<ComponentEnum, Func<IEnemyComponent>> componentCreationDictionary = new Dictionary<ComponentEnum, Func<IEnemyComponent>>();
    private static IDictionary<ComponentEnum, IEnemyComponent> componentsInst = new Dictionary<ComponentEnum, IEnemyComponent>();

    public static void AddComponentCreation(ComponentEnum type, Func<IEnemyComponent> componentCreator)
    {
        componentCreationDictionary.Add(type, componentCreator);
    }

    public static bool TryGet(ComponentEnum type, out IEnemyComponent component)
    {
        if (componentsInst.TryGetValue(type, out component))
        {
            return true;
        }

        if (componentCreationDictionary.TryGetValue(type, out var creator))
        {
            component = creator();
            componentsInst.Add(type, component);
            return true;
        }

        return false;
    }
}