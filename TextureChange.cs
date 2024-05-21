using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextureChange : MonoBehaviour {

    // And done with a list!
    [SerializeField] List<Sprite> mySprites = new List<Sprite>();

    public Sprite mySprite;
    public float timeToFade;
    int i = 0;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartTextureChange();
        }
    }
    void StartTextureChange() {
        StartCoroutine(TextureFadeOut(GetComponent<SpriteRenderer>()));
        int random;
        do {
            random = Random.Range(0, mySprites.Count);
        } while (mySprites[random] == GetComponent<SpriteRenderer>().sprite);
        SpriteRenderer tempSprite = Instantiate(GetComponent<SpriteRenderer>(), transform);
        tempSprite.sprite = mySprites[random];
        StartCoroutine(TextureFadeIn(tempSprite));
    }
    
    IEnumerator TextureFadeOut(SpriteRenderer _sprite) {
        Debug.Log("Started TextureFadeOut()");
        Color tempColor = _sprite.color;
        while(tempColor.a <= 1f) {
            tempColor.a -= Time.deltaTime / timeToFade;
            _sprite.color = tempColor;
            if(tempColor.a <= 0f) {
                tempColor.a = 0.0f;
                // Here my sprite is overwritten .-.
            }
            yield return null;
        }
        _sprite.color = tempColor;
    }

    IEnumerator TextureFadeIn(SpriteRenderer _sprite) {
        Debug.Log("Started TextureFadeIn()");
        Color tempColor = _sprite.color;
        _sprite.color = new Color(255, 255, 255, 0);
        //_sprite.name = "Child Sprite";
        //Debug.Log("Parent name: " + _sprite.transform.parent.name);
        while (tempColor.a >= 0f) {
            tempColor.a += Time.deltaTime / timeToFade;
            _sprite.color = tempColor;
            if (tempColor.a >= 1f) {
                tempColor.a = 1.0f;
                SpriteRenderer parentSprite = _sprite.transform.parent.GetComponent<SpriteRenderer>();
                parentSprite = _sprite;
                Color parentColor = parentSprite.color;
                parentColor.a = 1.0f;
                // Here it still takes Clone instead of Parent
                Debug.Log("Parent sprite: " + parentSprite.name + ": " + parentSprite.sprite.name + " vs Child sprite: " + _sprite.name + ": " + _sprite.sprite.name);
                StopCoroutine(TextureFadeOut(parentSprite));
            }
            yield return null;
        }
        _sprite.color = tempColor;
    }
}
