using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlanetMovement : MonoBehaviour {


    public Transform target;
    public float speed;
    public float radius;
    public float angle = 0f;
    public float startLocX;
    public float startLocY;

    private void Start() {
        startLocX = Random.Range(-10f, 10f);
        startLocY = Random.Range(-6f, 6f);
        radius = Random.Range(1f, 5f);
        speed = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update() {
        // Here add function to set a scale for a random planet.
        /*float random = Random.Range(1f, 5f);
        transform.localScale = new Vector3(Mathf.Cos(angle), Mathf.Cos(angle), 0);*/
        float x = startLocX + Mathf.Cos(angle) * radius;
        float y = startLocY + Mathf.Sin(angle) * radius;
        transform.position = new Vector3(x, y, 0);
        transform.rotation = Quaternion.Euler(0, 0, angle * 20);
        angle += speed * Time.deltaTime;
    }
}
