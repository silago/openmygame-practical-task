using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ScreenInstaller : MonoInstaller
    {
        public const string ScreensPrefabs = "ScreensPrefabs";
        public const string ScreensRoot = "ScreensRoot";
    
        [SerializeField]
        private List<BaseScreen> prefabs;
        [SerializeField]
        private Transform modalsRoot;
    
    
        public override void InstallBindings()
        {
            Container.BindInstance(prefabs).WithId(ScreensPrefabs).AsSingle();
            Container.BindInstance(modalsRoot).WithId(ScreensRoot).AsSingle();
            Container.BindInterfacesAndSelfTo<ScreenNavigator>().AsSingle();
        }
    }
}