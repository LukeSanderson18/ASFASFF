using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title : MonoBehaviour {

    bool showInstructions, gameStarted;
    float time;
    float timeStarted;

	void Update () {

        if (Input.anyKeyDown)
        {
            if (time == 0f)
                showInstructions = true;
            else if (time >= 1f && !gameStarted)
            {
                gameStarted = true;
                timeStarted = time;
                Invoke("StartGame", 0.75f);
            }
        }

        if ((showInstructions || gameStarted) && true) {
            time += Time.deltaTime;

            float outfloat = gameStarted ? 24 : 14.5f;
            transform.position = new Vector3(transform.position.x, 
                Mathf.Lerp(transform.position.y, outfloat, Time.deltaTime * 3), -1.08f);

            Debug.Log(time);
        }
    }

    void StartGame()
    {
        GameObject.Find("Curtains").GetComponent<CurtainManager>().open = true;
        Invoke("Stop", 1);
    }

    void Stop()
    {
        this.enabled = false;
    }
}
