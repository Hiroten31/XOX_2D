using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour {

    [SerializeField] private int _square;

    [SerializeField] private Tile _tilePrefab;
    void GenerateGrid() {
        for (int x = -(_square / 2); x < _square - (_square / 2); x++) {
            for(int y = -(_square / 2); y < _square - (_square / 2); y++) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector2(x, y), Quaternion.identity);
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
