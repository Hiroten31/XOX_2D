using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChange : MonoBehaviour {

    // And done with a list!
    [SerializeField] List<Sprite> mySprites = new List<Sprite>();

    public Sprite mySprite;
    public float timeToFade;
    private bool change = false;

    private Color FadeOut;
    private Color FadeIn;
    private SpriteRenderer spriteToFadeOut;
    private SpriteRenderer spriteToFadeIn;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TextureFade();
        }
        if(change) {
            FadeOut.a -= Time.deltaTime * timeToFade;
            spriteToFadeOut.color = FadeOut;
            FadeIn.a += Time.deltaTime * timeToFade;
            spriteToFadeIn.color = FadeIn;
            if (FadeIn.a == 1 && FadeOut.a == 0) {
                change = false;
            }
        }
    }
    
    void TextureFade() {
        change = true;
        int random;
        do {
            random = Random.Range(0, mySprites.Count);
        } while (mySprites[random] == GetComponent<SpriteRenderer>().sprite);
        SpriteRenderer spriteToFadeOut = GetComponent<SpriteRenderer>();
        Color FadeOut = spriteToFadeOut.color;
        GetComponent<SpriteRenderer>().sprite = mySprites[random];
        SpriteRenderer spriteToFadeIn = GetComponent<SpriteRenderer>();
        Color FadeIn = spriteToFadeIn.color;
        GetComponent<SpriteRenderer>().sprite = spriteToFadeOut.sprite;
    }
}
