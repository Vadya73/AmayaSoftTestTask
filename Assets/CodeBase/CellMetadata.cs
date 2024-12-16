using System;
using UnityEngine;

namespace CodeBase
{
    [Serializable]
    public class CellMetadata
    {
        [SerializeField] private string _cellTypeName;
        [SerializeField] private CellSpritesData[] _cellMainSprites;
        [SerializeField] private CellColorData[] _cellColors;
        
        public CellColorData[] CellColorData => _cellColors;
        public CellSpritesData[] CellMainSprites => _cellMainSprites;
    }
    
    [Serializable]
    public struct CellColorData
    {
        [SerializeField] private string _name;
        [SerializeField] private Color _backgroundColor;
        [SerializeField] private Color _frameColor;
        
        public string Name => _name;
        public Color BackgroundColor => _backgroundColor;
        public Color FrameColor => _frameColor;
    }

    [Serializable]
    public struct CellSpritesData
    {
        [SerializeField] private string _spriteName;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Vector3 _defaultRotation;
        [SerializeField] private Vector3 _defaultScale;
        
        public string Name => _spriteName;
        public Sprite Sprite => _sprite;
        public Vector3 DefaultRotation => _defaultRotation;
        public Vector3 DefaultScale => _defaultScale;
    }
}