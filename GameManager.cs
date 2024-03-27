using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public int gridSize = 3;

    public void OnEnable() {
        Debug.Log("Dzialaj prosze...");
    }

    public void Awake() {
        Instance = this;
    }

    public void SetGridSize(int size) {
        Instance.gridSize = size;
    }

    public static int GetGridSize() {
        return Instance.gridSize;
    }
}
