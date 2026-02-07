using Screens;
using Settings;
using UnityEngine;
using Zenject;

namespace Controlles
{
    public class GameController
    {
        [Inject] ScreenNavigator screenNavigator;

        public void ShowPreview(PuzzleData data)
        {
            screenNavigator.Push<PuzzlePreviewScreen>(PuzzlePreviewScreen.GetContextDecorator(data));
        }
        
        public void StartGame()
        {
            screenNavigator.Push<StartScreen>();
        }

        public void StartPuzzle(PuzzleData data, StartType startType)
        {
            Debug.Log("Starting the game here.");
        }
    }
}
