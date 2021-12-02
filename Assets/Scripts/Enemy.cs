using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject parent;
    [SerializeField] int points = 10;

    ScoreBoard scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        if (!GetComponent<BoxCollider>())
        {
           var boxCollider = gameObject.AddComponent<BoxCollider>();
            boxCollider.isTrigger = false;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        var fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent.transform;
        scoreBoard.AddScore(points);
        Destroy(gameObject);
    }
}
