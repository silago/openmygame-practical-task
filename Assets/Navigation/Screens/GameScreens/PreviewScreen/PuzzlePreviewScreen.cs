using System;
using System.Collections.Generic;
using Controlles;
using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Screens
{
    public class PuzzlePreviewScreen : BaseScreen
    {
        public static Action<DiContainer> GetContextDecorator(PuzzleData data)
        {
            return (container) =>
            {
                container.BindInstance(data);
            };
        }
    
        [Inject] private PuzzleData puzzleData;
        [Inject] private GameController gameController;

        [SerializeField] private Button closeButton;
        [SerializeField] private Button freeStart;
        [SerializeField] private Button advStart;
        [SerializeField] private Button payedStart;
        [SerializeField] private Image image;
        
        [SerializeField] private ToggleGroup toggleGroup;
        [SerializeField] private List<int> toggleGroupValues = new List<int>() { 32, 64, 128 };

        private void Awake()
        {
            closeButton.onClick.AddListener(Close);
            image.sprite = puzzleData.sprite;
        
            advStart.onClick.AddListener(OnAdvStartClicked);
            freeStart.onClick.AddListener(OnFreeStartClicked);
            payedStart.onClick.AddListener(OnPayedStartClicked);
        }

        private void OnPayedStartClicked()
        {
            gameController.StartPuzzle(puzzleData, StartType.Coins);
        }

        private void OnFreeStartClicked()
        {
            gameController.StartPuzzle(puzzleData, StartType.Free);
        }

        private void OnAdvStartClicked()
        {
            gameController.StartPuzzle(puzzleData, StartType.Adv);
        }
    }
}