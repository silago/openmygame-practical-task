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

    private readonly List<ScreenEntry> stack = new List<ScreenEntry>();

    public T Push<T>(Action<DiContainer> contextDecorator = null, bool hidePrevious = false) where T : BaseScreen
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

        if (hidePrevious && stack.Count > 0)
        {
            stack[stack.Count - 1].Screen.Hide();
        }
        var result = subContainer.InstantiatePrefabForComponent<T>(
            prefab.gameObject,
            modalsRoot
        );

        result.Closed += () => OnScreenClosed(result);
        stack.Add(new ScreenEntry(result, hidePrevious));
        result.Show();
        return result;
    }

    private void OnScreenClosed(BaseScreen screen)
    {
        var index = stack.FindIndex(x => x.Screen == screen);
        if (index < 0)
        {
            return;
        }

        var entry = stack[index];
        var wasTop = index == stack.Count - 1;
        stack.RemoveAt(index);

        if (entry.HidePrevious && wasTop && stack.Count > 0)
        {
            stack[stack.Count - 1].Screen.Show();
        }
    }

    private sealed class ScreenEntry
    {
        public ScreenEntry(BaseScreen screen, bool hidePrevious)
        {
            Screen = screen;
            HidePrevious = hidePrevious;
        }

        public BaseScreen Screen { get; }
        public bool HidePrevious { get; }
    }
}
