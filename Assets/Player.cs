using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float movementSpeed = 1.0f;
    public float jumpSpeed = 20f;
    public GameObject topFloor;
    public new Camera camera;
    public Tomato tomato;
    public float cameraZoomSpeed = 1.0f;
    
    private SpriteRenderer spr;
    private Rigidbody2D rb;
    private Instrument isBelowInstrument = null;
    private bool isOnTopFloor = false;
    private Vector3 cameraDefaultPosition;
    private float cameraDefaultSize;
    private float cameraLerpPosition;
    private bool isZoomed;
    private bool isSpotted;
    private bool justThrewTomato;
    private float justHitByTomato;
    Animator anim;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        cameraDefaultPosition = camera.transform.position;
        cameraDefaultSize = camera.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
        float dx = Input.GetAxis("Horizontal");

        if (!GameState.Paused) {
            // Arrow
            if (isBelowInstrument && !isOnTopFloor)
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }

            // Look at / flip
            if (!isOnTopFloor || !isBelowInstrument)
            {
                if (dx > 0.1f)
                {
                    spr.flipX = false;
                }
                else if (dx < -0.1f)
                {
                    spr.flipX = true;
                }

            }
            else
            {
                if (isBelowInstrument.transform.position.x < transform.position.x)
                {
                    spr.flipX = true;
                }
                else
                {
                    spr.flipX = false;
                }
            }
        }
        
        //simple player animations...
        if (!GameState.Paused && rb.velocity.y == 0 && dx != 0 && !isOnTopFloor)
        {
            anim.Play("Walk");
        }
        else if (GameState.Paused || rb.velocity.y == 0)
        {
            anim.Play("Idle");
        }
        else if (justHitByTomato <= 0f)
        {
            anim.Play("Jump");
        }
        else
        {
            anim.Play("Hit");
        }

        //such lazy floor """""detection"""""
        if (rb.velocity.y == 0.0f)
        {
            if (transform.position.y < -3.17f && isBelowInstrument && !isOnTopFloor) //on bottom layer
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rb.AddForce(Vector2.up * jumpSpeed);
                    topFloor.SetActive(false);
                    isOnTopFloor = true;
                }
            }

            if (transform.position.y > -0.26f && justHitByTomato <= 0f)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rb.AddForce(Vector2.up * (jumpSpeed * 0.2f));
                    topFloor.SetActive(false);
                    isOnTopFloor = false;
                }

                if (Input.GetButtonDown("Fix") && isBelowInstrument)
                {
                    isBelowInstrument.Fix();
                }
            }
        }
        if (GameState.Paused && rb.velocity.y == 0.0f && transform.position.y > -0.26f && isOnTopFloor) // Force jump down on game paused
        {
            rb.AddForce(Vector2.up * (jumpSpeed * 0.2f));
            topFloor.SetActive(false);
            isOnTopFloor = false;
        }
        if (transform.position.y > 0.02f)
        {
            topFloor.SetActive(true);
        }

        // Move the player horizontally
        if (!GameState.Paused && dx != 0.0f && !isOnTopFloor)
        {
            gameObject.transform.Translate(dx * movementSpeed * Time.deltaTime, 0, 0);
        }

        // Camera animation
        if (isOnTopFloor && !GameState.Paused)
        {
            cameraLerpPosition = Mathf.Clamp01(cameraLerpPosition + cameraZoomSpeed * Time.deltaTime);
            camera.transform.position = new Vector3(
                    Mathf.Lerp(camera.transform.position.x, isBelowInstrument.transform.position.x, cameraZoomSpeed * Time.deltaTime),
                    Mathf.Lerp(camera.transform.position.y, isBelowInstrument.transform.position.y, cameraZoomSpeed * Time.deltaTime),
                    cameraDefaultPosition.z
                );
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 4, cameraZoomSpeed * Time.deltaTime);
        }
        else
        {
            cameraLerpPosition = Mathf.Clamp01(cameraLerpPosition - cameraZoomSpeed * Time.deltaTime);
            camera.transform.position = new Vector3(
                    Mathf.Lerp(camera.transform.position.x, cameraDefaultPosition.x, cameraZoomSpeed * Time.deltaTime),
                    Mathf.Lerp(camera.transform.position.y, cameraDefaultPosition.y, cameraZoomSpeed * Time.deltaTime),
                    cameraDefaultPosition.z
                );
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, cameraDefaultSize, cameraZoomSpeed * Time.deltaTime);
        }

        if (isOnTopFloor && isSpotted && !justThrewTomato && transform.position.y > -0.26f)
        {
            tomato.Throw(transform.position);
            justThrewTomato = true;
        }
        else if (!isOnTopFloor)
            justThrewTomato = false;

        if (justHitByTomato > 0f)
            justHitByTomato -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instrument instrument = collision.gameObject.GetComponent<Instrument>();
        if (instrument)
        {
            isBelowInstrument = instrument;
        }
        else if (collision.gameObject.GetComponent<Spotlight>())
            isSpotted = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Instrument>())
            isBelowInstrument = null;
        else if (collision.gameObject.GetComponent<Spotlight>())
            isSpotted = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GameState.Paused) return;

        Tomato tomato = collision.gameObject.GetComponent<Tomato>();
        if (tomato)
        {
            if (tomato.isEnabled && justHitByTomato <= 0f && isOnTopFloor)
            {
                justHitByTomato = 0.5f;

                rb.AddForce(Vector2.up * (jumpSpeed * 0.2f));
                topFloor.SetActive(false);
                isOnTopFloor = false;
            }
        }
    }
}
