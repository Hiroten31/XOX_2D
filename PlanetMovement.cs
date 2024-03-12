using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour {


    public Transform target;
    public float speed = 2f;
    public float radius = 1f;
    public float angle = 0f;

    // Update is called once per frame
    void Update() {
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        transform.position = new Vector3(x, y, 0);
        angle += speed * Time.deltaTime;
    }
}
