using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class PlanetMovement : MonoBehaviour {

    public Transform target;
    public Transform firstAnchor;
    public Transform secondAnchor;
    public float speed;
    public float radius;
    public float angle = 0f;
    public float scale;
    public float rotation;

    //Two anchor point?
    //First: randomly placed in visible area
    //Second: randomly placed in not visible area + random scale futher from closest border
    //Radius = distance between first and second
    //Angle = set to opposite side of second anchor
    //Speed = random
    //Spawn every ## seconds
    //Despawn after reaching Second anchor.
    public float firstAnchorX;
    public float firstAnchorY;

    public float secondAnchorX;
    public float secondAnchorY;

    //Location based on two randomly got anchor points
    public float startLocX;
    public float startLocY;


    //Set Anchor of a planet outside the visible area
    //Set radius based on anchor point distance from border and scale of planet
    //Speed and scale can be random
    void GetRandomValues() {
        //Random scale is need to properly calculate secondAnchor coordinates.
        scale = Random.Range(0.1f, 0.8f);
        transform.localScale = new Vector3(scale, scale, 0);
        firstAnchorX = Random.Range(-7f, 7f);
        firstAnchorY = Random.Range(-4f, 4f);

        //0.1 scale takes up around 1 square of coordinates
        float planetSize = scale * 10;

        //Making second anchor out of visible area
        do {
            secondAnchorX = Random.Range(-14f, 14f);
        } while (secondAnchorX > (-9) && secondAnchorX < (9));

        do {
            secondAnchorY = Random.Range(-11f, 11f);
        } while (secondAnchorY > (-5) && secondAnchorY < (5));

        firstAnchor.transform.position = new Vector3(firstAnchorX, firstAnchorY, 0);
        secondAnchor.transform.position = new Vector3(secondAnchorX, secondAnchorY, 0);

        //Random
        speed = Random.Range(0.08f, 0.5f);
        rotation = Random.Range(0f, 360f);

        //Taking the middle between two anchors
        radius = Mathf.Sqrt(Mathf.Pow(secondAnchorX - firstAnchorX, 2) + Mathf.Pow(secondAnchorY - firstAnchorY, 2));
        radius /= 2;
        //Start location is between the two points
        startLocX = (secondAnchorX + firstAnchorX) / 2;
        startLocY = (secondAnchorY + firstAnchorY) / 2;
        //Angle set to start from secondAnchor.
        /*firstVector = new(firstAnchorX, firstAnchorY);
        secondVector = new(secondAnchorX, secondAnchorY);
        //angle = Vector2.Angle(secondVector, firstVector);
        angle = Mathf.Atan2(firstVector.x, secondVector.y);
        Debug.Log("angle = " + angle);*/

        angle = 0f;
    }

    private void Start() {
        GetRandomValues();
    }

    // Update is called once per frame
    void Update() {
        // A methods to make planet properly move around.
        float x = startLocX + Mathf.Cos(angle) * radius;
        float y = startLocY + Mathf.Sin(angle) * radius;
        transform.SetPositionAndRotation(new Vector3(x, y, 0), Quaternion.Euler(0, 0, rotation + angle * 20));
        angle += speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R)){
            GetRandomValues();
        }
    }
}
