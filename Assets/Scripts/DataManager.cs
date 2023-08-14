using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Audio;
using System;

public class DataManager : MonoBehaviour
{
    public static DataManager ins;
    public int scoreClassic;
    public int scoreSurvival;
    public int highScoreClassic;
    public int highScoreSurvival;
    public int level;
    public float target;
    public int coin;
    public float currentTime;
    public float maxTime = 45f;
    public bool start_new_game_classic;
    public bool start_new_game_survival;   
    public bool ClassicGame;
    public bool classicGame;
    public bool survivalGame;
    public bool timeActive;
    public bool musicMuted = false;
    public bool sfxMuted = false;

    public List<List<BoxType>> colorMatrixClassic;
    public List<List<BoxType2>> colorMatrixSurvival;

    private const string score_classic_key = "score_classic_key";
    private const string score_survival_key = "score_survival_key";
    private const string high_score_classic_key = "high_score_classic_key";
    private const string high_score_survival_key = "high_score_survival_key";
    private const string level_key = "level_key";
    private const string target_key = "target_key";
    private const string coin_key = "coin_key";
    private const string color_classic_key = "color_classic_key";
    private const string color_survival_key = "color_survival_key";
    private const string first_time_play_classic = "first_time_play_classic";
    private const string first_time_play_survival = "first_time_play_survival";
    private const string current_time_survival = "current_time_survival";
    private const string time_key = "time_key";
    private const string music_muted_key = "music_muted_key";
    private const string sfx_muted_key = "sfx_muted_key";
  
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
        AudioUpdate();
        FirstTimePlayClassic();
        FirstTimePlaySurvival();
    }

    public void FirstTimePlayClassic()
    {
        if (PlayerPrefs.HasKey(first_time_play_classic))
        {
            LoadDataClassic();
        }
        else
        {
            PlayerPrefs.SetInt(first_time_play_classic, 0);
            StartDataClassic();
        }
    }
    public void FirstTimePlaySurvival()
    {
        if (PlayerPrefs.HasKey(first_time_play_survival))
        {
            LoadDataSurvival();
        }
        else
        {
            PlayerPrefs.SetInt(first_time_play_survival, 0);
            StartDataSurvival();
        }
    }
    public void AudioUpdate()
    {
        if (!PlayerPrefs.HasKey(music_muted_key))
        {
            PlayerPrefs.SetInt(music_muted_key, 0);
            LoadMusic();
        }
        else
        {
            LoadMusic();
        }
    }
    public void LoadDataClassic()
    {
        LoadScoreClassic();
        LoadHighScoreClassic();
        LoadLevel();
        LoadTarget();
        LoadCoin();
        LoadJsonClassic();
    }
    public void LoadDataSurvival()
    {
        LoadScoreSurvival();
        LoadHighScoreSurvival();
        LoadCoin();
        LoadJsonSurvival();
        LoadTime();
    }

    public void StartDataClassic()
    {
        scoreClassic = 0;
        level = 1;
        target = 1000;
        highScoreClassic = 0;
        coin = 1000;
        colorMatrixClassic = new List<List<BoxType>>();

        for (int i = 0; i < 10; i++)
        {
            List<BoxType> row = new List<BoxType>();

            for (int j = 0; j < 10; j++)
            {
                row.Add(BoxType.None);  
            }
            colorMatrixClassic.Add(row);
        }
        SaveJsonClassic();
        SaveCoin();
        SaveScoreClassic();
        SaveLevel();
        SaveTarget();
        SaveHighScoreClassic();
    }
    public void StartDataSurvival()
    {
        maxTime = 45f;
        currentTime = maxTime;
        scoreSurvival = 0;
        highScoreSurvival = 0;
        colorMatrixSurvival = new List<List<BoxType2>>();

        for (int i = 0; i < 12; i++)
        {
            List<BoxType2> row = new List<BoxType2>();

            for (int j = 0; j < 12; j++)
            {
                row.Add(BoxType2.None);
            }

            colorMatrixSurvival.Add(row);
        }
        SaveJsonSurvival();
        SaveCoin();
        SaveScoreSurvival();
        SaveHighScoreSurvival();
        SaveTime();
    }

    public void ResetDataClassic()
    {
        scoreClassic = 0;
        level = 1;
        target = 1000;
    }
    public void ResetDataSurvival()
    {
        maxTime = 45f;
        currentTime = maxTime;
        scoreSurvival = 0;
    }

    public void LoadJsonClassic()
    {
        string finalJson = PlayerPrefs.GetString(color_classic_key);

        List<string> jsonsColor = JsonHelper.FromJson<string>(finalJson);

        colorMatrixClassic = new List<List<BoxType>>();
        for (int i = 0; i < 10; i++)
        {
            List<BoxType> row = JsonHelper.FromJson<BoxType>(jsonsColor[i]);
            colorMatrixClassic.Add(row);
        }
    }
    public void SaveJsonClassic()
    {
        List<string> jsonsColorClassic = new List<string>();

        for (int i = 0; i < 10; i++)
        {
            string jsonColor = JsonHelper.ToJson<BoxType>(colorMatrixClassic[i]);
            jsonsColorClassic.Add(jsonColor);
        }
        string finalJson = JsonHelper.ToJson<string>(jsonsColorClassic);
        PlayerPrefs.SetString(color_classic_key, finalJson);
    }

    public void LoadJsonSurvival()
    {
        string finalJson = PlayerPrefs.GetString(color_survival_key);

        List<string> jsonsColor = JsonHelper.FromJson<string>(finalJson);

        colorMatrixSurvival = new List<List<BoxType2>>();
        for (int i = 0; i < 12; i++)
        {
            List<BoxType2> row = JsonHelper.FromJson<BoxType2>(jsonsColor[i]);
            colorMatrixSurvival.Add(row);
        }
    }
    public void SaveJsonSurvival()
    {
        List<string> jsonsColorSurvival = new List<string>();

        for (int i = 0; i < 12; i++)
        {
            string jsonColor = JsonHelper.ToJson<BoxType2>(colorMatrixSurvival[i]);
            jsonsColorSurvival.Add(jsonColor);
        }
        string finalJson = JsonHelper.ToJson<string>(jsonsColorSurvival);
        PlayerPrefs.SetString(color_survival_key, finalJson);
    }


    public void LoadLevel()
    {
        level = PlayerPrefs.GetInt(level_key, 1);
    }
    public void SaveLevel()
    {
        PlayerPrefs.SetInt(level_key, level);
    }

    public void LoadScoreClassic()
    {
        scoreClassic = PlayerPrefs.GetInt(score_classic_key, 0);
    }
    public void SaveScoreClassic()
    {
        PlayerPrefs.SetInt(score_classic_key, scoreClassic);
    }

    public void LoadHighScoreClassic()
    {
        highScoreClassic = PlayerPrefs.GetInt(high_score_classic_key, 0);
    }
    public void SaveHighScoreClassic()
    {
        PlayerPrefs.SetInt(high_score_classic_key, highScoreClassic);
    }

    public void LoadTarget()
    {
        target = PlayerPrefs.GetFloat(target_key, 1000);
    }
    public void SaveTarget()
    {
        PlayerPrefs.SetFloat(target_key, target);
    }

    public void LoadCoin()
    {
        coin = PlayerPrefs.GetInt(coin_key, 0);
    }
    public void SaveCoin()
    {
        PlayerPrefs.SetInt(coin_key, coin);
    }

    public void LoadScoreSurvival()
    {
        scoreSurvival = PlayerPrefs.GetInt(score_survival_key, 0);
    }
    public void SaveScoreSurvival()
    {
        PlayerPrefs.SetInt(score_survival_key, scoreSurvival);
    }

    public void LoadHighScoreSurvival()
    {
        highScoreSurvival = PlayerPrefs.GetInt(high_score_survival_key, 0);
    }
    public void SaveHighScoreSurvival()
    {
        PlayerPrefs.SetInt(high_score_survival_key, highScoreSurvival);
    }

    public void LoadTime()
    {
        maxTime = PlayerPrefs.GetFloat(time_key);
    }
    public void SaveTime()
    {
        PlayerPrefs.SetFloat(time_key, maxTime);
    }

    public void LoadMusic()
    {
        musicMuted = PlayerPrefs.GetInt(music_muted_key) == 1;
    }

    public void SaveMusic()
    {
        PlayerPrefs.SetInt(music_muted_key, musicMuted ? 1 : 0);
    }

}

