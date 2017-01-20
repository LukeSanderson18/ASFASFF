using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float movementSpeed = 1.0f;
    public float jumpSpeed = 20f;
    Rigidbody2D rb;
    public GameObject topFloor;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
        float dx = Input.GetAxis("Horizontal");
        if (dx != 0.0f)
        {
            gameObject.transform.Translate(dx * movementSpeed * Time.deltaTime, 0, 0);
        }

        //such lazy floor """""detection"""""
        if (transform.position.y < -3.17)               //on bottom layer
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * jumpSpeed);
                topFloor.SetActive(true);
            }
        }

        if (transform.position.y > -0.26)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * (jumpSpeed * 0.2f));
                topFloor.SetActive(false);
            }
        }
        if (transform.position.y < 0.2f)
        {
            topFloor.SetActive(true);
        }
	}
}
