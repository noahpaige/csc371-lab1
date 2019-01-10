using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float speed;

    private float randSpeed;

    private float rotation = 0f;

    private void Start()
    {
        randSpeed = speed / 2f + Random.value * speed / 2f;

        speed = speed + randSpeed;
    }
    // Update is called once per frame
    void Update () {

        rotation %= 360f;
        transform.rotation = new Quaternion(0, 0, 0, 0);

        rotation += Time.deltaTime * speed;

        transform.Rotate(45f, rotation + 45f, 45f);

        //transform.Rotate(0, Time.deltaTime * speed, Time.deltaTime * speed);
	}
}
