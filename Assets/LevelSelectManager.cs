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

            Piano.GetComponent<Instrument>().Init(goodPiano, badPiano, false);
            Trumpet.GetComponent<Instrument>().Init(goodTrumpet, badTrumpet, false);
            Violin.GetComponent<Instrument>().Init(goodViolin, badViolin, false);
            Tuba.GetComponent<Instrument>().Init(goodTuba, badTuba, false);
            if (drumsOnThisTrack)
            {
                Drum.GetComponent<Instrument>().Init(goodDrum, goodDrum, false); //DRUMS CAN ONLY BE GOOD!!!!
            }

            clicked = 0;
            GameState.Paused = false;
        }


    }

    void Update()
    {
        if (clicked>=0)
        {
            clicked += Time.deltaTime;
            GameState.Paused = false;
        }
        if(clicked > 1)
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
