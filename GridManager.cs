using JetBrains.Annotations;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour {

    [SerializeField] private Tile _tilePrefab;

    private static Dictionary<Vector2, Tile> _tiles;

    private static int _square;
    private static float offsetPosition;
    private static int moveCounter;

    public void GenerateGrid() {
        _square = GameManager.GetGridSize();
        offsetPosition = _square / 2;
        if (_square % 2 == 0) {
            offsetPosition -= 0.5f;
        }
        //Debug.Log(offsetPosition);
        moveCounter = 0;
        _tiles = new Dictionary<Vector2, Tile>();
        this.transform.position = new Vector2(0, 0);
        this.transform.localScale = new Vector2(1, 1);
        for (float x = 0 - offsetPosition; x < _square - offsetPosition; x++) {
            for (float y = 0 - offsetPosition; y < _square - offsetPosition; y++) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector2(x, y), Quaternion.identity, this.transform);
                Debug.Log("Tile: " + spawnedTile + ", x: " + spawnedTile.transform.position.x + ", y: " + spawnedTile.transform.position.y);
                spawnedTile.name = $"Tile {x} {y}";
                bool isOffset;
                if (_square % 2 == 0) {
                    isOffset = ((x + y) % 2 == 0);
                } else {
                    isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                }
                spawnedTile.Init(isOffset);
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        this.transform.position = new Vector2(-4, 0);
        this.transform.localScale = new Vector2(9f / _square, 9f / _square);

        /*foreach (var (key, value) in _tiles) {
            Debug.Log("a Tile key: " + key);
        }*/
    }

    public static void IncreaseMove() {
        moveCounter++;
        if(moveCounter >= _square * _square) {
            Debug.Log("You ran out of possible moves!\nGAME ENDED!");
            StopGame();
        }
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
            Tile readTile = _tiles[new Vector2(i, clickedTile.transform.localPosition.y)];
            if (clickedTile.GetTileState(readTile)) {
                //Debug.Log("Horizontal: " + clickedTile.transform.position.x + " " + clickedTile.transform.position.y + " = " + readTile.transform.position.x + " " + readTile.transform.position.y);
                win++;
                //Debug.Log("=================" + win);
                if (win == _square) {
                    Debug.Log("YOU WON!");
                    StopGame();
                    return true;
                }
            }
        }
        win = 0;
        // Checking vertical line
        for (float i = 0 - offsetPosition; i < _square - offsetPosition; i++) {
            Tile readTile = _tiles[new Vector2(clickedTile.transform.localPosition.x, i)];
            if (clickedTile.GetTileState(readTile)) {
                //Debug.Log("Vertical: " + clickedTile.transform.position.x + " " + clickedTile.transform.position.y + " = " + readTile.transform.position.x + " " + readTile.transform.position.y);
                win++;
                //Debug.Log("=================" + win);
                if (win == _square) {
                    Debug.Log("YOU WON!");
                    StopGame();
                    return true;
                }
            }
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
                    StopGame();
                    return true;
                }
            }
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
                    StopGame();
                    return true;
                }
            }
        }

        //Debug.Log("clickedTile, x: " + clickedTile.transform.position.x + ", y: " + clickedTile.transform.position.y);
        return false;
    }

    public static void StopGame() {

        //maybe just switch here instead of 'ifs'?
        //if moveCounter == limit -> BIG "PLAY AGAIN?" BUTTON
        //if playerTurn and GameWinner are set, BIG "PLAY AGAIN?" BUTTON
        //in both cases it takes us to SETTINGS with slider and other game settings.
        if(_tiles.Count > 0) {
            for (float x = 0 - offsetPosition; x < _square - offsetPosition; x++) {
                for (float y = 0 - offsetPosition; y < _square - offsetPosition; y++) {
                    Tile tileToDestroy = _tiles[new Vector2(x, y)];
                    Destroy(tileToDestroy.gameObject);
                }
            }
            _tiles.Clear();
        }
        
        //if not any above, just return to main menu.
    }
}
