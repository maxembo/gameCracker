using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject startGame;
    
    private GameObject currentGame;

    private void Start()
    {
            startGame.SetActive(true);
            currentGame = startGame;
    }

    public void PlayGame(GameObject play)
    {
        if (currentGame != null)
        {
            currentGame.SetActive(false);
            play.SetActive(true);
            currentGame = play;
        }
    }
    
    public void MenuGame(GameObject author)
    {
        if (currentGame != null)
        {
            currentGame.SetActive(false);
            author.SetActive(true);
            currentGame = author;
        }
    }
    
    public void HistoryClick(GameObject history)
    {
        if (currentGame != null)
        {
            currentGame.SetActive(false);
            history.SetActive(true);
            currentGame = history;
        }
    }
}
