using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxManager : MonoBehaviour {

    public TextMeshProUGUI text;
    public float textSpeed;

    public void EmptyTextBox() {
        StopAllCoroutines();
        text.text = string.Empty;
    }

    public void StartTextBox(string msg) {
        StartCoroutine(TypeLine(msg));
    }

    public IEnumerator TypeLine(string msg) {
        foreach (char c in msg) {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        text.text += "\n";
    }

}
