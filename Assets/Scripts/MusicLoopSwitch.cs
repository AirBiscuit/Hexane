using UnityEngine;
using System.Collections;

public class MusicLoopSwitch : MonoBehaviour
{

    public AudioClip intro, loop;
    bool isLoop;
    void Start()
    {
        isLoop = false;
        this.GetComponent<AudioSource>().clip = intro;
        this.GetComponent<AudioSource>().loop = false;
        this.GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (!this.GetComponent<AudioSource>().isPlaying && !isLoop)
        {
            isLoop = true;
            this.GetComponent<AudioSource>().clip = loop;
            this.GetComponent<AudioSource>().loop = true;
            this.GetComponent<AudioSource>().Play();
        }
    }
}
