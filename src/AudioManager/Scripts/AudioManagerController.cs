using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManagerController : MonoBehaviour
{
    public List<AudioClip> clips = new List<AudioClip>();
    public GameObject AudioSourcePrefab;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySound(string name, bool loopable = false, bool selfDestruct = true, bool modulatePitch = false, float volume = 1f)
    {
        AudioClip clip = clips.Find(item => item.name.ToLower() == name.ToLower());
        SpawnAudioSource(clip, loopable, selfDestruct, modulatePitch, volume);
    }

    public void StopSound(){
        GameObject[] audioSources = GameObject.FindGameObjectsWithTag("Audio");
        foreach(GameObject source in audioSources){
            Destroy(source);
        }

    }

    private void SpawnAudioSource(AudioClip clip, bool loopable, bool selfDestruct, bool modulatePitch, float volume)
    {
        GameObject entity = Instantiate(AudioSourcePrefab, Vector3.zero, Quaternion.identity);
        entity.transform.parent = transform;
        entity.tag = "Audio";
        SetupAudioSource(clip, loopable, selfDestruct, modulatePitch,volume, entity);

    }

    private static void SetupAudioSource(AudioClip clip, bool loopable, bool selfDestruct, bool modulatePitch,float volume, GameObject entity)
    {
        AudioSource source = entity.GetComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.loop = loopable;
        if (modulatePitch)
        {
            source.pitch = Random.Range(source.pitch - 0.25f, source.pitch + 0.25f);
        }
        entity.GetComponent<AudioSourceController>().selfDestruct = selfDestruct;
    }
}
