using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton class for running coroutines
/// </summary>
public class CoroutineRunner : MonoBehaviour
{ 
    private static CoroutineRunner instance;
    public static CoroutineRunner Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("CoroutineRunner");
                instance = go.AddComponent<CoroutineRunner>();
            }
            return instance;
        }
    }
}



