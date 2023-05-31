using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Audio;
using System;

public class DataManager : MonoBehaviour
{
    public static DataManager ins;
    public int scoreCasual;
    public int scoreClassic;
    public int scoreSurvival;
    public int highScoreCasual;
    public int highScoreClassic;
    public int highScoreSurvival;
    public int level;
    public int target;
    public int coin;
    public float sfxVolume;
    public float musicSliderValue;
    public float sfxSliderValue;
    public float musicVolume;
    public bool start_new_game_casual;
    public bool start_new_game_classic;
    public bool start_new_game_survival;   
    public bool casualGame;
    public bool classicGame;
    public bool survivalGame;


    public List<List<BoxType>> colorMatrixCasual;
    public List<List<BoxType1>> colorMatrixClassic;
    public List<List<BoxType2>> colorMatrixSurvival;

    private const string score_casual_key = "score_casual_key";
    private const string score_classic_key = "score_classic_key";
    private const string score_survival_key = "score_survival_key";
    private const string high_score_casual_key = "high_score_casual_key";
    private const string high_score_classic_key = "high_score_classic_key";
    private const string high_score_survival_key = "high_score_survival_key";
    private const string level_key = "level_key";
    private const string target_key = "target_key";
    private const string coin_key = "coin_key";
    private const string color_casual_key = "color_casual_key";
    private const string color_classic_key = "color_classic_key";
    private const string color_survival_key = "color_survival_key";
    private const string first_time_play_casual = "first_time_play_casual";
    private const string first_time_play_classic = "first_time_play_classic";
    private const string first_time_play_survival = "first_time_play_survival";
    private const string music_volume = "music_volume";
    private const string sfx_volume = "sfx_volume";
    private const string music_slider_value = "music_slider_value";
    private const string sfx_slider_value = "sfx_slider_value";
    private const string current_time_survival = "current_time_survival";
  
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
        sfxSliderValue = 1;
        musicSliderValue = 1;
        FirstTimePlayCasual();
        FirstTimePlayClassic();
        FirstTimePlaySurvival();
    }

    public void FirstTimePlayCasual()
    {
        if (PlayerPrefs.HasKey(first_time_play_casual))
        {
            LoadDataCasual();
        }
        else
        {
            PlayerPrefs.SetInt(first_time_play_casual, 0);
            StartDataCasual();
        }
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

    public void LoadDataCasual()
    {
        LoadScoreCasual();
        LoadHighScoreCasual();
        LoadLevel();
        LoadTarget();
        LoadCoin();
        LoadJsonCasual();
        LoadMusicVolume();
        LoadMusicSliderValue();
        LoadSFXVolume();
        LoadSFXSliderValue();
    }

    public void LoadDataClassic()
    {
        LoadScoreClassic();
        LoadHighScoreClassic();
        LoadCoin();
        LoadJsonClassic();
        LoadMusicVolume();
        LoadMusicSliderValue();
        LoadSFXVolume();
        LoadSFXSliderValue();
    }

    public void LoadDataSurvival()
    {
        LoadScoreSurvival();
        LoadHighScoreSurvival();
        LoadCoin();
        LoadJsonSurvival();
        LoadMusicVolume();
        LoadMusicSliderValue();
        LoadSFXVolume();
        LoadSFXSliderValue();
    }

    public void StartDataCasual()
    {
        scoreCasual = 0;
        level = 1;
        target = 1000;
        highScoreCasual = 0;
        coin = 0;
        colorMatrixCasual = new List<List<BoxType>>();

        for (int i = 0; i < 10; i++)
        {
            List<BoxType> row = new List<BoxType>();

            for (int j = 0; j < 10; j++)
            {
                row.Add(BoxType.None);  
            }
            colorMatrixCasual.Add(row);
        }
        SaveJsonCasual();
        SaveCoin();
        SaveScoreCasual();
        SaveLevel();
        SaveTarget();
        SaveHighScoreCasual();
        SaveMusicVolume();
        SaveMusicSliderValue();
        SaveSFXVolume();
        SaveSFXSliderValue();
    }

    public void StartDataClassic()
    {
        scoreClassic = 0;
        highScoreClassic = 0;
        colorMatrixClassic = new List<List<BoxType1>>();

        for (int i = 0; i < 10; i++)
        {
            List<BoxType1> row = new List<BoxType1>();

            for (int j = 0; j < 10; j++)
            {
                row.Add(BoxType1.None);
            }

            colorMatrixClassic.Add(row);
        }
        SaveJsonClassic();
        SaveCoin();
        SaveScoreClassic();
        SaveHighScoreClassic();
        SaveMusicVolume();
        SaveMusicSliderValue();
        SaveSFXVolume();
        SaveSFXSliderValue();
    }

    public void StartDataSurvival()
    {
        scoreSurvival = 0;
        highScoreSurvival = 0;
        colorMatrixSurvival = new List<List<BoxType2>>();

        for (int i = 0; i < 15; i++)
        {
            List<BoxType2> row = new List<BoxType2>();

            for (int j = 0; j < 15; j++)
            {
                row.Add(BoxType2.None);
            }

            colorMatrixSurvival.Add(row);
        }
        SaveJsonSurvival();
        SaveCoin();
        SaveScoreSurvival();
        SaveHighScoreSurvival();
        SaveMusicVolume();
        SaveMusicSliderValue();
        SaveSFXVolume();
        SaveSFXSliderValue();
    }

    public void SaveJsonCasual()
    {
        List<string> jsonsColorCasual = new List<string>();

        for (int i = 0; i < 10; i++)
        {
            string jsonColor = JsonHelper.ToJson<BoxType>(colorMatrixCasual[i]);
            jsonsColorCasual.Add(jsonColor);
        }
        string finalJson = JsonHelper.ToJson<string>(jsonsColorCasual);
        PlayerPrefs.SetString(color_casual_key, finalJson);
    }

    public void SaveJsonClassic()
    {
        List<string> jsonsColorClassic = new List<string>();

        for (int i = 0; i < 10; i++)
        {
            string jsonColor = JsonHelper1.ToJson<BoxType1>(colorMatrixClassic[i]);
            jsonsColorClassic.Add(jsonColor);
        }
        string finalJson = JsonHelper1.ToJson<string>(jsonsColorClassic);
        PlayerPrefs.SetString(color_classic_key, finalJson);
    }

    public void SaveJsonSurvival()
    {
        List<string> jsonsColorSurvival = new List<string>();

        for (int i = 0; i < 15; i++)
        {
            string jsonColor = JsonHelper.ToJson<BoxType2>(colorMatrixSurvival[i]);
            jsonsColorSurvival.Add(jsonColor);
        }
        string finalJson = JsonHelper.ToJson<string>(jsonsColorSurvival);
        PlayerPrefs.SetString(color_survival_key, finalJson);
    }

    public void LoadJsonCasual()
    {
        string finalJson = PlayerPrefs.GetString(color_casual_key);

        List<string> jsonsColor = JsonHelper.FromJson<string>(finalJson);

        colorMatrixCasual = new List<List<BoxType>>();
        for(int i = 0; i < 10; i++)
        {
            List<BoxType> row = JsonHelper.FromJson<BoxType>(jsonsColor[i]);
            colorMatrixCasual.Add(row);
        }
    }

    public void LoadJsonClassic()
    {
        string finalJson = PlayerPrefs.GetString(color_classic_key);

        List<string> jsonsColor = JsonHelper1.FromJson<string>(finalJson);

        colorMatrixClassic = new List<List<BoxType1>>();
        for (int i = 0; i < 10; i++)
        {
            List<BoxType1> row = JsonHelper1.FromJson<BoxType1>(jsonsColor[i]);
            colorMatrixClassic.Add(row);
        }
    }

    public void LoadJsonSurvival()
    {
        string finalJson = PlayerPrefs.GetString(color_survival_key);

        List<string> jsonsColor = JsonHelper.FromJson<string>(finalJson);

        colorMatrixSurvival = new List<List<BoxType2>>();
        for (int i = 0; i < 15; i++)
        {
            List<BoxType2> row = JsonHelper.FromJson<BoxType2>(jsonsColor[i]);
            colorMatrixSurvival.Add(row);
        }
    }

    public void ResetDataCasual()
    {
        scoreCasual = 0;
        level = 1;
        target = 1000;
    }

    public void ResetDataClassic()
    {
        scoreClassic = 0;
    }

    public void ResetDataSurvival()
    {
        scoreSurvival = 0;
    }

    public void LoadScoreCasual()
    {
        scoreCasual = PlayerPrefs.GetInt(score_casual_key, 0);
    }

    public void LoadHighScoreCasual()
    {
        highScoreCasual = PlayerPrefs.GetInt(high_score_casual_key, 0);
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

    public void LoadMusicVolume()
    {      
        musicVolume = PlayerPrefs.GetFloat(music_volume);
    }

    public void LoadMusicSliderValue()
    {
        musicSliderValue = PlayerPrefs.GetFloat(music_slider_value);
    }

    public void LoadSFXSliderValue()
    {
        sfxSliderValue = PlayerPrefs.GetFloat(sfx_slider_value);
    }

    public void SaveMusicSliderValue()
    {
        PlayerPrefs.SetFloat(music_slider_value, musicSliderValue);
    }

    public void SaveSFXSliderValue()
    {
        PlayerPrefs.SetFloat(sfx_slider_value, sfxSliderValue);
    }

    public void LoadSFXVolume()
    {
        sfxVolume = PlayerPrefs.GetFloat(sfx_volume, 1);
    }

    public void SaveMusicVolume()
    {       
        PlayerPrefs.SetFloat(music_volume, musicVolume);
    }

    public void SaveSFXVolume()
    {
        PlayerPrefs.SetFloat(sfx_volume, sfxVolume);
    }
    public void SaveScoreCasual()
    {
        PlayerPrefs.SetInt(score_casual_key, scoreCasual);
    }

    public void SaveHighScoreCasual()
    {
        PlayerPrefs.SetInt(high_score_casual_key, highScoreCasual);
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

    public void LoadScoreClassic()
    {
        scoreClassic = PlayerPrefs.GetInt(score_classic_key, 0);
    }

    public void LoadHighScoreClassic()
    {
        highScoreClassic = PlayerPrefs.GetInt(high_score_classic_key, 0);
    }

    public void SaveScoreClassic()
    {
        PlayerPrefs.SetInt(score_classic_key, scoreClassic);
    }

    public void SaveHighScoreClassic()
    {
        PlayerPrefs.SetInt(high_score_classic_key, highScoreClassic);

    }

    public void LoadScoreSurvival()
    {
        scoreSurvival = PlayerPrefs.GetInt(score_survival_key, 0);
    }

    public void LoadHighScoreSurvival()
    {
        highScoreSurvival = PlayerPrefs.GetInt(high_score_survival_key, 0);
    }

    public void SaveScoreSurvival()
    {
        PlayerPrefs.SetInt(score_survival_key, scoreSurvival);
    }

    public void SaveHighScoreSurvival()
    {
        PlayerPrefs.SetInt(high_score_survival_key, highScoreSurvival);
    }
}

