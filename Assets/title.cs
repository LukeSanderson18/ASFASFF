using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title : MonoBehaviour {

    float outfloat = 12;
    float infloat = 3.5f;
    bool gameStarted;
	
	
	void Update () {

        if (Input.anyKeyDown)
        {
            gameStarted = true;
        }
        if (gameStarted)
        {
            transform.position = new Vector3(transform.position.x, 
                Mathf.Lerp(transform.position.y, outfloat, Time.deltaTime * 3), -1.08f);
            Invoke("StartTing", 1);
        }
		
	}

    void StartTing()
    {
        GameObject.Find("Curtains").GetComponent<CurtainManager>().open = true;
    }
}
