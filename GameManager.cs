using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    //gameState to control what player is currently doing
    //0 is menu
    //1 is game
    //2 is game + menu?? -> (player won, nothing dissapears and game waits for player to click menu option)
    public static int gameState = 0;

    public int gridSize = 3;

    // false as "O"
    // true as "X"
    public static bool playerTurn = false;

    public void Awake() {
        Instance = this;
    }

    public static void SetGridSize(int size) {
        Instance.gridSize = size;
    }

    public static int GetGridSize() {
        Instance.gridSize = SliderScript.value;
        return Instance.gridSize;
    }
}
