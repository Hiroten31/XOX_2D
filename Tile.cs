using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Tile : MonoBehaviour {

    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private GameObject _O;
    [SerializeField] private GameObject _X;

    private bool tileSet = false;

    public void Init(bool isOffset) { 
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    private void OnMouseEnter() {
        _highlight.SetActive(true);
    }

    // false as "O"
    // true as "X"
    private void OnMouseDown() {
        if (tileSet == false) {
            if (GameManager.playerTurn) { 
                _X.SetActive(true);
            } else {
                _O.SetActive(true);
            }
            tileSet = true;
            GridManager.CheckIfWin(this);
            GameManager.playerTurn = !GameManager.playerTurn;
            GridManager.IncreaseMove();
        } else {
            Debug.Log(this.name + " is already set!");
        }
    }

    private void OnMouseExit() {
        _highlight.SetActive(false);
    }

    public bool GetTileState(Tile tileUnderCheck) {
        if (tileUnderCheck._X.activeSelf == true && this._X.activeSelf == true) {
            return true;
        } else if (tileUnderCheck._O.activeSelf == true && this._O.activeSelf == true) {
            return true;
        } else {
            return false;
        }
    }
}
