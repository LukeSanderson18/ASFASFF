using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour {

    private float time;

	// Use this for initialization
	void Start () {
        time = Random.Range(0, Mathf.PI * 10f);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameState.Paused) return;

        time += Time.deltaTime;
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Sin(time * 0.2f) * 4f + Mathf.Sin(time * 0.5f) * 3f;
        newPosition.y = 0.5f + Mathf.Sin(time * 1.15f) * 2f;
        transform.position = newPosition;
	}
}
