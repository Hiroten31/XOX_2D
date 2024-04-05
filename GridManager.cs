using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour {

    [SerializeField] private Tile _tilePrefab;

    public static Dictionary<Vector2, Tile> _tiles;

    public void GenerateGrid() {
        int _square = GameManager.GetGridSize();
        float offsetPosition = _square / 2;
        if (_square % 2 == 0) {
            offsetPosition -= 0.5f;
        }
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _square; x++) {
            for (int y = 0; y < _square; y++) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector2(x - offsetPosition, y - offsetPosition), Quaternion.identity);
                spawnedTile.name = $"Tile {x - offsetPosition} {y - offsetPosition}";
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
                Debug.Log("Tile: " + spawnedTile + ", name: " + spawnedTile.name);
                _tiles[new Vector2(x - offsetPosition, y - offsetPosition)] = spawnedTile;
            }
        }
    }

    public Tile GetTileAtPosition(Vector2 position) {
        if (_tiles.TryGetValue(position, out Tile tile))
            return tile;
        return null;
    }

    public static bool CheckIfWin(Tile clickedTile) {
        Vector2 tilePosition = clickedTile.transform.position;

        // Checking horizontal line
        for (int i = 0; i < GameManager.GetGridSize(); i++) {
            // Here I have to do something with the fact of for loop range (0, GridSize) and
            // the fact that I operate of Tiles that are moved...
            //
            // or just DELETE OFFSET IN _TILES!!!
            Tile readTile = _tiles[new Vector2(0, 0)];
            if (clickedTile.GetTileState(readTile)) {
                Debug.Log("Zgadza sie!");
            };
        }
        // Checking vertical line
        for (int i = 0; i < GameManager.GetGridSize(); i++) {

        }
        Debug.Log("clickedTile, x: " + tilePosition.x + ", y: " + tilePosition.y);
        return true;
    }
}
