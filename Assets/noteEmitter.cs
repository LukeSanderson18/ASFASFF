using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteEmitter : MonoBehaviour {
    float time = 0;
    public float period = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= period)
        {
            time = 0;
            int i = transform.childCount;
            int r = Mathf.FloorToInt(Random.Range(0, i));
            transform.GetChild(r).gameObject.GetComponent<ParticleSystem>().Emit(1);
        }
	}
}
