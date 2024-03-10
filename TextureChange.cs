using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChange : MonoBehaviour {

    public Material myMaterial;

    // Try doing it by a list? Like, if I add one, I can add another and another and ...
    public Texture myTexture1;
    public Texture myTexture2;
    public Texture myTexture3;
    public Texture myTexture4;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            myMaterial.mainTexture = myTexture1;
            Debug.Log("KEYCODE.W!");
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            myMaterial.mainTexture = myTexture2;
            Debug.Log("KEYCODE.A!");
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            myMaterial.mainTexture = myTexture3;
            Debug.Log("KEYCODE.S!");
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            myMaterial.mainTexture = myTexture4;
            Debug.Log("KEYCODE.D!");
        }
        // It is changing material, but it doesn't show...
    }
}
