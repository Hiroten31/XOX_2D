using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChange : MonoBehaviour {

    // And done with a list!
    [SerializeField] List<Sprite> mySprites = new List<Sprite>();

    public Sprite mySprite;
    public float timeToFade;
    private bool change = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            change = true;
        }
        if(change) {
            int random;
            do {
                random = Random.Range(0, mySprites.Count);
            } while (mySprites[random] == GetComponent<SpriteRenderer>().sprite);
            Debug.Log("2 Sprite name: " + GetComponent<SpriteRenderer>().sprite.name);
            Color colorSprite = GetComponent<SpriteRenderer>().color;
            colorSprite.a -= Time.deltaTime * timeToFade;
            GetComponent<SpriteRenderer>().sprite = mySprites[random];
            colorSprite = GetComponent<SpriteRenderer>().color;
            colorSprite.a += Time.deltaTime * timeToFade;
            Debug.Log("3 Sprite name: " + GetComponent<SpriteRenderer>().sprite.name);
            change = false;
        }
    }
    
    void textureChange() {
        change = true;
    }

}
