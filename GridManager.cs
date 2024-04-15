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
        //Debug.Log(offsetPosition);
        _tiles = new Dictionary<Vector2, Tile>();
        for (float x = 0 - offsetPosition; x < _square - offsetPosition; x++) {
            for (float y = 0 - offsetPosition; y < _square - offsetPosition; y++) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector2(x , y), Quaternion.identity, this.transform);
                spawnedTile.name = $"Tile {x} {y}";
                bool isOffset;
                if(_square % 2 == 0) {
                    isOffset = ((x + y) % 2 == 0);
                } else {
                    isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                }
                spawnedTile.Init(isOffset);
                //Debug.Log("Tile: " + spawnedTile + ", name: " + spawnedTile.name);
                _tiles[new Vector2(x, y)] = spawnedTile;
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
        for (float i = 0 - offsetPosition; i < _square - offsetPosition; i++) {
            Tile readTile = _tiles[new Vector2(i, clickedTile.transform.position.y)];
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
        for (float i = 0 - offsetPosition; i < _square - offsetPosition; i++) {
            Tile readTile = _tiles[new Vector2(clickedTile.transform.position.x, i)];
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
        win = 0;
        // Checking diagonal /
        for (float i = 0 - offsetPosition; i < _square - offsetPosition; i++) {
            Tile readTile = _tiles[new Vector2(i, i)];
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
        win = 0;
        // Checking diagonal \
        for (float i = 0; i < _square; i++) {
            Tile readTile = _tiles[new Vector2(i - offsetPosition, _square - 1 - i - offsetPosition)];
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
