using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChange : MonoBehaviour {

    // Try doing it by a list? Like, if I add one, I can add another and another and ...
    public Sprite mySprite1;
    public Sprite mySprite2;
    public Sprite mySprite3;
    public Sprite mySprite4;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            GetComponent<SpriteRenderer>().sprite = mySprite1;
            Debug.Log("KEYCODE.W!");
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            GetComponent<SpriteRenderer>().sprite = mySprite2;
            Debug.Log("KEYCODE.A!");
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            GetComponent<SpriteRenderer>().sprite = mySprite3;
            Debug.Log("KEYCODE.S!");
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            GetComponent<SpriteRenderer>().sprite = mySprite4;
            Debug.Log("KEYCODE.D!");
        }
    }
}
