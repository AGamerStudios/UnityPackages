using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Determines if audio source will self destruct")]
    public bool selfDestruct = true;
    protected float lifeTime, startTime;
    
    void Start()
    {
        SetEntityName();
        SetStartTime();
        SetSourceLifeTime();
        GetComponent<AudioSource>().Play();
    }
    void Update()
    {
        if(selfDestruct){
            DestroyOnEndOfLifetime();
        }
    }

    protected void SetEntityName()
    {
        gameObject.name = GetComponent<AudioSource>().clip.name;
    }
    protected void SetStartTime()
    {
        startTime = Time.time;
    }
    protected void SetSourceLifeTime()
    {
        lifeTime = GetComponent<AudioSource>().clip.length;
    }
    protected void DestroyOnEndOfLifetime()
    {
        if (Time.time - startTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
