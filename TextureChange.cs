using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChange : MonoBehaviour {

    public Sprite mySprite1;

    // And done with a list!
    [SerializeField] List<Sprite> mySprites = new List<Sprite>();

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<SpriteRenderer>().sprite = mySprite1;
            Debug.Log("KEYCODE.SPACE!");
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            int random = Random.Range(0, mySprites.Count);
            while (mySprites[random] == GetComponent<SpriteRenderer>().sprite) {
                random = Random.Range(0, mySprites.Count);
            }
            GetComponent<SpriteRenderer>().sprite = mySprites[random];
            if(random%2  == 0) {
                GetComponent<SpriteRenderer>().flipX = true;
            } else {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (random % 3 == 0) {
                GetComponent<SpriteRenderer>().flipY = true;
            } else {
                GetComponent<SpriteRenderer>().flipY = false;
            }
            Debug.Log("KEYCODE.W! Sprite name: " + GetComponent<SpriteRenderer>().sprite.name);
        }
    }
}
