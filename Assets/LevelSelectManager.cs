using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour {

    public AudioClip goodTrumpet;
    public AudioClip badTrumpet;
    public AudioClip goodTuba;
    public AudioClip badTuba;
    public AudioClip goodViolin;
    public AudioClip badViolin;
    public AudioClip goodPiano;
    public AudioClip badPiano;
    public AudioClip goodDrum;
    public AudioClip badDrum;

    public GameObject Piano;
    public GameObject Trumpet;
    public GameObject Violin;
    public GameObject Tuba;
    public GameObject Drum;

    public bool drumsOnThisTrack;
    float clicked = -1;

    public void OnClick()
    {
        if (GameObject.Find("Curtains").GetComponent<CurtainManager>().open)
        {
            print("clicked!");

            Invoke("InitInstruments", 1);

            clicked = 0;
            GameState.Paused = false;
            GameState.Score = 0;
        }
    }
    void InitInstruments()
    {
        float[] delays = { 0, 0, 0, 0, 0 };
        float last = 0.5f;
        for (int i = 0; i < 5; i++)
        {
            int j = Random.Range(0, 5);
            while (delays[j] != 0f)
            {
                Debug.Log("Busy: " + j);
                j = (j + 1) % 5;
            }
            delays[j] = last;
            last += Random.Range(2f, 3f);
        }

        Piano.GetComponent<Instrument>().Init(goodPiano, badPiano, delays[0]);
        Trumpet.GetComponent<Instrument>().Init(goodTrumpet, badTrumpet, delays[1]);
        Violin.GetComponent<Instrument>().Init(goodViolin, badViolin, delays[2]);
        Tuba.GetComponent<Instrument>().Init(goodTuba, badTuba, delays[3]);
        Drum.GetComponent<Instrument>().Init(goodDrum, goodDrum, delays[4]);
    }

    void Update()
    {
        if (clicked>=0)
        {
            clicked += Time.deltaTime;
            GameState.Paused = false;

        }
        if(clicked > 0.75f)
        {
            transform.parent.position = new Vector3
            (transform.parent.position.x,
            Mathf.Lerp(transform.parent.position.y, 20, Time.deltaTime * 3),
            transform.parent.position.z);
        }
       
        if (clicked > 5f)
            clicked = -1f;
    }

}
