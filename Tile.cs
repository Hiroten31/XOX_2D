using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private GameObject _O;
    [SerializeField] private GameObject _X;

    public void Init(bool isOffset) { 
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    private void OnMouseEnter() {
        _highlight.SetActive(true);
    }

    private void OnMouseDown() {
        if (_O.activeSelf == false) {
            _O.SetActive(true);
            _X.SetActive(false);
        } else {
            _X.SetActive(true);
            _O.SetActive(false);
        }
    }

    private void OnMouseExit() {
        _highlight.SetActive(false);
    }
}
