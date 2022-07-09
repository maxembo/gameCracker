using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = System.Random;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private Text pinsText1;
    [SerializeField] private Text pinsText2;
    [SerializeField] private Text pinsText3;

    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject game1;
    [SerializeField] private GameObject game2;
    [SerializeField] private GameObject game3;
    [SerializeField] private GameObject winGame;
    [SerializeField] private GameObject LostGame;
    

    private int pins1;
    private int pins2;
    private int pins3;
    private int rand;
    
    private float timerTime;
    void Start()
    {
        timerTime = 100;
        randomLevel();
    }
    public void ResetGame()
    {
        timerTime = 100;
        randomLevel();

        winGame.SetActive(false);
        gameOver.SetActive(false);

        game1.SetActive(true);
        game2.SetActive(true);
        game3.SetActive(true);

    }
    void Update()
    {
        timerTime -= Time.deltaTime;
        timerText.text = Mathf.Round(timerTime).ToString();
        
        if (pinsText1.text == "7" && pinsText2.text == "7" && pinsText3.text == "7")
        {
            timerTime = 0;
            winGame.SetActive(true);
            game1.SetActive(false);
            game2.SetActive(false);
            game3.SetActive(false);
        }
        
        else if (timerTime <= 0)
        {
            timerTime = 0;
            gameOver.SetActive(true);
            game1.SetActive(false);
            game2.SetActive(false);
            game3.SetActive(false);
        }
    }
    public void DrillClick()
    {
        ConvertInts();

        pins1 += 1;
        pins2 -= 1;
        RangeInt();

       ConclusInts();
    }
    public void HammerClick()
    {
        ConvertInts();

        pins1 -= 1;
        pins2 += 2;
        pins3 -= 1;
        RangeInt();

        ConclusInts();
    }
    public void MasterKeyClick()
    {
        ConvertInts();

        pins1 -= 1;
        pins2 += 1;
        pins3 += 1;
        RangeInt();

        ConclusInts();
    }
    private void ConvertInts()
    {
        pins1 = int.Parse(pinsText1.text);
        pins2 = int.Parse(pinsText2.text);
        pins3 = int.Parse(pinsText3.text);
    }
    private void ConclusInts()
    {
        pinsText1.text = pins1.ToString();
        pinsText2.text = pins2.ToString();
        pinsText3.text = pins3.ToString();
    }
    private void RangeInt()
    {
        if (pins1 >= 10) pins1 = 10;
        if (pins2 >= 10) pins2 = 10;
        if (pins3 >= 10) pins3 = 10;
       
        if (pins1 <= 0) pins1 = 0;
        if (pins2 <= 0) pins2 = 0;
        if (pins3 <= 0) pins3 = 0;
    }
    private void randomLevel()
    {
        Random random = new Random();
        rand = random.Next(0, 3);
        if (rand == 0)
        {
            pinsText1.text = "8";
            pinsText2.text = "5";
            pinsText3.text = "7";
        }
        else if (rand == 1)
        {
            pinsText1.text = "9";
            pinsText2.text = "4";
            pinsText3.text = "6";
        }
        else if (rand == 2)
        {
            pinsText1.text = "7";
            pinsText2.text = "7";
            pinsText3.text = "6";
        }
    }
    public void ExitGame()
    {
        timerTime = 100;
        randomLevel();
        winGame.SetActive(false);
        game1.SetActive(true);
        game2.SetActive(true);
        game3.SetActive(true);

    }
   public void WinGame()
    {
        gameOver.SetActive(false);
        winGame.SetActive(false);
        game1.SetActive(true);
        game2.SetActive(true);
        game3.SetActive(true);
    }
}
