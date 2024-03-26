using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    [SerializeField] private Tile _tilePrefab;

    public Dictionary<Vector2, Tile> _tiles;

    public void GenerateGrid(int _square) {
        float offsetPosition = _square / 2;
        if (_square % 2 == 0) {
            offsetPosition -= 0.5f;
        }
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _square; x++) {
            for (int y = 0; y < _square; y++) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector2(x - offsetPosition, y - offsetPosition), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
                Debug.Log("Tile: " + spawnedTile + ", name: " + spawnedTile.name);
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
    }

    public Tile GetTileAtPosition(Vector2 position) {
        if (_tiles.TryGetValue(position, out Tile tile))
            return tile;
        return null;
    }
}
