using System.Collections.Generic;
using Controlles;
using Screens.Components;
using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Screens
{
    public class StartScreen : BaseScreen
    {
        [Inject] PuzzleSelectionButton.Factory selectionButtonPool;
        [Inject] private PuzzlesSettings settings;
        [Inject] private GameController gameController;

        [SerializeField] private Button closeButton;
        [SerializeField] private Transform buttonsContainer;

        private void Awake()
        {
            if (settings == null)
            {
                Debug.LogError("StartScreen: PuzzlesSettings is not assigned.");
                return;
            }
            if (settings.puzzles == null || settings.puzzles.Count == 0)
            {
                Debug.LogWarning("StartScreen: No puzzles configured in PuzzlesSettings.");
            }
            if (buttonsContainer == null)
            {
                Debug.LogError("StartScreen: Buttons container is not assigned.");
                return;
            }
            if (closeButton == null)
            {
                Debug.LogError("StartScreen: Close button is not assigned.");
                return;
            }

            foreach (var puzzleData in settings.puzzles ?? new List<PuzzleData>())
            {
                var item = selectionButtonPool.Create(puzzleData);
                item.transform.SetParent(buttonsContainer);
                item.PuzzleSelected += OnPuzzleSelected;
            }
        
            closeButton.onClick.AddListener(Close);
        }

        private void OnPuzzleSelected(PuzzleData obj)
        {
            gameController.ShowPreview(obj);
        }
    }
}
