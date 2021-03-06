﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    #region Singleton
    public static PlayerManager instence;
    private void Awake()
    {
        instence = this;
    }

    #endregion

    public GameObject player; 
    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
