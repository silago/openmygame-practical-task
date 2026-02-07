using System;
using System.Collections.Generic;
using System.Linq;
using Installers;
using UnityEngine;
using Zenject;

public class ScreenNavigator
{
    [Inject(Id = ScreenInstaller.ScreensPrefabs)]
    private List<BaseScreen> prefabs;
    [Inject]
    private DiContainer container;
    [Inject(Id = ScreenInstaller.ScreensRoot)]
    private Transform modalsRoot;         // куда инстанциировать (Canvas/Container)

    private Queue<BaseScreen> queue;

    public T Push<T>(Action<DiContainer> contextDecorator = null) where T : BaseScreen
    {
        if (prefabs == null || prefabs.Count == 0)
        {
            Debug.LogError("ScreenNavigator: No screen prefabs configured.");
            return null;
        }
        if (modalsRoot == null)
        {
            Debug.LogError("ScreenNavigator: Screens root is not assigned.");
            return null;
        }

        var subContainer = container.CreateSubContainer();
        contextDecorator?.Invoke(subContainer);
        
        var prefab = prefabs.FirstOrDefault(x => x.GetType() == typeof(T));
        if (prefab == null)
        {
            Debug.LogError($"ScreenNavigator: Prefab for screen type {typeof(T).Name} not found.");
            return null;
        }
        var result = subContainer.InstantiatePrefabForComponent<T>(
            prefab.gameObject,
            modalsRoot
        );

        result.Show();
        return result;
    }
}
