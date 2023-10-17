using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameManager gameManager;
    public void PlayGame()
    {
        gameManager.Enable();
        Destroy(gameObject);
    }

    
}
