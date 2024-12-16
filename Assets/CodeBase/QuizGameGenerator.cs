using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace CodeBase
{
    public class QuizGameGenerator : MonoBehaviour
    {
        [SerializeField] private QuizGameConfig _gameConfig;
        [SerializeField] private QuizGame _game;
        [SerializeField] private GameObject _cellPrefab;
        [SerializeField] private Transform _cellSpawnPoint;
        [SerializeField] private Transform _cellParent;
        [SerializeField, Range(3,9)] private int _cellCount;
        [SerializeField] private float _cellsOffset = 1.3f;
        [SerializeField] private Vector2 _gridSize;
        [SerializeField] private List<Cell> _cells;
        [SerializeField] private Vector3 _defaultSpawnPoint;
        
        private AnimatorController _animator;

        [Inject]
        public void Construct(AnimatorController animator)
        {
            _animator = animator;
        }
        
        [Button]
        public void GenerateQuizGame()
        {
            if (_cells.Count > 0)
            {
                foreach (var cell in _cells)
                    DestroyImmediate(cell.gameObject);
            }

            _cells = new List<Cell>();
            
            int gameType = GetRandomInt(0, _gameConfig.CellTypes.Length);
            List<int> exceptionsListMainSprites = new List<int>();

            int cellsCountX = 0;
            int cellsCountY = 0;

            for (int i = 0; i < _cellCount; i++)
            {
                if (cellsCountX >= _gridSize.x)
                {
                    _cellSpawnPoint.position += new Vector3(0, _cellsOffset, 0);
                    cellsCountX = 0;
                    cellsCountY++;
                }

                int cellColor = GetRandomInt(0, _gameConfig.CellTypes[gameType].CellColorData.Length);
                int cellMainSprite = SetRandomMainSprite(gameType, exceptionsListMainSprites);

                exceptionsListMainSprites.Add(cellMainSprite);

                Vector3 spawnPosition = _cellSpawnPoint.position + new Vector3(cellsCountX * _cellsOffset, -cellsCountY * _cellsOffset, 0);
                Cell cell = Instantiate(_cellPrefab, spawnPosition, Quaternion.identity, _cellParent).GetComponent<Cell>();
                
                cell.Construct( _gameConfig.GetNameMainSprite(gameType,cellMainSprite),
                    _gameConfig.GetMainSprite(gameType,cellMainSprite),
                    _gameConfig.GetMainSpriteRotation(gameType,cellMainSprite),
                    _gameConfig.GetMainSpriteScale(gameType,cellMainSprite),
                    _gameConfig.GetCellBackgroundColor(gameType, cellColor),
                    _gameConfig.GetCellFrameColor(gameType, cellColor),
                    _game,
                    _animator
                );

                cell.name = cell.Name;
                _cells.Add(cell);

                cellsCountX++;
            }

            _cellSpawnPoint.position = _defaultSpawnPoint;
            SetRandomCorrectCell();
        }

        private void SetRandomCorrectCell()
        {
            var randomCell = Random.Range(0, _cells.Count);
            
            _game.SetCorrectCell(_cells[randomCell]);
            _cells[randomCell].SetCorrect();
        }

        private int SetRandomMainSprite(int gameType, List<int> exceptions)
        {
            var availableSprites = Enumerable
                .Range(0, _gameConfig.CellTypes[gameType].CellMainSprites.Length)
                .Except(exceptions)
                .ToList();

            if (availableSprites.Count == 0)
                throw new InvalidOperationException("No available sprites to select from.");

            int randomIndex = GetRandomInt(0, availableSprites.Count);
            return availableSprites[randomIndex];
        }
        
        private int GetRandomInt(int firstRangeInt, int secondRangeInt) => Random.Range(firstRangeInt, secondRangeInt);
    }
}