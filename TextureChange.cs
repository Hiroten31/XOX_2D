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
        StartCoroutine(TextureFadeOut());
        StartCoroutine(TextureFadeIn());
    }
    
    IEnumerator TextureFadeOut() {
        Debug.Log("Started TextureFadeOut()");
        SpriteRenderer _sprite = GetComponent<SpriteRenderer>();
        yield return null;
    }

    IEnumerator TextureFadeIn() {
        Debug.Log("Started TextureFadeIn()");
        int random;
        do {
            random = Random.Range(0, mySprites.Count);
        } while (mySprites[random] == GetComponent<SpriteRenderer>().sprite);
        SpriteRenderer _spriteIn = Instantiate(GetComponent<SpriteRenderer>(), transform);
        _spriteIn.sprite = mySprites[random];
        SpriteRenderer _spriteOut = _spriteIn.transform.parent.GetComponent<SpriteRenderer>();
        Debug.Log("Parent sprite " + _spriteIn.transform.parent.name + " : " + _spriteIn.transform.parent.GetComponent<SpriteRenderer>().sprite.name + ", Child sprite " + _spriteIn.name + " :" + _spriteIn.sprite.name);
        Color tempColor = _spriteOut.color;
        while (tempColor.a <= 1f && tempColor.a != 0.0f) {
            tempColor.a -= Time.deltaTime / timeToFade;
            _spriteOut.color = tempColor;
            if (tempColor.a <= 0f) {
                tempColor.a = 0.0f;
            }
            yield return null;
        }
        _spriteOut.sprite = _spriteIn.sprite;
        tempColor.a = 1.0f;
        _spriteOut.color = tempColor;
        //_sprite.name = "Child Sprite";
        //Debug.Log("Parent name: " + _sprite.transform.parent.name);
        Destroy(_spriteIn.gameObject);
        yield return null;
    }
}
