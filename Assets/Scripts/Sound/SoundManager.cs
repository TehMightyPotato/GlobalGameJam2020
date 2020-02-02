using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public float shoutoutVolume;
    public AudioSource source;
    public Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
    public List<string> shoutouts = new List<string>();

    private void Start()
    {
        var shoutouts = Resources.LoadAll<AudioClip>("Sounds/Shoutouts/");
        var sounds = Resources.LoadAll<AudioClip>("Sounds/Rest");

        foreach(var clip in shoutouts)
        {
            this.clips.Add(clip.name, clip);
            this.shoutouts.Add(clip.name);
        }
        foreach(var clip in sounds)
        {
            this.clips.Add(clip.name, clip);
        }
    }

    public void PlayRandomShoutout()
    {
        if (source.isPlaying)
        {
            return;
        }
        PlayAudioClip(shoutouts[Random.Range(0, shoutouts.Count)], shoutoutVolume);
    }

    public bool IsPlaying()
    {
        return source.isPlaying;
    }

    public void PlayAudioClip(string clipName, float volumeScale)
    {
        if (clips.ContainsKey(clipName))
        {
            source.PlayOneShot(clips[clipName], volumeScale);
        }
    }
}
