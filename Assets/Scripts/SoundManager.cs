using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip Music;
    public AudioClip Jump;
    public AudioClip PlaceNode;
    public AudioClip DeleteNode;
    public AudioClip PickItem;
    public AudioClip BigNode;
    public AudioClip Ouch;
    public AudioClip MusicCredits;
    
    public AudioSource audioData;

    private void Start()
    {
        instance = this;
    }
}
