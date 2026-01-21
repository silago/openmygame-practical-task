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
            foreach (var puzzleData in settings.puzzles)
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