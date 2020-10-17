//SourceFileName : SoundManager.cs
//Author's name : Doosung Jang
//Studnet Number : 101175013
//Date last Modified : Oct.17, 2020
//Program description : SoundManager will manage all sounds that is needed in game
//Revision History : Oct.17, 2020 Created

//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public Sound[] listOfSounds;

    private void Awake()
    {
        //Make sure there is only one instance of SoundManager;
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Make it persist through levels
        DontDestroyOnLoad(gameObject);

        //Create AudioSource for each sound
        foreach(Sound s in listOfSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void Play(string name)
    {
        Sound foundSound = Array.Find(listOfSounds, sound => sound.name == name);
        if(foundSound != null)
        {
            foundSound.source.Play();
        }
    }

}
