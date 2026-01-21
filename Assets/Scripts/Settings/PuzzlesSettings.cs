using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Create PuzzlesSettings", fileName = "PuzzlesSettings", order = 0)]
    public class PuzzlesSettings : ScriptableObject
    {
        public List<PuzzleData> puzzles;
    }
}