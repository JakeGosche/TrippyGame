﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodScript : MonoBehaviour
{
    public int podId;
    public DreamManager dreamManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        dreamManager.DisplayDream(podId);
    }
}