using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public List<List<GameObject>> boxMatrixClassic;
    public List<List<GameObject>> boxMatrixSurvival;

    public List<GameObject> boxClassic;
    public List<GameObject> boxSurvival;
    public List<GameObject> breakBox;
    public List<GameObject> moveBox;

    public GameObject greenExplosion;
    public GameObject orangeExplosion;
    public GameObject purpleExplosion;
    public GameObject redExplosion;
    public GameObject pinkExplosion;
    public GameObject yellowExplosion;
    public GameObject goodexplosion;
    public GameObject greatexplosion;
    public GameObject excellentexplosion;
    public GameObject amazingexplosion;
    public GameObject unbelievableexplosion;
    public GameObject objectParent;
    public GameObject linebroad;


    public bool useIt1;
    public bool useIt2;
    public bool useIt3;
    public bool clickBox1;
    public bool clickBox2;
    public bool gameOver;
    public bool gamePlay;

    public Transform popup;
    public Ease ease;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }

        instance = this;
    }

    private void Start()
    {
        boxMatrixClassic = new List<List<GameObject>>();
        for (int i = 0; i < 10; i++)
        {
            List<GameObject> listBoxClassic = new List<GameObject>();

            for (int j = 0; j < 10; j++)
            {
                listBoxClassic.Add(null);
            }
            boxMatrixClassic.Add(listBoxClassic);
        }
        boxMatrixSurvival = new List<List<GameObject>>();
        for (int i = 0; i < 12; i++)
        {
            List<GameObject> listBoxSurvival = new List<GameObject>();
            for (int j = 0; j < 12; j++)
            {
                listBoxSurvival.Add(null);
            }
            boxMatrixSurvival.Add(listBoxSurvival);
        }

        if (DataManager.ins.classicGame == true && DataManager.ins.survivalGame == false)
        {
            if (DataManager.ins.start_new_game_classic == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        SpawnBoxClassic(i, j);
                        boxMatrixClassic[i][j].transform.SetParent(objectParent.transform);

                    }
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        SpawnBoxClassic1(i, j);
                        if (boxMatrixClassic[i][j] != null)
                        {
                            boxMatrixClassic[i][j].transform.SetParent(objectParent.transform);
                        }
                    }
                }
            }
        }
        if (DataManager.ins.survivalGame == true && DataManager.ins.classicGame == false)
        {
            if (DataManager.ins.start_new_game_survival == true)
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        SpawnBoxSurvival(i, j);
                        boxMatrixSurvival[i][j].transform.SetParent(objectParent.transform);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        SpawnBoxSurvival1(i, j);
                        if (boxMatrixSurvival[i][j] != null)
                        {
                            boxMatrixSurvival[i][j].transform.SetParent(objectParent.transform);
                        }
                    }
                }
            }
            PopupInOutBack();
        }
        popup.localScale = Vector3.zero;
    }

    private void Update()
    {
        TimeUpdate();
    }
    public void PopupInOutBack()
    {
        popup.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(ease);
    }

    public void SpawnBoxClassic(int x, int y)
    {
        int color = UnityEngine.Random.Range(1, 6);
        GameObject box1 = Instantiate(boxClassic[color - 1]);
        Vector3 pos = box1.GetComponent<Box>().CalculatationPosition(x, y);
        box1.transform.localPosition = pos;
        box1.GetComponent<Box>().OnSpawn(x, y, (BoxType)color);
        boxMatrixClassic[x][y] = box1;
    }

    public void SpawnBoxSurvival(int x, int y)
    {
        int color = UnityEngine.Random.Range(1, 7);
        GameObject box1 = Instantiate(boxSurvival[color - 1]);
        Vector3 pos = box1.GetComponent<BoxSurvival>().CalculatationPosition(x, y);
        box1.transform.position = pos;
        box1.GetComponent<BoxSurvival>().OnSpawn(x, y, (BoxType2)color);
        boxMatrixSurvival[x][y] = box1;
    }

    public void SpawnBoxClassic1(int x, int y)
    {
        BoxType color1 = DataManager.ins.colorMatrixClassic[x][y];
        if (color1 == BoxType.None)
        {
            boxMatrixClassic[x][y] = null;
        }
        else
        {
            GameObject box2 = Instantiate(this.boxClassic[(int)color1 - 1]);
            Vector3 pos = box2.GetComponent<Box>().CalculatationPosition(x, y);
            box2.transform.position = pos;
            box2.GetComponent<Box>().OnSpawn(x, y, color1);
            boxMatrixClassic[x][y] = box2;
        }
    }

    public void SpawnBoxSurvival1(int x, int y)
    {
        BoxType2 color1 = DataManager.ins.colorMatrixSurvival[x][y];
        if (color1 == BoxType2.None)
        {
            boxMatrixSurvival[x][y] = null;
        }
        else
        {
            GameObject box2 = Instantiate(this.boxSurvival[(int)color1 - 1]);
            Vector3 pos = box2.GetComponent<BoxSurvival>().CalculatationPosition(x, y);
            box2.transform.position = pos;
            box2.GetComponent<BoxSurvival>().OnSpawn(x, y, color1);
            boxMatrixSurvival[x][y] = box2;
        }
    }

    public void FindBreakBoxClassic()
    {
        for (int i = 0; i < breakBox.Count; i++)
        {
            int x = breakBox[i].GetComponent<Box>().x;
            int y = breakBox[i].GetComponent<Box>().y;
            if (x > 0 && boxMatrixClassic[x - 1][y] != null && boxMatrixClassic[x - 1][y].GetComponent<Box>().type == breakBox[i].GetComponent<Box>().type && !KTBoxClassic(boxMatrixClassic[x - 1][y]))
            {
                breakBox.Add(boxMatrixClassic[x - 1][y]);
            }
            if (x < 9 && boxMatrixClassic[x + 1][y] != null && boxMatrixClassic[x + 1][y].GetComponent<Box>().type == breakBox[i].GetComponent<Box>().type && !KTBoxClassic(boxMatrixClassic[x + 1][y]))
            {
                breakBox.Add(boxMatrixClassic[x + 1][y]);
            }
            if (y > 0 && boxMatrixClassic[x][y - 1] != null && boxMatrixClassic[x][y - 1].GetComponent<Box>().type == breakBox[i].GetComponent<Box>().type && !KTBoxClassic(boxMatrixClassic[x][y - 1]))
            {
                breakBox.Add(boxMatrixClassic[x][y - 1]);
            }
            if (y < 9 && boxMatrixClassic[x][y + 1] != null && boxMatrixClassic[x][y + 1].GetComponent<Box>().type == breakBox[i].GetComponent<Box>().type && !KTBoxClassic(boxMatrixClassic[x][y + 1]))
            {
                breakBox.Add(boxMatrixClassic[x][y + 1]);
            }
        }
        if (breakBox.Count > 1)
        {
            BreakBoxClassic();

            MoveBoxClassic();

            SaveBoxClassic();

        }
        breakBox.Clear();
        CheckWinLoseClassic();
    }

    public void FindBreakBoxSurvival()
    {
        for (int i = 0; i < breakBox.Count; i++)
        {
            int x = breakBox[i].GetComponent<BoxSurvival>().x;
            int y = breakBox[i].GetComponent<BoxSurvival>().y;
            if (x > 0 && boxMatrixSurvival[x - 1][y] != null && boxMatrixSurvival[x - 1][y].GetComponent<BoxSurvival>().type == breakBox[i].GetComponent<BoxSurvival>().type && !KTBoxSurvival(boxMatrixSurvival[x - 1][y]))
            {
                breakBox.Add(boxMatrixSurvival[x - 1][y]);
            }
            if (x < 11 && boxMatrixSurvival[x + 1][y] != null && boxMatrixSurvival[x + 1][y].GetComponent<BoxSurvival>().type == breakBox[i].GetComponent<BoxSurvival>().type && !KTBoxSurvival(boxMatrixSurvival[x + 1][y]))
            {
                breakBox.Add(boxMatrixSurvival[x + 1][y]);
            }
            if (y > 0 && boxMatrixSurvival[x][y - 1] != null && boxMatrixSurvival[x][y - 1].GetComponent<BoxSurvival>().type == breakBox[i].GetComponent<BoxSurvival>().type && !KTBoxSurvival(boxMatrixSurvival[x][y - 1]))
            {
                breakBox.Add(boxMatrixSurvival[x][y - 1]);
            }
            if (y < 11 && boxMatrixSurvival[x][y + 1] != null && boxMatrixSurvival[x][y + 1].GetComponent<BoxSurvival>().type == breakBox[i].GetComponent<BoxSurvival>().type && !KTBoxSurvival(boxMatrixSurvival[x][y + 1]))
            {
                breakBox.Add(boxMatrixSurvival[x][y + 1]);
            }
        }
        if (breakBox.Count > 1)
        {
            BreakBoxSurvival();

            MoveBoxSurvival();

            SaveBoxSurvival();

        }
        breakBox.Clear();
        CheckWinLoseSurvival();
    }

    public void TimeUpdate()
    {
        if (DataManager.ins.timeActive)
        {
            gamePlay = true;
            DataManager.ins.currentTime -= Time.deltaTime;
            if (DataManager.ins.currentTime < 10)
            {
                ((UISurvival)UIController.ins.currentScreen).txtCurrentTime.color = Color.red;
            }
            ((UISurvival)UIController.ins.currentScreen).UpdateTimeText();
            DataManager.ins.maxTime = DataManager.ins.currentTime;
            DataManager.ins.SaveTime();
            CheckTime();

        }
    }

    public void CheckTime()
    {
        if (DataManager.ins.currentTime <= 0)
        {
            DataManager.ins.timeActive = false;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    Destroy(boxMatrixSurvival[j][i], 0.05f);
                    boxMatrixSurvival[j][i] = null;
                }
            }
            gameOver = true;
            ManagerAds.Ins.ShowInterstitial();
            linebroad.SetActive(false);
            UIController.ins.ShowGameOverSurvival();
            ((SurvivalGameOverScreen)UIController.ins.currentScreen).ScoreSurvival();
            ((SurvivalGameOverScreen)UIController.ins.currentScreen).HighScoreSurvival();
        }
    }

    public void ColorExplosionClassic()
    {
        for (int i = 0; i < breakBox.Count; i++)
        {
            if (breakBox[i].GetComponent<Box>().type == BoxType.Purple)
            {
                GameObject popPurple = Instantiate(purpleExplosion);
                popPurple.SetActive(true);
                popPurple.transform.position = breakBox[i].transform.position;
                Destroy(popPurple, 3f);
            }
            if (breakBox[i].GetComponent<Box>().type == BoxType.Orange)
            {
                GameObject popGreen = Instantiate(greenExplosion);
                popGreen.SetActive(true);
                popGreen.transform.position = breakBox[i].transform.position;
                Destroy(popGreen, 3f);
            }
            if (breakBox[i].GetComponent<Box>().type == BoxType.Green)
            {
                GameObject popPink = Instantiate(pinkExplosion);
                popPink.SetActive(true);
                popPink.transform.position = breakBox[i].transform.position;
                Destroy(popPink, 3f);
            }
            if (breakBox[i].GetComponent<Box>().type == BoxType.Red)
            {
                GameObject popRed = Instantiate(redExplosion);
                popRed.SetActive(true);
                popRed.transform.position = breakBox[i].transform.position;
                Destroy(popRed, 3f);
            }
            if (breakBox[i].GetComponent<Box>().type == BoxType.Yellow)
            {
                GameObject popYellow = Instantiate(yellowExplosion);
                popYellow.SetActive(true);
                popYellow.transform.position = breakBox[i].transform.position;
                Destroy(popYellow, 3f);
            }
        }
    }
    public void ColorExplosionClassic1(int x, int y)
    {
        if (boxMatrixClassic[x][y].GetComponent<Box>().type == BoxType.Orange)
        {
            GameObject popOrange = Instantiate(orangeExplosion);
            popOrange.SetActive(true);
            popOrange.transform.position = boxMatrixClassic[x][y].transform.position;
            Destroy(popOrange, 3f);
        }
        if (boxMatrixClassic[x][y].GetComponent<Box>().type == BoxType.Green)
        {
            GameObject popGreen = Instantiate(greenExplosion);
            popGreen.SetActive(true);
            popGreen.transform.position = boxMatrixClassic[x][y].transform.position;
            Destroy(popGreen, 3f);
        }
        if (boxMatrixClassic[x][y].GetComponent<Box>().type == BoxType.Purple)
        {
            GameObject popPurple = Instantiate(purpleExplosion);
            popPurple.SetActive(true);
            popPurple.transform.position = boxMatrixClassic[x][y].transform.position;
            Destroy(popPurple, 3f);
        }
        if (boxMatrixClassic[x][y].GetComponent<Box>().type == BoxType.Red)
        {
            GameObject popRed = Instantiate(redExplosion);
            popRed.SetActive(true);
            popRed.transform.position = boxMatrixClassic[x][y].transform.position;
            Destroy(popRed, 3f);
        }
        if (boxMatrixClassic[x][y].GetComponent<Box>().type == BoxType.Yellow)
        {
            GameObject popYellow = Instantiate(yellowExplosion);
            popYellow.SetActive(true);
            popYellow.transform.position = boxMatrixClassic[x][y].transform.position;
            Destroy(popYellow, 3f);
        }
    }

    public void ColorExplosionSurvival()
    {
        for (int i = 0; i < breakBox.Count; i++)
        {
            if (breakBox[i].GetComponent<BoxSurvival>().type == BoxType2.Purple)
            {
                GameObject popPurple = Instantiate(purpleExplosion);
                popPurple.SetActive(true);
                popPurple.transform.position = breakBox[i].transform.position;
                Destroy(popPurple, 3f);
            }
            if (breakBox[i].GetComponent<BoxSurvival>().type == BoxType2.Orange)
            {
                GameObject popOrange = Instantiate(orangeExplosion);
                popOrange.SetActive(true);
                popOrange.transform.position = breakBox[i].transform.position;
                Destroy(popOrange, 3f);
            }
            if (breakBox[i].GetComponent<BoxSurvival>().type == BoxType2.Pink)
            {
                GameObject popPink = Instantiate(pinkExplosion);
                popPink.SetActive(true);
                popPink.transform.position = breakBox[i].transform.position;
                Destroy(popPink, 3f);
            }
            if (breakBox[i].GetComponent<BoxSurvival>().type == BoxType2.Red)
            {
                GameObject popRed = Instantiate(redExplosion);
                popRed.SetActive(true);
                popRed.transform.position = breakBox[i].transform.position;
                Destroy(popRed, 3f);
            }
            if (breakBox[i].GetComponent<BoxSurvival>().type == BoxType2.Yellow)
            {
                GameObject popYellow = Instantiate(yellowExplosion);
                popYellow.SetActive(true);
                popYellow.transform.position = breakBox[i].transform.position;
                Destroy(popYellow, 3f);
            }
            if (breakBox[i].GetComponent<BoxSurvival>().type == BoxType2.Green)
            {
                GameObject popGreen = Instantiate(greenExplosion);
                popGreen.SetActive(true);
                popGreen.transform.position = breakBox[i].transform.position;
                Destroy(popGreen, 3f);
            }
        }
    }
    public void ColorExplosionSurvival1(int x, int y)
    {
        if (boxMatrixSurvival[x][y].GetComponent<BoxSurvival>().type == BoxType2.Orange)
        {
            GameObject popOrange = Instantiate(orangeExplosion);
            popOrange.SetActive(true);
            popOrange.transform.position = boxMatrixSurvival[x][y].transform.position;
            Destroy(popOrange, 3f);
        }
        if (boxMatrixSurvival[x][y].GetComponent<BoxSurvival>().type == BoxType2.Pink)
        {
            GameObject popPink = Instantiate(pinkExplosion);
            popPink.SetActive(true);
            popPink.transform.position = boxMatrixSurvival[x][y].transform.position;
            Destroy(popPink, 3f);
        }
        if (boxMatrixSurvival[x][y].GetComponent<BoxSurvival>().type == BoxType2.Purple)
        {
            GameObject popPurple = Instantiate(purpleExplosion);
            popPurple.SetActive(true);
            popPurple.transform.position = boxMatrixSurvival[x][y].transform.position;
            Destroy(popPurple, 3f);
        }
        if (boxMatrixSurvival[x][y].GetComponent<BoxSurvival>().type == BoxType2.Red)
        {
            GameObject popRed = Instantiate(redExplosion);
            popRed.SetActive(true);
            popRed.transform.position = boxMatrixSurvival[x][y].transform.position;
            Destroy(popRed, 3f);
        }
        if (boxMatrixSurvival[x][y].GetComponent<BoxSurvival>().type == BoxType2.Yellow)
        {
            GameObject popYellow = Instantiate(yellowExplosion);
            popYellow.SetActive(true);
            popYellow.transform.position = boxMatrixSurvival[x][y].transform.position;
            Destroy(popYellow, 3f);
        }
        if (boxMatrixSurvival[x][y].GetComponent<BoxSurvival>().type == BoxType2.Green)
        {
            GameObject popGreen = Instantiate(greenExplosion);
            popGreen.SetActive(true);
            popGreen.transform.position = boxMatrixSurvival[x][y].transform.position;
            Destroy(popGreen, 3f);
        }
    }

    public void BreakBoxClassic()
    {
        for (int i = 0; i < breakBox.Count; i++)
        {
            int j = 5;
            j = j + i * 10;
            if (breakBox.Count == 2)
            {
                ColorExplosionClassic();
                AudioManager.ins.PlaySFX("click");
            }
            if (breakBox.Count > 2 && breakBox.Count < 5)
            {
                GameObject goodexplosion1 = Instantiate(goodexplosion);
                goodexplosion1.GetComponent<ParticleSystem>().Play();
                goodexplosion1.transform.position = breakBox[i].transform.position;
                ColorExplosionClassic();
                AudioManager.ins.PlaySFX("good");
                Destroy(goodexplosion1, 3f);
            }
            if (breakBox.Count > 4 && breakBox.Count < 7)
            {
                GameObject greatexplosion1 = Instantiate(greatexplosion);
                greatexplosion1.GetComponent<ParticleSystem>().Play();
                greatexplosion1.transform.position = breakBox[i].transform.position;
                ColorExplosionClassic();
                AudioManager.ins.PlaySFX("great");
                Destroy(greatexplosion1, 3f);

            }
            if (breakBox.Count > 6 && breakBox.Count < 9)
            {
                GameObject excellentexplosion1 = Instantiate(excellentexplosion);
                excellentexplosion1.GetComponent<ParticleSystem>().Play();
                excellentexplosion1.transform.position = breakBox[i].transform.position;
                ColorExplosionClassic();
                AudioManager.ins.PlaySFX("excellent");
                Destroy(excellentexplosion1, 3f);
            }
            if (breakBox.Count > 8 && breakBox.Count < 11)
            {
                GameObject amazingexplosion1 = Instantiate(amazingexplosion);
                amazingexplosion1.GetComponent<ParticleSystem>().Play();
                amazingexplosion1.transform.position = breakBox[i].transform.position;
                ColorExplosionClassic();
                AudioManager.ins.PlaySFX("amazing");
                Destroy(amazingexplosion1, 3f);
            }
            if (breakBox.Count > 10)
            {
                GameObject unbelievableexplosion1 = Instantiate(unbelievableexplosion);
                unbelievableexplosion1.GetComponent<ParticleSystem>().Play();
                unbelievableexplosion1.transform.position = breakBox[i].transform.position;
                ColorExplosionClassic();
                AudioManager.ins.PlaySFX("unbelievable");
                Destroy(unbelievableexplosion1, 3f);
            }
            AddScoreClassic(j);
            Destroy(breakBox[i]);
        }
    }

    public void BreakBoxSurvival()
    {
        for (int i = 0; i < breakBox.Count; i++)
        {
            int j = 5;
            j = j + i * 10;
            if (breakBox.Count == 2)
            {
                ColorExplosionSurvival();
                AudioManager.ins.PlaySFX("click");
            }
            if (breakBox.Count > 2 && breakBox.Count < 5)
            {
                GameObject goodexplosion1 = Instantiate(goodexplosion);
                goodexplosion1.GetComponent<ParticleSystem>().Play();
                goodexplosion1.transform.position = breakBox[i].transform.position;
                ColorExplosionSurvival();
                AudioManager.ins.PlaySFX("good");
                Destroy(goodexplosion1, 3f);
            }
            if (breakBox.Count > 4 && breakBox.Count < 7)
            {
                GameObject greatexplosion1 = Instantiate(greatexplosion);
                greatexplosion1.GetComponent<ParticleSystem>().Play();
                greatexplosion1.transform.position = breakBox[i].transform.position;
                ColorExplosionSurvival();
                AudioManager.ins.PlaySFX("great");
                Destroy(greatexplosion1, 3f);

            }
            if (breakBox.Count > 6 && breakBox.Count < 9)
            {
                GameObject excellentexplosion1 = Instantiate(excellentexplosion);
                excellentexplosion1.GetComponent<ParticleSystem>().Play();
                excellentexplosion1.transform.position = breakBox[i].transform.position;
                ColorExplosionSurvival();
                AudioManager.ins.PlaySFX("excellent");
                Destroy(excellentexplosion1, 3f);
            }
            if (breakBox.Count > 8 && breakBox.Count < 11)
            {
                GameObject amazingexplosion1 = Instantiate(amazingexplosion);
                amazingexplosion1.GetComponent<ParticleSystem>().Play();
                amazingexplosion1.transform.position = breakBox[i].transform.position;
                ColorExplosionSurvival();
                AudioManager.ins.PlaySFX("amazing");
                Destroy(amazingexplosion1, 3f);
            }
            if (breakBox.Count > 10)
            {
                GameObject unbelievableexplosion1 = Instantiate(unbelievableexplosion);
                unbelievableexplosion1.GetComponent<ParticleSystem>().Play();
                unbelievableexplosion1.transform.position = breakBox[i].transform.position;
                ColorExplosionSurvival();
                AudioManager.ins.PlaySFX("unbelievable");
                Destroy(unbelievableexplosion1, 3f);
            }
            AddScoreSurvival(j);
            Destroy(breakBox[i]);
        }
    }

    public void MoveBoxClassic()
    {
        for (int i = 0; i < breakBox.Count; i++)
        {
            int x = breakBox[i].GetComponent<Box>().x;
            int y = breakBox[i].GetComponent<Box>().y;
            for (int j = y; j < 9; j++)
            {
                boxMatrixClassic[x][j] = boxMatrixClassic[x][j + 1];
                if (boxMatrixClassic[x][j] != null)
                {
                    boxMatrixClassic[x][j].GetComponent<Box>().y--;
                    boxMatrixClassic[x][j].GetComponent<Box>().MoveDown();
                }
            }
            boxMatrixClassic[x][9] = null;
        }

        for (int i = 8; i >= 0; i--)
        {
            if (boxMatrixClassic[i][0] == null)
            {
                for (int j = i; j < 9; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        boxMatrixClassic[j][k] = boxMatrixClassic[j + 1][k];
                        if (boxMatrixClassic[j][k] != null)
                        {
                            boxMatrixClassic[j][k].GetComponent<Box>().x--;
                            boxMatrixClassic[j][k].GetComponent<Box>().MoveLeft();
                        }
                    }
                }
                for (int h = 0; h < 10; h++)
                {
                    boxMatrixClassic[9][h] = null;
                }
            }
        }
    }

    public void MoveBoxSurvival()
    {
        for (int i = 0; i < breakBox.Count; i++)
        {
            int x = breakBox[i].GetComponent<BoxSurvival>().x;
            int y = breakBox[i].GetComponent<BoxSurvival>().y;
            for (int j = y; j < 11; j++)
            {
                boxMatrixSurvival[x][j] = boxMatrixSurvival[x][j + 1];
                if (boxMatrixSurvival[x][j] != null)
                {
                    boxMatrixSurvival[x][j].GetComponent<BoxSurvival>().y--;
                    boxMatrixSurvival[x][j].GetComponent<BoxSurvival>().MoveDown();
                }
            }
            boxMatrixSurvival[x][11] = null;
        }

        for (int i = 11; i >= 0; i--)
        {
            if (boxMatrixSurvival[i][0] == null)
            {
                DataManager.ins.currentTime += 10f;
                for (int k = 0; k < 12; k++)
                {
                    for (int h = 0; h < 12; h++)
                    {
                        if (boxMatrixSurvival[k][h] == null)
                        {
                            SpawnBoxSurvival(k, h);
                        }
                    }
                }
            }
        }
    }

    public void SaveBoxClassic()
    {
        for (int i = 0; i < boxMatrixClassic.Count; i++)
        {
            for (int j = 0; j < boxMatrixClassic[i].Count; j++)
            {
                if (boxMatrixClassic[i][j] == null)
                {
                    DataManager.ins.colorMatrixClassic[i][j] = BoxType.None;
                }
                else
                {
                    DataManager.ins.colorMatrixClassic[i][j] = boxMatrixClassic[i][j].GetComponent<Box>().type;
                }
            }
        }
        DataManager.ins.SaveJsonClassic();
    }

    public void SaveBoxSurvival()
    {
        for (int i = 0; i < boxMatrixSurvival.Count; i++)
        {
            for (int j = 0; j < boxMatrixSurvival[i].Count; j++)
            {
                if (boxMatrixSurvival[i][j] == null)
                {
                    DataManager.ins.colorMatrixSurvival[i][j] = BoxType2.None;
                }
                else
                {
                    DataManager.ins.colorMatrixSurvival[i][j] = boxMatrixSurvival[i][j].GetComponent<BoxSurvival>().type;
                }
            }
        }
        DataManager.ins.SaveJsonSurvival();
    }

    public void CheckWinLoseClassic()
    {
        if (KTGameLoseClassic())
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Destroy(boxMatrixClassic[j][i]);
                    boxMatrixClassic[j][i] = null;
                    ((UIClassic)UIController.ins.currentScreen).panel.SetActive(false);
                }
            }
            if (DataManager.ins.scoreClassic >= DataManager.ins.target)
            {

                DataManager.ins.level++;
                DataManager.ins.coin++;
                DataManager.ins.SaveLevel();
                DataManager.ins.SaveCoin();
                DataManager.ins.target = DataManager.ins.target + 1750;
                DataManager.ins.SaveTarget();
                ((UIClassic)UIController.ins.currentScreen).panel.SetActive(true);
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        AudioManager.ins.PlaySFX("gamestart");
                        SpawnBoxClassic(i, j);
                        boxMatrixClassic[i][j].transform.SetParent(objectParent.transform);
                        DataManager.ins.colorMatrixClassic[i][j] = boxMatrixClassic[i][j].GetComponent<Box>().type;
                    }
                }
                PopupInOutBack();
                DataManager.ins.SaveJsonClassic();
            }
            else
            {
                ManagerAds.Ins.ShowInterstitial();
                linebroad.SetActive(false);
                UIController.ins.ShowGameOverClassic();
                ((GameOverScreenClassic)UIController.ins.currentScreen).ScoreClassic();
                ((GameOverScreenClassic)UIController.ins.currentScreen).HighScoreClassic();
                gameOver = true;
                if (gameOver == true)
                {
                    DataManager.ins.start_new_game_classic = true;
                    DataManager.ins.ResetDataClassic();
                }
            }
            popup.localScale = Vector3.zero;
        }
    }

    public void CheckWinLoseSurvival()
    {
        if (KTGameLoseSurvival())
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    Destroy(boxMatrixSurvival[j][i], 0.05f);
                    boxMatrixSurvival[j][i] = null;
                }
            }
            gameOver = true;
            ManagerAds.Ins.ShowInterstitial();
            linebroad.SetActive(false);
            UIController.ins.ShowGameOverSurvival();
            ((SurvivalGameOverScreen)UIController.ins.currentScreen).ScoreSurvival();
            ((SurvivalGameOverScreen)UIController.ins.currentScreen).HighScoreSurvival();
        }
    }

    public void AddScoreClassic(int addedScore)
    {
        DataManager.ins.scoreClassic += addedScore;
        DataManager.ins.SaveScoreClassic();
        ((UIClassic)UIController.ins.currentScreen).UpdateScoreText();
        if (DataManager.ins.scoreClassic > DataManager.ins.highScoreClassic)
        {
            DataManager.ins.highScoreClassic = DataManager.ins.scoreClassic;
            DataManager.ins.SaveHighScoreClassic();
        }
        ((UIClassic)UIController.ins.currentScreen).UpdateHighScoreText();
        ((UIClassic)UIController.ins.currentScreen).UpdateTargetText();
        ((UIClassic)UIController.ins.currentScreen).UpdateLevelText();
        ((UIClassic)UIController.ins.currentScreen).UpdateCoinText();
    }

    public void AddScoreSurvival(int addScore)
    {
        DataManager.ins.scoreSurvival += addScore;
        DataManager.ins.SaveScoreSurvival();
        ((UISurvival)UIController.ins.currentScreen).UpdateScoreText();
        if (DataManager.ins.scoreSurvival > DataManager.ins.highScoreSurvival)
        {
            DataManager.ins.highScoreSurvival = DataManager.ins.scoreSurvival;
            DataManager.ins.SaveHighScoreSurvival();
        }
        ((UISurvival)UIController.ins.currentScreen).UpdateHighScoreText();
        ((UISurvival)UIController.ins.currentScreen).UpdateCoinText();
    }

    public bool KTGameLoseClassic()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {

                if (j < 9 && boxMatrixClassic[j + 1][i] != null && boxMatrixClassic[j][i] != null)
                {
                    bool kt1 = boxMatrixClassic[j][i].GetComponent<Box>().type == boxMatrixClassic[j + 1][i].GetComponent<Box>().type;
                    if (kt1)
                    {
                        return false;
                    }
                }

                if (i < 9 && boxMatrixClassic[j][i + 1] != null && boxMatrixClassic[j][i] != null)
                {
                    bool kt1 = boxMatrixClassic[j][i].GetComponent<Box>().type == boxMatrixClassic[j][i + 1].GetComponent<Box>().type;
                    if (kt1)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public bool KTGameLoseSurvival()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                if (j < 11 && boxMatrixSurvival[j + 1][i] != null && boxMatrixSurvival[j][i] != null)
                {
                    bool kt1 = boxMatrixSurvival[j][i].GetComponent<BoxSurvival>().type == boxMatrixSurvival[j + 1][i].GetComponent<BoxSurvival>().type;
                    if (kt1)
                    {
                        return false;
                    }
                }

                if (i < 11 && boxMatrixSurvival[j][i + 1] != null && boxMatrixSurvival[j][i] != null)
                {
                    bool kt1 = boxMatrixSurvival[j][i].GetComponent<BoxSurvival>().type == boxMatrixSurvival[j][i + 1].GetComponent<BoxSurvival>().type;
                    if (kt1)
                    {
                        return false;
                    }
                }
            }
        }
        return true;

    }

    public bool KTBoxClassic(GameObject box)
    {
        for (int i = 0; i < breakBox.Count; i++)
        {
            int boxX = box.GetComponent<Box>().x;
            int boxY = box.GetComponent<Box>().y;

            int breakBoxX = breakBox[i].GetComponent<Box>().x;
            int breakBoxY = breakBox[i].GetComponent<Box>().y;

            if (boxX == breakBoxX && boxY == breakBoxY)
            {
                return true;
            }
        }
        return false;
    }

    public bool KTBoxSurvival(GameObject box)
    {
        for (int i = 0; i < breakBox.Count; i++)
        {
            int boxX = box.GetComponent<BoxSurvival>().x;
            int boxY = box.GetComponent<BoxSurvival>().y;

            int breakBoxX = breakBox[i].GetComponent<BoxSurvival>().x;
            int breakBoxY = breakBox[i].GetComponent<BoxSurvival>().y;

            if (boxX == breakBoxX && boxY == breakBoxY)
            {
                return true;
            }
        }
        return false;
    }

    public void ClickMoveBoxClassic1(int x, int y)
    {
        AudioManager.ins.PlaySFX("it1");
        moveBox.Add(boxMatrixClassic[x][y]);
        clickBox1 = true;
    }

    public void ClickMoveBoxClassic2(int x, int y)
    {
        AudioManager.ins.PlaySFX("it1");
        moveBox.Add(boxMatrixClassic[x][y]);
        clickBox2 = true;
    }

    public void ClickMoveBoxSurvival1(int x, int y)
    {
        AudioManager.ins.PlaySFX("it1");
        moveBox.Add(boxMatrixSurvival[x][y]);
        clickBox1 = true;
    }

    public void ClickMoveBoxSurvival2(int x, int y)
    {
        AudioManager.ins.PlaySFX("it1");
        moveBox.Add(boxMatrixSurvival[x][y]);
        clickBox2 = true;
    }

    public void Item1Classic()
    {
        if (clickBox1 && clickBox2 && moveBox.Count == 2)
        {
            Box box1 = moveBox[0].GetComponent<Box>();
            //Debug.Log(box1.x);
            //Debug.Log(box1.y);
            Box box2 = moveBox[1].GetComponent<Box>();
            //Debug.Log(box2.x);
            //Debug.Log(box2.y);
            BoxType color1 = box1.type;
            BoxType color2 = box2.type;
            if (box1 != null && box2 != null)
            {
                if(box1.x == box2.x)
                {
                    if(Math.Abs(box1.y - box2.y) == 1)
                    {
                        var tempColor = DataManager.ins.colorMatrixClassic[box1.x][box1.y];
                        DataManager.ins.colorMatrixClassic[box1.x][box1.y] = DataManager.ins.colorMatrixClassic[box2.x][box2.y];
                        DataManager.ins.colorMatrixClassic[box2.x][box2.y] = tempColor;
                        var temp = boxMatrixClassic[box1.x][box1.y];
                        boxMatrixClassic[box1.x][box1.y] = boxMatrixClassic[box2.x][box2.y];
                        boxMatrixClassic[box2.x][box2.y] = temp;
                        var tempX = box1.x;
                        box1.x = box2.x;
                        box2.x = tempX;
                        var tempY = box1.y;
                        box1.y = box2.y;
                        box2.y = tempY;
                        box1.transform.position = box1.CalculatationPosition(box1.x, box1.y);
                        box2.transform.position = box2.CalculatationPosition(box2.x, box2.y);

                    }
                }else if(box1.y == box2.y)
                {
                    if(Math.Abs(box1.x - box2.x) == 1)
                    {
                        var tempColor = DataManager.ins.colorMatrixClassic[box1.x][box1.y];
                        DataManager.ins.colorMatrixClassic[box1.x][box1.y] = DataManager.ins.colorMatrixClassic[box2.x][box2.y];
                        DataManager.ins.colorMatrixClassic[box2.x][box2.y] = tempColor;
                        var temp = boxMatrixClassic[box1.x][box1.y];
                        boxMatrixClassic[box1.x][box1.y] = boxMatrixClassic[box2.x][box2.y];
                        boxMatrixClassic[box2.x][box2.y] = temp;
                        var tempX = box1.x;
                        box1.x = box2.x;
                        box2.x = tempX;
                        var tempY = box1.y;
                        box1.y = box2.y;
                        box2.y = tempY;
                        box1.transform.position = box1.CalculatationPosition(box1.x, box1.y);
                        box2.transform.position = box2.CalculatationPosition(box2.x, box2.y);
                    }
                }
                //if (box1.x > 0 || box2.x > 0 && box1.x - box2.x == 1 || box2.x - box1.x == 1 && box1.y == box2.y && color1 != color2)
                //{
                //    var tempColor = DataManager.ins.colorMatrixClassic[box1.x][box1.y];
                //    DataManager.ins.colorMatrixClassic[box1.x][box1.y] = DataManager.ins.colorMatrixClassic[box2.x][box2.y];
                //    DataManager.ins.colorMatrixClassic[box2.x][box2.y] = tempColor;

                //    int tempX = box1.x;
                //    box1.x = box2.x;
                //    box2.x = tempX;


                //    int tempY = box1.y;
                //    box1.y = box2.y;
                //    box2.y = tempY;

                //    box1.transform.position = box1.CalculatationPosition(box1.x, box1.y);


                //    box2.transform.position = box2.CalculatationPosition(box2.x, box2.y);


                //    //DataManager.ins.colorMatrixClassic[box2.x][box2.y] = boxMatrixClassic[box2.x][box2.y].GetComponent<Box>().type;
                //}
                //else if (box1.y > 0 || box2.y > 0 && box1.y - box2.y == 1 || box2.y - box1.y == 1 && box1.x == box2.x && color1 != color2)
                //{
                //    var tempColor = DataManager.ins.colorMatrixClassic[box1.x][box1.y];
                //    DataManager.ins.colorMatrixClassic[box1.x][box1.y] = DataManager.ins.colorMatrixClassic[box2.x][box2.y];
                //    DataManager.ins.colorMatrixClassic[box2.x][box2.y] = tempColor;

                //    int tempX = box1.x;
                //    box1.x = box2.x;
                //    box2.x = tempX;

                //    int tempY = box1.y;
                //    box1.y = box2.y;
                //    box2.y = tempY;

                //    box1.transform.position = box1.CalculatationPosition(box1.x, box1.y);
                //    //DataManager.ins.colorMatrixClassic[box1.x][box1.y] = boxMatrixClassic[box1.x][box1.y].GetComponent<Box>().type;
                //    box2.transform.position = box2.CalculatationPosition(box2.x, box2.y);
                //    //DataManager.ins.colorMatrixClassic[box2.x][box2.y] = boxMatrixClassic[box2.x][box2.y].GetComponent<Box>().type;
                //}
            }

            CheckWinLoseClassic();
            SaveBoxClassic();
            moveBox.Clear();
            clickBox1 = false;
            clickBox2 = false;
            useIt1 = false;
            ((UIClassic)UIController.ins.currentScreen).it2.enabled = true;
            ((UIClassic)UIController.ins.currentScreen).it3.enabled = true;
            ((UIClassic)UIController.ins.currentScreen).selectIT1.SetActive(false);
        }
    }

    public void Item2Classic(int x, int y)
    {
        AudioManager.ins.PlaySFX("it2");
        AddScoreClassic(5);
        ColorExplosionClassic1(x, y);
        Destroy(boxMatrixClassic[x][y]);
        boxMatrixClassic[x][y] = null;
        MoveBoxClassic();
        CheckWinLoseClassic();
        SaveBoxClassic();
        breakBox.Clear();
        useIt2 = false;
        ((UIClassic)UIController.ins.currentScreen).it1.enabled = true;
        ((UIClassic)UIController.ins.currentScreen).it3.enabled = true;
        ((UIClassic)UIController.ins.currentScreen).selectIT2.SetActive(false);
    }

    public void Item3Classic(int x, int y)
    {
        AudioManager.ins.PlaySFX("it3");
        ColorExplosionClassic1(x, y);
        Destroy(boxMatrixClassic[x][y]);
        boxMatrixClassic[x][y] = null;
        int color = UnityEngine.Random.Range(1, 6);
        GameObject box1 = Instantiate(this.boxClassic[color - 1]);
        box1.GetComponent<Box>().OnSpawn(x, y, (BoxType)color);
        boxMatrixClassic[x][y] = box1;
        box1.transform.position = box1.GetComponent<Box>().CalculatationPosition(x, y);
        DataManager.ins.colorMatrixClassic[x][y] = boxMatrixClassic[x][y].GetComponent<Box>().type;
        CheckWinLoseClassic();
        SaveBoxClassic();
        useIt3 = false;
        ((UIClassic)UIController.ins.currentScreen).it1.enabled = true;
        ((UIClassic)UIController.ins.currentScreen).it2.enabled = true;
        ((UIClassic)UIController.ins.currentScreen).selectIT3.SetActive(false);
    }

    public void Item1Survival()
    {
        if (clickBox1 == true && clickBox2 == true && moveBox.Count == 2)
        {

            CheckWinLoseSurvival();
            SaveBoxSurvival();
        }
        moveBox.Clear();
        clickBox1 = false;
        clickBox2 = false;
        useIt1 = false;
        ((UISurvival)UIController.ins.currentScreen).it2.enabled = true;
        ((UISurvival)UIController.ins.currentScreen).it3.enabled = true;
        ((UISurvival)UIController.ins.currentScreen).selectIT1.SetActive(false);
    }


    public void Item2Survival(int x, int y)
    {
        AudioManager.ins.PlaySFX("it2");
        AddScoreSurvival(5);
        ColorExplosionSurvival1(x, y);
        Destroy(boxMatrixSurvival[x][y]);
        boxMatrixSurvival[x][y] = null;
        MoveBoxSurvival();
        CheckWinLoseSurvival();
        SaveBoxSurvival();
        breakBox.Clear();
        useIt2 = false;
        ((UISurvival)UIController.ins.currentScreen).it1.enabled = true;
        ((UISurvival)UIController.ins.currentScreen).it3.enabled = true;
        ((UISurvival)UIController.ins.currentScreen).selectIT2.SetActive(false);
    }

    public void Item3Survival(int x, int y)
    {
        AudioManager.ins.PlaySFX("it3");
        ColorExplosionSurvival1(x, y);
        Destroy(boxMatrixSurvival[x][y]);
        boxMatrixSurvival[x][y] = null;
        int color = UnityEngine.Random.Range(1, 7);
        GameObject box1 = Instantiate(this.boxSurvival[color - 1]);
        box1.GetComponent<BoxSurvival>().OnSpawn(x, y, (BoxType2)color);
        boxMatrixSurvival[x][y] = box1;
        box1.transform.position = box1.GetComponent<BoxSurvival>().CalculatationPosition(x, y);
        DataManager.ins.colorMatrixSurvival[x][y] = boxMatrixSurvival[x][y].GetComponent<BoxSurvival>().type;
        CheckWinLoseSurvival();
        SaveBoxSurvival();
        useIt3 = false;
        ((UISurvival)UIController.ins.currentScreen).it1.enabled = true;
        ((UISurvival)UIController.ins.currentScreen).it2.enabled = true;
        ((UISurvival)UIController.ins.currentScreen).selectIT3.SetActive(false);
    }
}