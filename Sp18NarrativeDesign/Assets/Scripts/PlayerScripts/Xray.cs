﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xray : MonoBehaviour
{
    Material m_Original;
    float fadeSpeed = .5f;
    bool fading = false;
    [SerializeField]
    Material m_Xray;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    AudioSource AudioSource
    {
        get
        {
            if (audioSource == null)
            {
                audioSource = Instantiate(Resources.Load("ScannedObjectSoundSource") as GameObject, transform.position, Quaternion.identity, gameObject.transform).GetComponent<AudioSource>();
            }
            return audioSource;
        }
    }
    bool _xRayActive = false;
    void Start()
    {
        m_Original = GetComponent<Renderer>().material;
        audioClip = Resources.Load("ScanFound") as AudioClip;
        audioSource = AudioSource;
    }


    float opacity = 1;
    private void Update()
    {
        if (fading)
        {
            opacity -= fadeSpeed * Time.deltaTime;
            if (opacity >= 0)
                GetComponent<Renderer>().material.SetFloat("_Opacity", opacity);
        }
        if (opacity <= 0 && fading)
        {
            opacity -= fadeSpeed * Time.deltaTime;
            if (opacity <= -1f)
            {
                GetComponent<Renderer>().material = m_Original;
                fading = false;
                opacity = 1;
            }
        }
    }

    bool played = false;


    public virtual void ShowThroughWalls(bool doit)
    {
        if (!doit)
        {
            fading = true;
            opacity = 1;
            //  GetComponent<Renderer>().material = m_Original;
            played = false;
        }
        else
        {
            fading = false;
            opacity = 1;
            GetComponent<Renderer>().material.SetFloat("_Opacity", opacity);

            GetComponent<Renderer>().material = m_Xray;
            _xRayActive = false;
            if (audioClip != null && !played)
            {
                AudioSource.clip = audioClip;
                AudioSource.Play();
                played = true;
            }
        }
    }

}
