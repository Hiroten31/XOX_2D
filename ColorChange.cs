using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.R)) {
            GetComponent<SpriteRenderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.G)) {
            GetComponent<SpriteRenderer>().material.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.B)) {
            GetComponent<SpriteRenderer>().material.color = Color.blue;
        }
    }
}
