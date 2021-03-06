﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThisIsAScript : MonoBehaviour
{
    [SerializeField] GameObject _Pink;
    [SerializeField] GameObject _Blue;
    [SerializeField] GameObject _Yellow;
    [SerializeField] GameObject _Yellow2;

    void Start()
    {
        _Pink.gameObject.SetActive(false);
        _Blue.gameObject.SetActive(false); 
        _Yellow.gameObject.SetActive(false);
        _Yellow2.gameObject.SetActive(false);
    }
    public void SetBlueTrue()
    {
        _Blue.SetActive(true); //set true if otherways. 
    }
    public void SetPinkTrue()
    {
        _Pink.SetActive(true); //set true if otherways. 
    }
    public void SetYellowTrue()
    {
        _Yellow2.SetActive(true);
        _Yellow.SetActive(true); //set true if otherways. 
    }
}
