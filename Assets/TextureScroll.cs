using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour {

    public float scrollSpeed = 1.0f;
    private float scrollPosition = 0.0f;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        scrollPosition += scrollSpeed * Time.deltaTime;
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(scrollPosition, 0));
	}
}
