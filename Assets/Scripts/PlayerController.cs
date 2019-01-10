using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private int count;

    public Text countText;
    public Text winText;

    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setText();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical   = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);

        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<Rotator>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().detectCollisions = false;

            confetti con = other.GetComponent<confetti>();
            con.explode();

            count++;
            setText();
        }
    }
    
    void setText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12) winText.text = "You Win!";
    }

}
