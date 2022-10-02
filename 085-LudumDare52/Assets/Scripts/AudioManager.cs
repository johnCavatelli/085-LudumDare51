using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager current;
    public AudioSource talkSource;
    public AudioSource coinSource;
    public AudioSource coinSource1;
    
    private void Awake()
    {
        current = this;
    }

}
