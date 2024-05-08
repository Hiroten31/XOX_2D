using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDisplay : MonoBehaviour {
    [SerializeField] private GameObject _O;
    [SerializeField] private GameObject _X;

    public void ChangeDisplay() {
        if(GameManager.playerTurn == true) {
            _O.SetActive(false);
            _X.SetActive(true);
        } else {
            _O.SetActive(true);
            _X.SetActive(false);
        }
    }

}
