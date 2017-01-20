using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Instrument : MonoBehaviour {

    public float health;
    float randDetoriation;
    TextMesh text;
    bool det = false;
    public bool beingFixed = false;
    public bool fullyFixed = false;

    private int timesDeteriorated;
     
	// Use this for initialization
	void Start () {

        randDetoriation = Random.Range(0.8f, 3f);
        text = transform.GetChild(0).GetChild(0).GetComponent<TextMesh>();

        //how much time until an instrument starts detoriating
        det = false;
        Invoke("Det", Random.Range(3f, Mathf.Clamp(14f - timesDeteriorated, 4f, 100f)));
	}

    void Det()
    {
        det = true;
        timesDeteriorated++;
    }
	
	// Update is called once per frame
	void Update () {

        text.text = "" + health.ToString("F2");

        if (det) //if instrumet has started detoriating, det by randDetoriation (set in Start());
        {
            if (health > 0)
            {
                health -= Time.deltaTime * randDetoriation * (1 + timesDeteriorated);
            }
        }

        if (fullyFixed)
        {
            health = 100;
            Invoke("Start", 0);
            fullyFixed = false;
        }
	
	}
}
