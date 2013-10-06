using UnityEngine;
using System.Collections;

public class PlayAttachedAudio : MonoBehaviour
{
    public AudioSource source;
    void Start()
    {

        audio.Play(source);
    }
}
