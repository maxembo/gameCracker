using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = System.Random;
using System.Linq;

public class Game : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private Text pinsText;
    

    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject game1;
    [SerializeField] private GameObject game2;
    [SerializeField] private GameObject game3;
    [SerializeField] private GameObject winGame;
   
    private int rand;
   
    private int[] pins;
    private int[] secretPins = {7,7,7};

    private float timerTime;

    private void Start()
    {
        timerTime = 100;
        RandomLevel();
    }
    /// <summary>
    /// Обратный таймер
    /// </summary>
    private void Update()
    {
        timerTime -= Time.deltaTime;
        timerText.text = Mathf.Round(timerTime).ToString();

        Win();

        GameOver();
    }
    /// <summary>
    /// Заново запустить игру
    /// </summary>
    public void ResetGame()
    {
        timerTime = 100;
        RandomLevel();

        winGame.SetActive(false);
        gameOver.SetActive(false);

        game1.SetActive(true);
        game2.SetActive(true);
        game3.SetActive(true);

    }
    /// <summary>
    /// Нажатие на дрель
    /// </summary>
    public void DrillClick()
    {
        pins[0] += 1;
        pins[1] -= 1;
        RangeArrayPins();

        pinsText.text = string.Join("  ", pins);
    }
    /// <summary>
    /// Нажатие на молоток
    /// </summary>
    public void HammerClick()
    {
   
        pins[0] -= 1;
        pins[1] += 2;
        pins[2] -= 1;
        RangeArrayPins();

        pinsText.text = string.Join("  ", pins);
    }
    /// <summary>
    /// Нажатие на отмычки
    /// </summary>
    public void MasterKeyClick()
    {
        pins[0] -= 1;
        pins[1] += 1;
        pins[2] += 1;
        RangeArrayPins();

        pinsText.text = string.Join("  ", pins);
    }
    /// <summary>
    /// Выход из игры
    /// </summary>
    public void ExitGame()
    {
        timerTime = 100;
        RandomLevel();
        winGame.SetActive(false);
        gameOver.SetActive(false);
        game1.SetActive(true);
        game2.SetActive(true);
        game3.SetActive(true);

    }
   
    /// <summary>
    ///  Диапазон 0 до 10 в массиве
    /// </summary>
    private void RangeArrayPins()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            if(pins[i] <= 0) pins[i] = 0;
            if(pins[i] >= 10) pins[i] = 10;
        }
    }
    /// <summary>
    /// Рандомные уровни - 3 уровня
    /// </summary>
    private void RandomLevel()
    {
        
        Random random = new Random();
        rand = random.Next(0, 3);
        if (rand == 0)
        {
            pins = new int[] { 8, 5, 7 };
            pinsText.text = string.Join("  ", pins);

        }
        else if (rand == 1)
        {
            pins = new int[] { 9, 4, 6 };
            pinsText.text = string.Join("  ", pins);
        }
        else if (rand == 2)
        {
            pins = new int[] { 7, 7, 6 };
            pinsText.text = string.Join("  ", pins);
        }
    }
   /// <summary>
   /// Открывает панель Победа
   /// </summary>
    private void Win()
    {
        if (pins.SequenceEqual(secretPins)) 
            {
                timerTime = 0;
                winGame.SetActive(true);
                game1.SetActive(false);
                game2.SetActive(false);
                game3.SetActive(false);
        }
    }
    /// <summary>
    /// Открывает панель Поражение
    /// </summary>
    private void GameOver()
    {
        if (timerTime <= 0)
        {
            timerTime = 0;
            gameOver.SetActive(true);
            game1.SetActive(false);
            game2.SetActive(false);
            game3.SetActive(false);
        }
    }
}
