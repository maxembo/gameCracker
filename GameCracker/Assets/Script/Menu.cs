using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject startGame;
    [SerializeField] private GameObject playGame;
    [SerializeField] private GameObject authorGame;
    [SerializeField] private GameObject historyGame;
 

    private GameObject currentGame;

    private void Start()
    {
            startGame.SetActive(true);
            currentGame = startGame;
    }
    public void PlayGame(GameObject play)
    {
        currentGame.SetActive(false);
        play.SetActive(true);
        currentGame = play;
    }
    public void MenuGame(GameObject author)
    {
        currentGame.SetActive(false);
        author.SetActive(true);
        currentGame = author;
    }
    public void HistoryClick(GameObject history)
    {
        currentGame.SetActive(false);
        history.SetActive(true);
        currentGame = history;
    }
}
