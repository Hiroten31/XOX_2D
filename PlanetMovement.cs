using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class PlanetMovement : MonoBehaviour {

    /// <summary>
    /// Our object (planet) that will move around in background.
    /// </summary>
    public Transform target;

    // Vectors to correctly set the center of gravity.
    Vector2 firstAnchor;
    Vector2 centerAnchor;
    Vector2 secondAnchor;

    // Random values in reasonable ranges.
    float speed;
    float radius;
    float scale;
    float rotation;

    // Variable that controls at which point of trajectory our planet is.
    float angle;
    Vector3 startPosition;

    // Method to get a new set of values for our object.
    void GetNewSetOfValues() {
        // Random values.
        speed = Random.Range(0.08f, 0.5f);
        rotation = Random.Range(0f, 360f);

        // Value of object size (scale).
        scale = Random.Range(0.1f, 0.8f);

        // Planet of 0.1 scale is taking up 1 square, so 0.5 in every direction from the center.
        float planetSize = scale * 5;

        // Setting firstAnchor in visible range exluding borders.
        firstAnchor.x = Random.Range(-7f, 7f);
        firstAnchor.y = Random.Range(-4f, 4f);

        // Setting secondAnchor in non-visible range including planetSize.
        do {
            secondAnchor.x = Random.Range(-16f - planetSize, 16f + planetSize);
            secondAnchor.y = Random.Range(-13.5f - planetSize, 13.5f + planetSize);
        } while ((secondAnchor.x > (-11 - planetSize) && secondAnchor.x < (11 + planetSize)) && (secondAnchor.y > (-7.5f - planetSize) && secondAnchor.y < (7.5f + planetSize)));

        // Calculating the middle point between our two anchors.
        centerAnchor.x = (secondAnchor.x + firstAnchor.x) / 2;
        centerAnchor.y = (secondAnchor.y + firstAnchor.y) / 2;

        // Getting radius from our given anchors.
        radius = Mathf.Sqrt(Mathf.Pow(secondAnchor.x - firstAnchor.x, 2) + Mathf.Pow(secondAnchor.y - firstAnchor.y, 2));
        radius /= 2;

        // Setting angle to proper value to make it exactly at secondAnchor coordinates (off-screen).
        angle = Mathf.Acos((secondAnchor.x - centerAnchor.x) / radius);
        Debug.Log("Start Position: " + startPosition);
        if (secondAnchor.y < 0) {
            angle = -1 * angle;
        }

        // Making scale as last to avoid fliching size in visible area.
        transform.localScale = new Vector2(scale, scale);
        //startPosition = new Vector3(centerAnchor.x + Mathf.Cos(angle) * radius, centerAnchor.y + Mathf.Sin(angle) * radius, transform.position.z);
    }

    private void Start() {
        GetNewSetOfValues();
    }

    void Update() {
        // Using cos() and sin() methods to make planet properly move around in circle.
        float x = centerAnchor.x + Mathf.Cos(angle) * radius;
        float y = centerAnchor.y + Mathf.Sin(angle) * radius;
        transform.SetPositionAndRotation(new Vector3(x, y, transform.position.z), Quaternion.Euler(0, 0, rotation + angle * 20));
        angle += speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R)){
            GetNewSetOfValues();
        }
        if((transform.position - startPosition).sqrMagnitude <= 0.000001f) {
            GetNewSetOfValues();
        }
    }
}
