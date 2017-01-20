using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camLerpTest : MonoBehaviour {

    bool zoomed;
    float outSize = 6;
    float inSize = 3;
    public Vector2 onesy;
    public Vector2 twosey;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (zoomed)
        {
            Camera.main.transform.position = new Vector3(Mathf.Lerp(Camera.main.transform.position.x, twosey.x, Time.deltaTime * 4),
                                                            Mathf.Lerp(Camera.main.transform.position.y, twosey.y, Time.deltaTime * 4),-10);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, inSize, Time.deltaTime * 4);
        }
        else
        {
            Camera.main.transform.position = new Vector3(Mathf.Lerp(Camera.main.transform.position.x, onesy.x, Time.deltaTime * 4),
                                                            Mathf.Lerp(Camera.main.transform.position.y, onesy.y, Time.deltaTime * 4),-10);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, outSize, Time.deltaTime * 4);
        }
        

        if (Input.GetKeyDown(KeyCode.B))
        {
            zoomed = !zoomed;
        }
		
	}
}
