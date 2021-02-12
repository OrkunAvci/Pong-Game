﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash_Screen : MonoBehaviour
{
    public string nextScene;

    public int secsToWait;

    void Start()
    {
        Invoke("OpenNextScene", secsToWait);
    }

    void OpenNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    //void Update() {   }
}
