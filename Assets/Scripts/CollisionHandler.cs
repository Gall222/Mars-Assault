using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float lvlLoadDelay = 2f;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        Invoke("ReloadScene", 1f);
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
