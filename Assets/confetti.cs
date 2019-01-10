using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confetti : MonoBehaviour {

    private bool blown;
    private float timeSinceBlow;
    private GameObject[] pieces;

    public int numPieces = 100;
    public float speed = 100f;
    public float timeLimit = 5f;

    private float baseSpeed;

	// Use this for initialization
	void Start () {
        blown = false;
        timeSinceBlow = 0f;
        pieces = new GameObject[numPieces];
        baseSpeed = 0.5f * speed;
	}
	
	// Update is called once per frame
	void Update () {


        if (blown)
        {
            if(timeSinceBlow > timeLimit)
            {
                for (int i = 0; i < numPieces; i++)
                {
                    GameObject piece = (GameObject) pieces[i];
                    Destroy(piece);
                }
            }
            timeSinceBlow += Time.deltaTime;
        }

		
	}

    public void explode()
    {
        for (int i = 0; i < numPieces; i++)
        {
            GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
            piece.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            piece.transform.position = transform.position;

            piece.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(Random.value, Random.value, Random.value));

            Rigidbody rb = piece.AddComponent<Rigidbody>();
            rb.useGravity = true;

            rb.detectCollisions = false;

            Vector3 randForce = new Vector3(1f - Random.value * 2f,
                                            1f - Random.value * 2f,
                                            1f - Random.value * 2f);
            //randForce.x += randForce.x / Mathf.Abs(randForce.x) * baseSpeed;
            //randForce.y += randForce.y / Mathf.Abs(randForce.y) * baseSpeed;
            //randForce.y += baseSpeed;
            //randForce.z += randForce.z / Mathf.Abs(randForce.z) * baseSpeed;

            rb.AddForce(speed * randForce);

            pieces[i] = piece;
        }
        blown = true;
    }
}
