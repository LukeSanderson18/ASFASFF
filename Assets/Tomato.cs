using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour {

    public bool isEnabled;

    private float time;
    private Vector3 target;
    private SpriteRenderer rend;
    private Collision2D coll;

	// Use this for initialization
	void Start () {
        rend = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime * 2f;

        if (time < 0f && time > -2f)
        {
            transform.position -= new Vector3(0, Time.deltaTime, 0);

            if (time < -0.5f)
            {
                rend.color -= new Color(0, 0, 0, Time.deltaTime * 2f);
            }

            isEnabled = time > -0.25f;
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f) * Mathf.Lerp(4f, 20f, time);
            transform.position = new Vector3(Mathf.Lerp(target.x, 0, time), Mathf.Lerp(target.y, -1, time), 0f);
        }
	}

    public void Throw(Vector3 target)
    {
        time = 1f;
        this.target = target;
        rend.color = Color.white;
    }
}
