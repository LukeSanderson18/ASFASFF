using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title : MonoBehaviour {

    bool showInstructions, gameStarted;
    float time;

	void Update () {

        if (Input.anyKeyDown && time == 0f)
        {
            showInstructions = true;
        }
        if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Fix")) && time >= 1f && !gameStarted)
        {
            gameStarted = true;
            Invoke("StartGame", 0.75f);
        }

        if ((showInstructions || gameStarted) && true) {
            time += Time.deltaTime;

            float outfloat = gameStarted ? 24 : 14.5f;
            transform.position = new Vector3(transform.position.x, 
                Mathf.Lerp(transform.position.y, outfloat, Time.deltaTime * 3), -1.08f);

            //Debug.Log(time);
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
