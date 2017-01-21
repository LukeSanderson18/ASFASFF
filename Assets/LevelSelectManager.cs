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
        Piano.GetComponent<Instrument>().good = goodPiano;
        Piano.GetComponent<Instrument>().bad = badPiano;
        Trumpet.GetComponent<Instrument>().good = goodTrumpet;
        Trumpet.GetComponent<Instrument>().bad = badTrumpet;
        Violin.GetComponent<Instrument>().good = goodViolin;
        Violin.GetComponent<Instrument>().bad = badViolin;
        Tuba.GetComponent<Instrument>().good = goodTuba;
        Tuba.GetComponent<Instrument>().bad = badTuba;
    }

}
