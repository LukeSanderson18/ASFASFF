using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float movementSpeed = 1.0f;
    public float jumpSpeed = 20f;
    Rigidbody2D rb;
    public GameObject topFloor;

    private GameObject isBelowInstrument = null;
    private bool isOnTopFloor = false;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
        float dx = Input.GetAxis("Horizontal");
        if (dx != 0.0f && !isOnTopFloor)
        {
            gameObject.transform.Translate(dx * movementSpeed * Time.deltaTime, 0, 0);
        }

        //such lazy floor """""detection"""""
        if (transform.position.y < -3.17f && isBelowInstrument)               //on bottom layer
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * jumpSpeed);
                topFloor.SetActive(false);
                isOnTopFloor = true;
            }
        }

        if (transform.position.y > -0.26f)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * (jumpSpeed * 0.3f));
                topFloor.SetActive(false);
                print("turn floor off");
                isOnTopFloor = false;
            }

        }
        if (transform.position.y > 0.02f)
        {
            topFloor.SetActive(true);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isBelowInstrument = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isBelowInstrument = null;
    }
}
