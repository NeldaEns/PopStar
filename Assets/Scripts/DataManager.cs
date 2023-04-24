using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    public static DataManager ins;
    public int scoreCasual;
    public int scoreClassic;
    public int highScoreCasual;
    public int highScoreClassic;
    public int level;
    public float target;
    public int coin;
    public bool start_new_game;

    public List<List<BoxType>> colorMatrixCasual;
    public List<List<BoxType1>> colorMatrixClassic;

    private const string score_casual_key = "score_casual_key";
    private const string score_classic_key = "score_classic_key";
    private const string high_score_casual_key = "high_score_casual_key";
    private const string high_score_classic_key = "high_score_classic_key";
    private const string level_key = "level_key";
    private const string target_key = "target_key";
    private const string coin_key = "coin_key";
    private const string color_key = "color_key";
    private const string first_time_play_casual = "first_time_play_casual";
    private const string first_time_play_classic = "first_time_play_classic";


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

        FirstTimePlayCasual();
        
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
        if (PlayerPrefs.HasKey(first_time_play_casual))
        {
            LoadDataClassic();
        }
        else
        {
            PlayerPrefs.SetInt(first_time_play_casual, 0);
            StartDataClassic();
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
    }
    public void LoadDataClassic ()
    {
        LoadScoreClassic();
        LoadHighScoreClassic();
        LoadCoin();
        LoadJsonClassic();
    }

    public void StartDataCasual()
    {
        scoreCasual = 0;
        level = 1;
        target = 1000;
        highScoreCasual = 0;
        coin = 1000;
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
        PlayerPrefs.SetString(color_key, finalJson);
    }

    public void SaveJsonClassic()
    {
        List<string> jsonsColorClassic = new List<string>();

        for (int i = 0; i < 10; i++)
        {
            string jsonColor = JsonHelper.ToJson<BoxType1>(colorMatrixClassic[i]);
            jsonsColorClassic.Add(jsonColor);
        }
        string finalJson = JsonHelper.ToJson<string>(jsonsColorClassic);
        PlayerPrefs.SetString(color_key, finalJson);
    }

    public void LoadJsonCasual()
    {
        string finalJson = PlayerPrefs.GetString(color_key);

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
        string finalJson = PlayerPrefs.GetString(color_key);

        List<string> jsonsColor = JsonHelper.FromJson<string>(finalJson);

        colorMatrixClassic = new List<List<BoxType1>>();
        for (int i = 0; i < 10; i++)
        {
            List<BoxType1> row = JsonHelper.FromJson<BoxType1>(jsonsColor[i]);
            colorMatrixClassic.Add(row);
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
        PlayerPrefs.SetFloat(target_key, target);
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
}

