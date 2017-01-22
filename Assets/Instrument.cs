using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Instrument : MonoBehaviour {

    public AudioSource goodAudioSource;
    public AudioSource badAudioSource;
    public CanvasManager canvas;
    public AudioClip[] boos;

    public float health;
    float randDetoriation;
    TextMesh text;
    public bool det = false;
    Renderer rend;

    private float recovery;
    private int timesDeteriorated;
    private AudioSource boosSource;
    private float timeForNextBoo;

	// Use this for initialization
	void Start () {
        text = transform.GetChild(0).GetChild(0).GetComponent<TextMesh>();
        rend = transform.GetChild(0).GetComponent<Renderer>();
        boosSource = gameObject.AddComponent<AudioSource>();
	}

    void Det()
    {
        det = true;
        timesDeteriorated++;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameState.Paused) return;

        text.text = "" + health.ToString("F2");

        if (health >= 50)
        {
            goodAudioSource.volume = 1;
            badAudioSource.volume = 0;
        }
        else
        {
            goodAudioSource.volume = 0;
            badAudioSource.volume = 1;
        }

        // Fix instrument
        float partialRecovery = recovery * Mathf.Min(Time.deltaTime * 5f, 1);
        recovery -= partialRecovery;
        if (health < 100f && health + partialRecovery >= 100f)
        {
            det = false;
            randDetoriation = Random.Range(2f, 3.5f);
            Invoke("Det", Random.Range(3f, Mathf.Clamp(8f - timesDeteriorated, 4f, 100f)));
            recovery = 0f;
        }
        health += partialRecovery;
        if (health > 100f)
            health = 100f;

        if (det) //if instrumet has started detoriating, det by randDetoriation (set in Start());
        {
            health -= Time.deltaTime * randDetoriation * (1 + timesDeteriorated * 0.45f);
            if (health < 0f)
                health = 0f;
        }
        else
        {
            health = 100f;
        }

        // Handle wave texture
        if (health * 0.01f > 2f / 3f)
            rend.material.color = Color.Lerp(Color.yellow, Color.green, Mathf.InverseLerp(2f / 3f, 1f, health * 0.01f));
        else
            rend.material.color = Color.Lerp(Color.red, Color.yellow, Mathf.InverseLerp(0f, 2f / 3f, health * 0.01f));
        rend.material.SetTextureScale("_MainTex", new Vector2(2f - health * 0.01f, Mathf.Lerp(0.75f, 1.35f, health * 0.01f)));
        Vector2 offset = rend.material.GetTextureOffset("_MainTex");
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset.x + Time.deltaTime * (2.5f - health * 0.02f), Mathf.Lerp(0.125f, -0.185f, health * 0.01f)));
        transform.GetChild(0).GetChild(1).GetComponent<Renderer>().material.color = rend.material.color;

        // Update score
        GameState.Score += Time.deltaTime * Mathf.Clamp01(health * 0.0125f - 0.25f);

        // Boo sounds
        if (timeForNextBoo > 0)
            timeForNextBoo -= Time.deltaTime;
        if (health <= 25f)
        {
            if (timeForNextBoo <= 0f && boos.Length > 0 && !boosSource.isPlaying)
            {
                boosSource.clip = boos[Random.Range(0, boos.Length)];
                boosSource.Play();
                timeForNextBoo = Random.Range(4f, 10f);
            }
        }
        else
            timeForNextBoo = 0f;
    }

    public void Fix()
    {
        recovery += 20f;
    }

    public void Init(AudioClip good, AudioClip bad, float delay)
    {
        if (!good || !bad) return;

        goodAudioSource.clip = good;
        badAudioSource.clip = bad;
        goodAudioSource.Play();
        badAudioSource.Play();
        Invoke("Finish", good.length);

        //how much time until an instrument starts detoriating
        health = 100f;
        det = false;
        Invoke("Det", delay);
        Debug.Log(delay);
        randDetoriation = Random.Range(3.5f, 5f);
        timesDeteriorated = 0;
        recovery = 0f;
    }

    private void Finish()
    {
        canvas.time = 0f;
    }
}
