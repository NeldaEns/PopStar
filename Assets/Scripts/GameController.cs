﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public List<List<GameObject>> boxMatrix;

    public List<GameObject> box;

    public List<GameObject> breakBox;

    public GameObject explosionPrefabs;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        boxMatrix = new List<List<GameObject>>();

        for (int i = 0; i < 10; i++)
        {
            List<GameObject> listBox = new List<GameObject>();

            for (int j = 0; j < 10; j++)
            {
                listBox.Add(null);
            }

            boxMatrix.Add(listBox);
        }
        if (DataManager.ins.start_new_game == true)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    SpawnBox(i, j);
                }
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    SpawnBox1(i, j);
                }
            }
        }
    }

    public void SpawnBox(int x, int y)
    {
        int color = Random.Range(1, 6);
        GameObject box1 = Instantiate(this.box[color - 1]);
        Vector3 pos = box1.GetComponent<Box>().CalculatationPosition(x, y);
        box1.transform.position = pos;
        box1.GetComponent<Box>().OnSpawn(x, y, (BoxType)color);
        boxMatrix[x][y] = box1;
    }

    public void SpawnBox1(int x, int y)
    {
        BoxType color1 = DataManager.ins.colorMatrix[x][y];
        if (color1 == BoxType.None)
        {
            boxMatrix[x][y] = null;
        }
        else
        {
            GameObject box2 = Instantiate(this.box[(int)color1 - 1]);
            Vector3 pos = box2.GetComponent<Box>().CalculatationPosition(x, y);
            box2.transform.position = pos;
            box2.GetComponent<Box>().OnSpawn(x, y, (BoxType)color1);
            boxMatrix[x][y] = box2;
        }
    }

    public void FindBreakBox()
    {       
        for (int i = 0; i < breakBox.Count; i++)
        {
            int x = breakBox[i].GetComponent<Box>().x;
            int y = breakBox[i].GetComponent<Box>().y;
            if (x > 0 && boxMatrix[x - 1][y] != null && boxMatrix[x - 1][y].GetComponent<Box>().type == breakBox[i].GetComponent<Box>().type && !KTBox(boxMatrix[x - 1][y]))
            {
                        breakBox.Add(boxMatrix[x - 1][y]);
            }
            if (x < 9 && boxMatrix[x + 1][y] != null && boxMatrix[x + 1][y].GetComponent<Box>().type == breakBox[i].GetComponent<Box>().type && !KTBox(boxMatrix[x + 1][y]))
            {
                        breakBox.Add(boxMatrix[x + 1][y]);
            }
            if (y > 0 && boxMatrix[x][y - 1] != null && boxMatrix[x][y - 1].GetComponent<Box>().type == breakBox[i].GetComponent<Box>().type && !KTBox(boxMatrix[x][y - 1]))
            {
                        breakBox.Add(boxMatrix[x][y - 1]);
            }
            if (y < 9 && boxMatrix[x][y + 1] != null && boxMatrix[x][y + 1].GetComponent<Box>().type == breakBox[i].GetComponent<Box>().type && !KTBox(boxMatrix[x][y + 1]))
            {
                        breakBox.Add(boxMatrix[x][y + 1]);
            }
        }
        if (breakBox.Count > 1)
        {
            for (int i = 0; i < breakBox.Count; i++)
            {
                int x = breakBox[i].GetComponent<Box>().x;
                int y = breakBox[i].GetComponent<Box>().y;
                for (int j = y; j < 9; j++)
                {
                    boxMatrix[x][j] = boxMatrix[x][j + 1];
                    if (boxMatrix[x][j] != null)
                    {
                        boxMatrix[x][j].GetComponent<Box>().y--;
                        boxMatrix[x][j].GetComponent<Box>().MoveDown();
                    }
                }
                boxMatrix[x][9] = null;   
            }
            for(int i = 8; i >= 0; i--)
            {
                if (boxMatrix[i][0] == null)
                {
                    for (int j = i; j < 9; j++)
                    {
                        for(int k = 0; k < 10; k++)
                        {
                            boxMatrix[j][k] = boxMatrix[j + 1][k];
                            if (boxMatrix[j][k] != null)
                            {
                                boxMatrix[j][k].GetComponent<Box>().x--;
                                boxMatrix[j][k].GetComponent<Box>().MoveLeft();
                            }
                        }
                    }
                    for(int h = 0; h < 10; h++)
                    {
                        boxMatrix[9][h] = null;
                    }
                }
            }
           
            for (int i = 0; i < breakBox.Count; i++)
            {
                int j = 5;
                if(breakBox.Count > 1)
                {
                    j = j + i * 10;
                    AddScore(j);                    
                }
                GameObject explosion = Instantiate(explosionPrefabs);
                explosion.GetComponent<ParticleSystem>().Play();
                explosion.transform.position = breakBox[i].transform.position;
                Destroy(breakBox[i]);
                Destroy(explosion, 0.5f);
            }

            for (int i = 0; i < boxMatrix.Count; i++)
            {
                for (int j = 0; j < boxMatrix[i].Count; j++)
                {
                    if(boxMatrix[i][j] == null)
                    {
                        DataManager.ins.colorMatrix[i][j] = BoxType.None;
                    }
                    else
                    {
                        DataManager.ins.colorMatrix[i][j] = boxMatrix[i][j].GetComponent<Box>().type;
                    }

                }
            }
            DataManager.ins.SaveJson();
        }
        breakBox.Clear();
        if (KTGameLose())
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Destroy(boxMatrix[j][i]);
                    boxMatrix[i][j] = null;
                }
            }
            if(DataManager.ins.score >= DataManager.ins.target)
            {
                DataManager.ins.level++;
                DataManager.ins.coin++;
                DataManager.ins.SaveLevel();
                DataManager.ins.SaveCoin();
                DataManager.ins.target = DataManager.ins.target + 1750;
                DataManager.ins.SaveTarget();
                for(int i = 0; i < 10; i++)
                {
                    for(int j = 0; j < 10; j++)
                    {
                        SpawnBox(i, j);
                    }
                }
            }
            else
            {
                UIController.ins.ShowGameOver();
                ((GameOverScreen)UIController.ins.currentScreen).Score();
                ((GameOverScreen)UIController.ins.currentScreen).HighScore();              
            }
        }
    }

    public void AddScore(int addedScore)
    {
        DataManager.ins.score += addedScore;
        DataManager.ins.SaveScore();
        ((UICasual)UIController.ins.currentScreen).UpdateScoreText();
        if(DataManager.ins.score > DataManager.ins.highScore)
        {
            DataManager.ins.highScore = DataManager.ins.score;
            DataManager.ins.SaveHighScore();
        }
        ((UICasual)UIController.ins.currentScreen).UpdateHighScoreText();
        ((UICasual)UIController.ins.currentScreen).UpdateTargetText();
        ((UICasual)UIController.ins.currentScreen).UpdateLevelText();
        ((UICasual)UIController.ins.currentScreen).UpdateCoinText();
    }

    public bool KTGameLose()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {

                if ( j < 9 && boxMatrix[j + 1][i] != null && boxMatrix[j][i] != null)
                {
                    bool kt1 = boxMatrix[j][i].GetComponent<Box>().type == boxMatrix[j + 1][i].GetComponent<Box>().type;
                    if (kt1)
                    {           
                        return false;
                    }
                }

                if (i < 9 && boxMatrix[j][i + 1] != null && boxMatrix[j][i] != null)
                {
                    bool kt1 = boxMatrix[j][i].GetComponent<Box>().type == boxMatrix[j][i + 1].GetComponent<Box>().type;
                    if (kt1)
                    {
                        return false;
                    }
                }

            }
        }
        return true;
    }
    public bool KTBox(GameObject box)
    { 
        for(int i = 0; i < breakBox.Count; i++)
        {
            int boxX = box.GetComponent<Box>().x;
            int boxY = box.GetComponent<Box>().y;

            int breakBoxX = breakBox[i].GetComponent<Box>().x;
            int breakBoxY = breakBox[i].GetComponent<Box>().y;

            if(boxX == breakBoxX && boxY == breakBoxY)
            {
                return true;
            }
        }
        return false;
    }

    public void ContinueGame()
    {
        for (int i = 0; i < DataManager.ins.colorMatrix.Count; i++)
        {
            for (int j = 0; j < DataManager.ins.colorMatrix[i].Count; j++)
            {
                if (DataManager.ins.colorMatrix[i][j] == BoxType.None)
                {
                    boxMatrix[i][j] = null;
                }
                else
                {
                    SpawnBox1(i, j);              
                }
            }
        }
    }
}