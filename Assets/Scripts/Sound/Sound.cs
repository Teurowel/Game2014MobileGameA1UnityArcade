//SourceFileName : Sound.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.17, 2020
//Program description : Sound class represent one sound
//Revision History : Oct.17, 2020 Created

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
