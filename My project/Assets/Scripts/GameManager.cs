using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;

    private bool isGameover;
    void Start()
    {
        isGameover = false;    
    }

    public void EndGame()
    {
        isGameover=true;
        gameoverText.SetActive(true);       
    }
}
