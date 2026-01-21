using Installers;
using Settings;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
    
    [SerializeField] private PuzzlesSettings puzzleSettings;
    public override void InstallBindings()
    {
        Container.BindInstance(puzzleSettings).AsSingle();
    }
}