using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour {

    public bool isEnabled;

    public Sprite normal;
    public Sprite splatted;
    private float time = -5f;
    private Vector3 target;
    public SpriteRenderer rend;
    private Collision2D coll;
    private float throwOrigin;

	// Use this for initialization
	void Start () {
        rend = gameObject.GetComponent<SpriteRenderer>();
        
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime * 2f;

        if (time > -2f)
        {
            if (time < 0f)
            {
                transform.position -= new Vector3(0, Time.deltaTime, 0);

                if (time < -0.5f)
                {
                    rend.color -= new Color(0, 0, 0, Time.deltaTime * 2f);
                }

                isEnabled = time > -0.25f;
            }
            else if (time < 1f)
            {
                rend.color = Color.white;
                transform.localScale = new Vector3(1f, 1f, 1f) * Mathf.Lerp(4f, 20f, time);
                transform.position = new Vector3(Mathf.Lerp(target.x, target.x + throwOrigin, time), Mathf.LerpUnclamped(target.y, -5, 4 * time * time - 3 * time), 0f);
            }
        }
	}

    public void Throw(Vector3 target)
    {
        rend.sprite = normal;
        time = 1f;
        this.target = target;
        throwOrigin = Random.Range(5f, 10f) * (Random.Range(0, 2) * 2 - 1);
    }
}
