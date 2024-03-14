using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlanetMovement : MonoBehaviour {
    public Transform target;
    public float speed;
    public float radius;
    public float angle = 0f;
    public float startLocX;
    public float startLocY;
    public float scale;
    public float rotation;

    private void Start() {
        GetRandomValues();
    }

    // Update is called once per frame
    void Update() {
        // Here add function to set a scale for a random planet.
        float x = startLocX + Mathf.Cos(angle) * radius;
        float y = startLocY + Mathf.Sin(angle) * radius;
        transform.position = new Vector3(x, y, 0);
        transform.rotation = Quaternion.Euler(0, 0, rotation + angle * 20);
        angle += speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R)){
            GetRandomValues();
        }
    }

    void GetRandomValues() {
        startLocX = Random.Range(-10f, 10f);
        startLocY = Random.Range(-6f, 6f);
        radius = Random.Range(1f, 5f);
        speed = Random.Range(0.25f, 1.5f);
        scale = Random.Range(0.1f, 0.6f);
        rotation = Random.Range(0f, 360f);
        transform.localScale = new Vector3(scale, scale, 0);
    }
}
