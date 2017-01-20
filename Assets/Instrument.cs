using UnityEngine;
using System.Collections;

public class Instrument : MonoBehaviour {

    public float health;
    float randDetoriation;
	// Use this for initialization
	void Start () {

        randDetoriation = Random.Range(2f, 10f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
