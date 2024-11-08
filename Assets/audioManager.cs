using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioSource player;
    private string currentLoop = "";
    [Range(0f, 1f)] public float loopAudio;
    [SerializedDictionary("SFXName", "SFX")]
    public SerializedDictionary<string, SFX> sfxSources;

    [SerializedDictionary("LoopName", "Loop")]
    public SerializedDictionary<string, MusicLoop> loopSources;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        LoadSFX();
        LoadLoops();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSFX()
    {
        foreach (var item in sfxSources)
        {
            item.Value.source = gameObject.AddComponent<AudioSource>();
            item.Value.source.clip = item.Value.clip;
            item.Value.source.volume = item.Value.volume;
        }
    }

    public void LoadLoops()
    {
        foreach (var item in loopSources)
        {
            item.Value.source = gameObject.AddComponent<AudioSource>();
            item.Value.source.clip = item.Value.clip;
            item.Value.source.volume = loopAudio;
            item.Value.PlayBackground();
        }
    }

    public void PlaySFX(string sfx)
    {
        sfxSources[sfx].PlaySFX();
    }

    public void StopLoop()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void PlayLoop(AudioClip newTrack)
    {
        StopLoop();
        audioSource.clip = newTrack;
        audioSource.Play();
    }

    public void ChangeTrack(string newTrack)
    {
        if (loopSources[newTrack] != null)
        {
            StartCoroutine(FadeTracks(newTrack));
        }
    }

    public IEnumerator FadeTracks(string newTrack)
    {

        if (currentLoop != null && currentLoop != "")
        {
            yield return StartCoroutine(ReduceVolOnLoop(0.030f));
            loopSources[currentLoop].StopLoop();
        }
        currentLoop = newTrack;
        loopSources[currentLoop].PlayLoop();
        yield return StartCoroutine(IncreaseVolOnLoop(0.050f));
    }

    public IEnumerator ReduceVolOnLoop(float rate)
    {
        while(loopSources[currentLoop].source.volume > 0)
        {
            loopSources[currentLoop].source.volume -= rate * Time.deltaTime;
            if (Mathf.Abs(loopSources[currentLoop].source.volume - 0.0f) < 0.001)
            {
                loopSources[currentLoop].source.volume = 0.0f;
            }
            yield return null;
        }
        yield break;
    }

    public IEnumerator IncreaseVolOnLoop(float rate)
    {
        while (loopSources[currentLoop].source.volume < loopAudio)
        {
            loopSources[currentLoop].source.volume += rate * Time.deltaTime;
            if (Mathf.Abs(loopSources[currentLoop].source.volume - 0.1f) < 0.001)
            {
                loopSources[currentLoop].source.volume = loopAudio;
            }
            yield return null;
        }
        yield break;
    }
}
