using Controlles;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Screens
{
    public class MainScreen : BaseScreen
    {
        [Inject] private GameController gameController;
        [SerializeField] private Button startButton;

        private void Awake()
        {
            startButton.onClick.AddListener(ShowStartScreen);
        }

        private void ShowStartScreen()
        {
            gameController.StartGame();
        }
    }
}