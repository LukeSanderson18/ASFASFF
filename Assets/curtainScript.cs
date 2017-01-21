using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curtainScript : MonoBehaviour {
    
    private float distance;
    float screenWidth;
    bool open = false;

	// Use this for initialization
	void Start () {
        float posx = transform.position.x;
        if (posx < 0)
        {
            screenWidth = -10.5f;// - posx / 5;
        }
        else
        {
            screenWidth = 10.5f;// + posx / 5;
        }
        distance = screenWidth - transform.position.x;
        print(distance);
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.C))
        {
            open = !open;
        }

        open = transform.parent.parent.GetComponent<CurtainManager>().open;
		
        if (open)
        {
            Open();
        }
        else
        {
            Close();
        }

    }

    void Open()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, screenWidth, Time.deltaTime * 4), transform.position.y, transform.position.z);

    }

    void Close()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, screenWidth - distance, Time.deltaTime * 4), transform.position.y, transform.position.z);

    }
}
