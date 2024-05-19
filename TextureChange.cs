using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextureChange : MonoBehaviour {

    // And done with a list!
    [SerializeField] List<Sprite> mySprites = new List<Sprite>();

    public Sprite mySprite;
    public float timeToFade;

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
                //SpriteRenderer parentSprite =_sprite.transform.parent.GetComponent<SpriteRenderer>();
                //parentSprite.sprite = _sprite.sprite;
            }
            yield return null;
        }
        _sprite.color = tempColor;
    }
}
