using JetBrains.Annotations;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using TMPro.EditorUtilities;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour {
    [SerializeField] private TextBoxManager textBoxManager;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private MoveDisplay moveDisplay;
    [SerializeField] public GameObject Menus;
    [SerializeField] public static GameObject PLAYAGAIN;

    private static Dictionary<Vector2, Tile> _tiles;

    private static int _square;
    private static float offsetPosition;
    private static int moveCounter;

    static TextBoxManager textBox;
    static MoveDisplay display;

    private static GameObject PLAY;
    private static GameObject QUIT;

    public void GenerateGrid() {
        GameManager.gameState = 1;
        GameManager.gameWinner = -1;
        PLAYAGAIN = Menus.transform.Find("PlayAgain").gameObject;
        PLAY = GameObject.Find("Menus/GameMenu/PLAY");
        QUIT = GameObject.Find("Menus/GameMenu/QUIT");
        PLAY.SetActive(true);
        QUIT.SetActive(true);
        PLAYAGAIN.SetActive(false);
        _square = GameManager.GetGridSize();
        offsetPosition = _square / 2;
        if (_square % 2 == 0) {
            offsetPosition -= 0.5f;
        }
        Debug.Log(offsetPosition);
        moveCounter = 0;
        _tiles = new Dictionary<Vector2, Tile>();
        display = moveDisplay;
        textBox = textBoxManager;
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
        textBox.StartTextBox("GOOD LUCK!"); // a test message
        /*foreach (var (key, value) in _tiles) {
            Debug.Log("a Tile key: " + key);
        }*/
    }

    public static void IncreaseMove() {
        moveCounter++;
        if(moveCounter >= _square * _square && GameManager.gameState != 2) {
            textBox.StartTextBox("You ran out of possible moves!\nGAME ENDED!");
            StopGame();
        }
        display.ChangeDisplay();
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
                win++;
                if (win == _square) {
                    textBox.StartTextBox("YOU WON!");
                    StopGame();
                    Debug.Log("YOU WON!");
                    return true;
                }
            }
        }

        win = 0;
        // Checking vertical line
        for (float i = 0 - offsetPosition; i < _square - offsetPosition; i++) {
            Tile readTile = _tiles[new Vector2(clickedTile.transform.localPosition.x, i)];
            if (clickedTile.GetTileState(readTile)) {
                win++;
                if (win == _square) {
                    textBox.StartTextBox("YOU WON!");
                    StopGame();
                    Debug.Log("YOU WON!");
                    return true;
                }
            }
        }

        win = 0;
        // Checking diagonal /
        for (float i = 0 - offsetPosition; i < _square - offsetPosition; i++) {
            Tile readTile = _tiles[new Vector2(i, i)];
            if (clickedTile.GetTileState(readTile)) {
                win++;
                if (win == _square) {
                    textBox.StartTextBox("YOU WON!");
                    StopGame();
                    Debug.Log("YOU WON!");
                    return true;
                }
            }
        }

        win = 0;
        // Checking diagonal \
        for (float i = 0; i < _square; i++) {
            Tile readTile = _tiles[new Vector2(i - offsetPosition, _square - 1 - i - offsetPosition)];
            if (clickedTile.GetTileState(readTile)) {
                win++;
                if (win == _square) {
                    textBox.StartTextBox("YOU WON!");
                    StopGame();
                    Debug.Log("YOU WON!");
                    return true;
                }
            }
        }

        return false;
    }

    public static void StopGame() {
        if(GameManager.playerTurn) {
            GameManager.gameWinner = 0;
        } else {
            GameManager.gameWinner = 1;
        }
        if (GameManager.gameWinner != -1 || (moveCounter >= _square * _square && GameManager.gameState != 2)) {
            PLAY.SetActive(false);
            QUIT.SetActive(false);
            PLAYAGAIN.SetActive(true);
        }
        GameManager.gameState = 2;
    }

    public static void EndGame() {
        //maybe just switch here instead of 'ifs'?
        //if moveCounter == limit -> BIG "PLAY AGAIN?" BUTTON
        //if playerTurn and GameWinner are set, BIG "PLAY AGAIN?" BUTTON
        //in both cases it takes us to SETTINGS with slider and other game settings.
        if (_tiles.Count > 0) {
            for (float x = 0 - offsetPosition; x < _square - offsetPosition; x++) {
                for (float y = 0 - offsetPosition; y < _square - offsetPosition; y++) {
                    Tile tileToDestroy = _tiles[new Vector2(x, y)];
                    Destroy(tileToDestroy.gameObject);
                }
            }
            _tiles.Clear();
            textBox.EmptyTextBox();
            GameManager.gameState = 0;
        }

        //if not any above, just return to main menu.
    }
}
