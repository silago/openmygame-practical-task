using System;
using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Screens.Components
{
    public class PuzzleSelectionButton : MonoBehaviour
    {
        public event Action<PuzzleData> PuzzleSelected = delegate { };
    
        [SerializeField] private Image image;
        [SerializeField] private Button button;

        [Inject]
        private PuzzleData data;
    
        private void Awake()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            PuzzleSelected.Invoke(data);
        }

        private void Start()
        {
            image.sprite = data.sprite;
        }

        public class Factory : PlaceholderFactory<PuzzleData, PuzzleSelectionButton>
        {
            public override PuzzleSelectionButton Create(PuzzleData param)
            {
                var item = base.Create(param);
                return item;
            }
        }
    }
}