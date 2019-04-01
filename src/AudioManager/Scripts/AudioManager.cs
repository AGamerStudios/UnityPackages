using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> clips = new List<AudioClip>();
    public GameObject AudioSourcePrefab;

    public void PlaySound(string title, bool selfDestruct)
    {
        AudioClip clip = clips.Find(item => item.name.ToLower() == title.ToLower());
        SpawnAudioSource(clip, selfDestruct);
    }

    private void SpawnAudioSource(AudioClip clip, bool selfDestruct)
    {
        GameObject entity = Instantiate(AudioSourcePrefab, Vector3.zero, Quaternion.identity);
        entity.transform.parent = transform;
        AudioSource source = entity.GetComponent<AudioSource>();
        source.clip = clip;
        entity.GetComponent<AudioSourceController>().selfDestruct = selfDestruct;
    }
}
