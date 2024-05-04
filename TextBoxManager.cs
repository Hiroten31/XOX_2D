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
    }

    public void StartTextBox(string msg) {
        index = 0;
        StartCoroutine(TypeLine(msg));
    }

    public IEnumerator TypeLine(string msg) {
        foreach (char c in msg.ToCharArray()) {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void Update() {
        
    }
}
