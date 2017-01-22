using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fix"))
        {
            anim.Play("hammerHitting");
        }
        else
        {
            anim.Play("hammerIdle");
        }
		
	}
}
