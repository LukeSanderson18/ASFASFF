﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PitchBend : MonoBehaviour {

    
    public AudioMixer m;
    int state = 0;
    float bend = 0.05f;
	// Use this for initialization
	void Start () {
        m.SetFloat("pitch", 1);
	}
	
	// Update is called once per frame
	void Update () {
        float h = GetComponent<Instrument>().health;
        if (h > 25)
        {
            if (state != 0)
            {
                m.SetFloat("pitch", 1);
            }
            state = 0;
        }
        if (h <= 25)
        {
            if (state == 0)
            {
                float r = Random.Range(-1.0f, 1.0f);
                r = r / Mathf.Abs(r);
                if (r < 0)
                {
                    m.SetFloat("pitch", 1 + (r) * bend/2);
                }
                else
                {
                    m.SetFloat("pitch", (r) + bend);
                }
                /*float e;
                m.GetFloat("pitch", out e);
                print(e); /**/
            }
            state = 1;
        }
        /*if (h < 50)
        {
            if (state == 1)
            {
                float i;
                m.GetFloat("pitch", out i);
                m.SetFloat("pitch", i * 0.9f);
            }
            state = 2;
        }/**/
    }
}
