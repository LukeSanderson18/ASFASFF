﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Instrument : MonoBehaviour {

    public float health;
    float randDetoriation;
    TextMesh text;
    public bool det = false;
    public Texture greenHealth;
    public Texture yellowHealth;
    public Texture redHealth;
    Renderer rend;

    private int timesDeteriorated;
     
	// Use this for initialization
	void Start () {
        randDetoriation = Random.Range(0.8f, 3f);
        text = transform.GetChild(0).GetChild(0).GetComponent<TextMesh>();
        rend = transform.GetChild(0).GetComponent<Renderer>();

        //how much time until an instrument starts detoriating
        if (!det)
            Invoke("Det", Random.Range(3f, Mathf.Clamp(14f - timesDeteriorated, 4f, 100f)));
	}

    void Det()
    {
        det = true;
        timesDeteriorated++;
    }
	
	// Update is called once per frame
	void Update () {

        text.text = "" + health.ToString("F2");

        if (det) //if instrumet has started detoriating, det by randDetoriation (set in Start());
        {
            health -= Time.deltaTime * randDetoriation * (1 + timesDeteriorated);
            if (health < 0f)
                health = 0f;
        }
        else
        {
            health = 100f;
        }

        if (health >= 75)
        {
            rend.material.mainTexture = greenHealth;
        }
        else if (health > 50 && health < 75)
        {
            rend.material.mainTexture = yellowHealth;
        }
        else
        {
            rend.material.mainTexture = redHealth;
        }
	}

    public void Fix()
    {
        health += 20f;
        if (health >= 100f) // Fully fixed
        {
            det = false;
            Invoke("Start", 0);
        }
    }
}