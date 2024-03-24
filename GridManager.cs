using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour {

    [SerializeField] private int _square;
    [SerializeField] private Tile _tilePrefab;
    void GenerateGrid() {
        float offsetPosition = _square / 2;
        if (_square%2 == 0) {
            offsetPosition -= 0.5f;
        }
        for (int x = 0; x < _square; x++) {
            for(int y = 0; y < _square; y++) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector2(x - offsetPosition, y - offsetPosition), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
            }
        }
    }
    // Start is called before the first frame update
    void Start() {
        GenerateGrid();
    }
}
