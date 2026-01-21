using Screens.Components;
using Settings;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PuzzleUiInstaller : MonoInstaller
    {
        [SerializeField] private PuzzleSelectionButton prefab;

        public override void InstallBindings()
        {
            Container.BindFactory<PuzzleData, PuzzleSelectionButton, PuzzleSelectionButton.Factory>()
                .FromComponentInNewPrefab(prefab);
        }
    }
}