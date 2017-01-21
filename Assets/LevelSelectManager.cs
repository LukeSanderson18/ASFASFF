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

    public GameObject Piano;
    public GameObject Trumpet;
    public GameObject Violin;
    public GameObject Tuba;

    public void OnClick()
    {
        print("clicked!");

        Piano.GetComponent<Instrument>().Init(goodPiano, badPiano, false);
        Trumpet.GetComponent<Instrument>().Init(goodTrumpet, badTrumpet, false);
        Violin.GetComponent<Instrument>().Init(goodViolin, badViolin, false);
        Tuba.GetComponent<Instrument>().Init(goodTuba, badTuba, false);

        GameState.Paused = false;
    }

}
