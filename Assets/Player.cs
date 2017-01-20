using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float movementSpeed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float dx = Input.GetAxis("Horizontal");
        if (dx != 0.0f)
        {
            gameObject.transform.Translate(dx * movementSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Animator>().Play("JumpIn");
        }
	}
}
