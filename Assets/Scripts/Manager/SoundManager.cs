using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public static SoundManager Instance;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (Instance == null) Instance = this;
    }

    public void PlaySound(eSOUND soundName)
    {
        audioSource.PlayOneShot(audioClips[(int)soundName]);
    }
}

public enum eSOUND
{
    Branch,
    Stone,
    Leaf,
    CustomerIn,
    CustomerOut,
    Submit,
    Reset,
    ButtonClickETC,
    Wrong,
    End
}