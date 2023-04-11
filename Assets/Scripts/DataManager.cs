using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    public static DataManager ins;
    public int score;
    public int highScore;
    public int level;
    public float target;
    public int coin;
    public bool start_new_game;

    public List<List<BoxType>> colorMatrix;

    private const string score_key = "score_key";
    private const string high_score_key = "high_score_key";
    private const string level_key = "level_key";
    private const string target_key = "target_key";
    private const string coin_key = "coin_key";
    private const string color_key = "color_key";
    private const string first_time_play = "first_time_play";


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

        FirstTimePlay();
    }

    public void FirstTimePlay()
    {
        if (PlayerPrefs.HasKey(first_time_play))
        {
            LoadData();
        }
        else
        {
            PlayerPrefs.SetInt(first_time_play, 0);
            StartData();
        }
    }

    public void LoadData()
    {
        LoadScore();
        LoadHighScore();
        LoadLevel();
        LoadTarget();
        LoadCoin();
        LoadJson();
    }

    public void StartData()
    {
        score = 0;
        level = 1;
        target = 1000;
        highScore = 0;
        coin = 0;
        colorMatrix = new List<List<BoxType>>();

        for (int i = 0; i < 10; i++)
        {
            List<BoxType> row = new List<BoxType>();

            for (int j = 0; j < 10; j++)
            {
                row.Add(BoxType.None);  
            }

            colorMatrix.Add(row);
        }
        SaveJson();
        SaveCoin();
        SaveScore();
        SaveLevel();
        SaveTarget();
        SaveHighScore();
    }

    public void SaveJson()
    {
        List<string> jsonsColor = new List<string>();

        for (int i = 0; i < 10; i++)
        {
            string jsonColor = JsonHelper.ToJson<BoxType>(colorMatrix[i]);
            jsonsColor.Add(jsonColor);
        }
        string finalJson = JsonHelper.ToJson<string>(jsonsColor);
        PlayerPrefs.SetString(color_key, finalJson);
    }

    public void LoadJson()
    {
        string finalJson = PlayerPrefs.GetString(color_key);

        List<string> jsonsColor = JsonHelper.FromJson<string>(finalJson);

        colorMatrix = new List<List<BoxType>>();
        for(int i = 0; i < 10; i++)
        {
            List<BoxType> row = JsonHelper.FromJson<BoxType>(jsonsColor[i]);
            colorMatrix.Add(row);
        }
    }

    public void ResetData()
    {
        score = 0;
        level = 1;
        target = 1000;
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
        PlayerPrefs.SetFloat(target_key, target);
    }
    public void SaveCoin()
    {
        PlayerPrefs.SetInt(coin_key, coin);
    }
}

