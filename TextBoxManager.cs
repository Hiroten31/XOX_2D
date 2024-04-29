using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxManager : MonoBehaviour {

    public TextMeshProUGUI text;
    public string[] textCharacters;
    public float textSpeed;

    private int index;

    private void Start() {
        text.text = string.Empty;
        StartTextBox();
    }

    void StartTextBox() {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        foreach (char c in textCharacters[index].ToCharArray()) {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void Update() {
        
    }
}
