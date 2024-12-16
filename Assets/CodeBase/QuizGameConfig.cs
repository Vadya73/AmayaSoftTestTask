using UnityEngine;

namespace CodeBase
{
    [CreateAssetMenu(fileName ="QuizGameConfig",menuName = "QuizGame/Config")]
    public class QuizGameConfig : ScriptableObject
    { 
        [field: SerializeField] private CellMetadata[] _cellTypes;
        
        public CellMetadata[] CellTypes => _cellTypes;

        public string GetNameMainSprite(int cellTypeIndex, int cellSpriteIndex) => _cellTypes[cellTypeIndex].CellMainSprites[cellSpriteIndex].Name;

        public Sprite GetMainSprite(int cellTypeIndex, int cellSpriteIndex) => _cellTypes[cellTypeIndex].CellMainSprites[cellSpriteIndex].Sprite;

        public Vector3 GetMainSpriteRotation(int cellTypeIndex, int cellSpriteIndex) => _cellTypes[cellTypeIndex].CellMainSprites[cellSpriteIndex].DefaultRotation;

        public Vector3 GetMainSpriteScale(int cellTypeIndex, int cellSpriteIndex) => _cellTypes[cellTypeIndex].CellMainSprites[cellSpriteIndex].DefaultScale;

        public Color GetCellBackgroundColor(int cellTypeIndex, int cellColorIndex) => _cellTypes[cellTypeIndex].CellColorData[cellColorIndex].BackgroundColor;

        public Color GetCellFrameColor(int cellTypeIndex, int cellColorIndex) => _cellTypes[cellTypeIndex].CellColorData[cellColorIndex].FrameColor;
    }
}