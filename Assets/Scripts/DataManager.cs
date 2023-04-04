using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager ins;
    [HideInInspector]
    public int score;
    [HideInInspector]
    public int highScore;
    [HideInInspector]
    public int level;
    [HideInInspector]
    public int target;
    [HideInInspector]
    public int coin;

    private const string score_key = "score_key";
    private const string high_score_key = "high_score_key";
    private const string level_key = "level_key";
    private const string target_key = "target_key";
    private const string coin_key = "coin_key";


    private void Awake()
    {
        if (ins != null)
        {
            Destroy(gameObject);
        }
        else
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadData();
    }

    public void LoadData()
    {
        LoadScore();
        LoadHighScore();
        LoadLevel();
        LoadTarget();
        LoadCoin();
    }

    public void LoadScore()
    {
        score = PlayerPrefs.GetInt(score_key, 0);
    }

    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt(high_score_key, 0);
    }

    public void LoadLevel()
    {
        level = PlayerPrefs.GetInt(level_key, 1);
    }

    public void LoadTarget()
    {
        target = PlayerPrefs.GetInt(target_key, 1000);
    }
    public void LoadCoin()
    {
        coin = PlayerPrefs.GetInt(coin_key, 0);
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt(score_key, score);
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt(high_score_key, highScore);
    }

    public void SaveLevel()
    {
        PlayerPrefs.SetInt(level_key, level);
    }

    public void SaveTarget()
    {
        PlayerPrefs.SetInt(target_key, target);
    }
    public void SaveCoin()
    {
        PlayerPrefs.SetInt(coin_key, coin);
    }
   
    public void ResetGame()
    {
        PlayerPrefs.DeleteKey(score_key);
        PlayerPrefs.DeleteKey(level_key);
        PlayerPrefs.DeleteKey(target_key);
        PlayerPrefs.Save();
    }
}

