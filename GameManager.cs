using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public int gridSize = 3;

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
