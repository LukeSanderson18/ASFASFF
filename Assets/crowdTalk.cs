using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowdTalk : MonoBehaviour {

	AudioSource aud;

    void Start()
    {
        aud = GetComponent<AudioSource>();
    }
	// Update is called once per frame
	void Update () {

        if (GameState.Paused)
        {
            aud.volume = Mathf.Lerp(aud.volume, 0.8f, Time.deltaTime);
        }
        else
        {
            aud.volume = Mathf.Lerp(aud.volume, 0, Time.deltaTime);
        }

		
	}
}
