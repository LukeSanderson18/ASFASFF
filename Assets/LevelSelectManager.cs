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

            int autostart = Random.Range(0, 5);
            Piano.GetComponent<Instrument>().Init(goodPiano, badPiano);
            Trumpet.GetComponent<Instrument>().Init(goodTrumpet, badTrumpet);
            Violin.GetComponent<Instrument>().Init(goodViolin, badViolin);
            Tuba.GetComponent<Instrument>().Init(goodTuba, badTuba);
            Drum.GetComponent<Instrument>().Init(goodDrum, goodDrum);

            clicked = 0;
            GameState.Paused = false;
            GameState.Score = 0;
        }
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
