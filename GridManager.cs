using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour {

    [SerializeField] private Tile _tilePrefab;

    private static Dictionary<Vector2, Tile> _tiles;

    private static int _square;
    private static float offsetPosition;

    public void GenerateGrid() {
        _square = GameManager.GetGridSize();
        offsetPosition = _square / 2;
        if (_square % 2 == 0) {
            offsetPosition -= 0.5f;
        }
        _tiles = new Dictionary<Vector2, Tile>();
        for (float x = 0; x < _square; x++) {
            for (float y = 0; y < _square; y++) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector2(x - offsetPosition, y - offsetPosition), Quaternion.identity);
                spawnedTile.name = $"Tile {x - offsetPosition} {y - offsetPosition}";
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
                //Debug.Log("Tile: " + spawnedTile + ", name: " + spawnedTile.name);
                _tiles[new Vector2(x - offsetPosition, y - offsetPosition)] = spawnedTile;
            }
        }

        /*foreach (var (key, value) in _tiles) {
            Debug.Log("a Tile key: " + key);
        }*/
    }

    public Tile GetTileAtPosition(Vector2 position) {
        if (_tiles.TryGetValue(position, out Tile tile))
            return tile;
        return null;
    }

    public static bool CheckIfWin(Tile clickedTile) {
        int win = 0;

        // Checking horizontal line
        for (float i = 0; i < GameManager.GetGridSize(); i++) {
            Tile readTile = _tiles[new Vector2(i - offsetPosition, clickedTile.transform.position.y)];
            if (clickedTile.GetTileState(readTile)) {
                //Debug.Log("Horizontal: " + clickedTile.transform.position.x + " " + clickedTile.transform.position.y + " = " + readTile.transform.position.x + " " + readTile.transform.position.y);
                win++;
                //Debug.Log("=================" + win);
                if (win == _square) {
                    Debug.Log("YOU WON!");
                    break;
                }
            }

        }
        win = 0;
        // Checking vertical line
        for (float i = 0; i < GameManager.GetGridSize(); i++) {
            Tile readTile = _tiles[new Vector2(clickedTile.transform.position.x, i - offsetPosition)];
            if (clickedTile.GetTileState(readTile)) {
                //Debug.Log("Vertical: " + clickedTile.transform.position.x + " " + clickedTile.transform.position.y + " = " + readTile.transform.position.x + " " + readTile.transform.position.y);
                win++;
                //Debug.Log("=================" + win);
                if (win == _square) {
                    Debug.Log("YOU WON!");
                    break;
                }
            };
        }
        //Debug.Log("clickedTile, x: " + clickedTile.transform.position.x + ", y: " + clickedTile.transform.position.y);
        return true;
    }
}
