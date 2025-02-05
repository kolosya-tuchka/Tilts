﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerControls3D : MonoBehaviour
{
    MazeGameManager manager;
    public ParticleSystem firework;
    public ParticleSystem boom, trail;

    private void Start()
    {
        manager =  FindObjectOfType<MazeGameManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bomb") && manager.gameState != GameManager.GameState.gameOver)
        {
            boom.transform.position = transform.position;
            boom.Play();
            Destroy(other.gameObject);
            manager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money") && manager.gameState != GameManager.GameState.gameOver)
        {
            firework.transform.position = transform.position;
            firework.Play();
            manager.money++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Finish") && manager.gameState != GameManager.GameState.gameOver)
        {
            manager.score += manager.levelScore;
            if (trail != null) trail.Clear();
            manager.gameState = GameManager.GameState.nextLevel;
        }
    }
}