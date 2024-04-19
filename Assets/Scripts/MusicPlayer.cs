using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Music : byte
{
    none, intro, run, lose, victory
}

public class MusicPlayer : MonoBehaviour
{
    public AudioClip introMusic;
    public AudioClip runMusic;
    public AudioClip loseMusic;
    public AudioClip victoryMusic;

    public float fadeSpeed = 1.0f;
    public bool autoLoop = true;
    public AudioSource source;

    private Music nextMusic = Music.none;
    private bool musicFadeOutEnabled = false;
    private float musicVolume = 1;

    private static MusicPlayer instance;
    public static MusicPlayer Get() => instance;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    
    public void PlayMusic(Music music, bool doLoop = true)
    {
        if (!source)
            return;
        if (nextMusic == music)
            return;
        nextMusic = music;
        autoLoop = doLoop;
        PlayNextMusic();
    }


    public void PlayMusicAsNext(Music music, bool doLoop = true)
    {
        if (!source)
            return;
        if (nextMusic == music)
            return;
        nextMusic = music;
        autoLoop = doLoop;
        FadeStopMusic(true);
    }

    private void PlayNextMusic()
    {
        if (nextMusic < 0)
            return;
        AudioClip clip = GetAudioClip(nextMusic);
        if (clip == null)
            return;
        ApplyVolumeSetting();
        if (autoLoop)
            source.loop = true;
        source.clip = clip;
        source.Play();
    }

    public void FadeStopMusic(bool playNextSong)
    {
        if (!playNextSong)
            nextMusic = Music.none;
        musicFadeOutEnabled = true;
    }

    public void StopMusic(bool playNextSong)
    {
        if (!playNextSong)
            nextMusic = Music.none;
        source.Stop();
        musicFadeOutEnabled = false;
    }

    private void ApplyVolumeSetting()
    {
        source.volume = musicVolume * 0.5f;
    }

    private void Update()
    {
        if (musicFadeOutEnabled)
        {
            if (source.volume <= 0.1f)
            {
                source.Stop();
                musicFadeOutEnabled = false;
                PlayNextMusic();
            }
            else
            {
                float newVolume = source.volume - (fadeSpeed * Time.deltaTime); 
                if (newVolume < 0f)
                {
                    newVolume = 0f;
                }
                source.volume = newVolume;
            }
        }
        else
        {
            if (!source.isPlaying && nextMusic != Music.none)
                nextMusic = Music.none;
        }
    }

    public Music GetPlayingMusic()
    {
        return nextMusic;
    }

    private AudioClip GetAudioClip(Music music)
    {
        switch (music)
        {
            case Music.intro:return introMusic;
            case Music.run: return runMusic;
            case Music.lose: return loseMusic;
            case Music.victory: return victoryMusic;
        }
        return null;
    }

}
