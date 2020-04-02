﻿using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Start()
    {
        var objs = GameObject.FindGameObjectsWithTag("GameMusic");

        if (objs.Length > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}