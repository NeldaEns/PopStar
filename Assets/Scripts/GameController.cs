using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public List<List<GameObject>> boxMatrixCasual;

    public List<List<GameObject>> boxMatrixClassic;

    public List<List<GameObject>> boxMatrixSurvival;
    public List<List<GameObject>> bombMatrix;

    public List<GameObject> boxCasual;
    public List<GameObject> boxClassic;
    public List<GameObject> boxSurvival;
    public List<GameObject> listBomb;
    public List<GameObject> breakBox;
    public GameObject explosionPrefabs;

    public bool useIt1;

    public bool useIt2;

    public bool useIt3;

    public bool clickBox1;
    public bool clickBox2;
    public List<GameObject> moveBox;
    public List<GameObject> listBox;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance.gameObject);
        }

        instance = this;
    }
    private void Start()
    {
        boxMatrixCasual = new List<List<GameObject>>();      
        for (int i = 0; i < 10; i++)
        {
            List<GameObject> listBoxCasual = new List<GameObject>();

            for (int j = 0; j < 10; j++)
            {
                listBoxCasual.Add(null);
            }
            boxMatrixCasual.Add(listBoxCasual);
        }
        boxMatrixClassic = new List<List<GameObject>>();
        for (int i = 0; i < 10; i++)
        {
            List<GameObject> listBoxClassic = new List<GameObject>();
            for(int j = 0; j < 10; j++)
            {
                listBoxClassic.Add(null);
            }
            boxMatrixClassic.Add(listBoxClassic);
        }
        boxMatrixSurvival = new List<List<GameObject>>();
        for(int i = 0; i < 15; i++)
        {
            List<GameObject> listBoxSurvival = new List<GameObject>();
            for(int j = 0; j < 15; j++)
            {
                listBoxSurvival.Add(null);
            }
            boxMatrixSurvival.Add(listBoxSurvival);
        }

        bombMatrix = new List<List<GameObject>>();
        for(int i = 0; i < 10; i++)
        {
            List<GameObject> listBomb = new List<GameObject>();
            for(int j = 0; j < 10; j++)
            {
                listBomb.Add(null);
            }
            bombMatrix.Add(listBomb);
        }
        if (DataManager.ins.casualGame == true && DataManager.ins.classicGame == false && DataManager.ins.survivalGame == false)
        {
            if (DataManager.ins.start_new_game_casual == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        SpawnBoxCasual(i, j);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        SpawnBoxCasual1(i, j);
                    }
                }
            }
        }
        if (DataManager.ins.classicGame == true && DataManager.ins.casualGame == false && DataManager.ins.survivalGame == false)
        {
            if (DataManager.ins.start_new_game_classic == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        SpawnBoxClassic(i, j);
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
                    }
                }
            }
        }
        if(DataManager.ins.survivalGame == true && DataManager.ins.casualGame == false && DataManager.ins.classicGame == false)
        {
            if(DataManager.ins.start_new_game_survival == true)
            {
                for(int i = 0; i < 15; i++)
                {
                    for(int j = 0; j < 15; j++)
                    {
                        SpawnBoxSurvival(i, j);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        
                        SpawnBoxSurvival1(i, j);
                    }
                }
            }
        }
    }

    public void SpawnBoxCasual(int x, int y)
    {
        int color = Random.Range(1, 6);
        GameObject box1 = Instantiate(boxCasual[color - 1]);
        Vector3 pos = box1.GetComponent<Box>().CalculatationPosition(x, y);
        box1.transform.position = pos;
        box1.GetComponent<Box>().OnSpawn(x, y, (BoxType)color);
        boxMatrixCasual[x][y] = box1;
    }

    public void SpawnBoxClassic(int x, int y)
    {
        int color = Random.Range(1, 6);
        GameObject box1 = Instantiate(boxClassic[color - 1]);
        Vector3 pos = box1.GetComponent<BoxClassic>().CalculatationPosition(x, y);
        box1.transform.position = pos;
        box1.GetComponent<BoxClassic>().OnSpawn(x, y, (BoxType1)color);
        boxMatrixClassic[x][y] = box1;
    }

    public void SpawnBoxSurvival(int x, int y)
    {
        int color = Random.Range(1, 7);
        GameObject box1 = Instantiate(boxSurvival[color - 1]);
        Vector3 pos = box1.GetComponent<BoxSurvival>().CalculatationPosition(x, y);
        box1.transform.position = pos;
        box1.GetComponent<BoxSurvival>().OnSpawn(x, y, (BoxType2)color);
        boxMatrixSurvival[x][y] = box1;
    }

    public void SpawnBomb(int x, int y)
    {
        int bomb = Random.Range(1, 2);
        GameObject bom = Instantiate(listBomb[bomb - 1]);
        Vector3 pos = bom.GetComponent<Bomb>().CalculatationPosition(x, y);
        bom.transform.position = pos;
        bom.GetComponent<Bomb>().OnSpawn(x, y, (Bom)bomb);
        bombMatrix[x][y] = bom;
    }

    public void SpawnBoxCasual1(int x, int y)
    {
        BoxType color1 = DataManager.ins.colorMatrixCasual[x][y];
        if (color1 == BoxType.None)
        {
            boxMatrixCasual[x][y] = null;
        }
        else
        {
            GameObject box2 = Instantiate(this.boxCasual[(int)color1 - 1]);
            Vector3 pos = box2.GetComponent<Box>().CalculatationPosition(x, y);
            box2.transform.position = pos;
            box2.GetComponent<Box>().OnSpawn(x, y, color1);
            boxMatrixCasual[x][y] = box2;
        }
    }

    public void SpawnBomb1(int x, int y)
    {
        Bom bomb = DataManager.ins.bombMatrix[x][y];
        if (bomb == Bom.None)
        {
            bombMatrix[x][y] = null;
        }
        else
        {
            GameObject bomb2 = Instantiate(this.listBomb[(int)bomb - 1]);
            Vector3 pos = bomb2.GetComponent<Bomb>().CalculatationPosition(x, y);
            bomb2.transform.position = pos;
            bomb2.GetComponent<Bomb>().OnSpawn(x, y, bomb);
            bombMatrix[x][y] = bomb2;
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

    public void SpawnBoxClassic1(int x, int y)
    {      
        BoxType1 color1 = DataManager.ins.colorMatrixClassic[x][y];
        if (color1 == BoxType1.None)
        {
            boxMatrixClassic[x][y] = null;
        }
        else
        {
            GameObject box2 = Instantiate(this.boxClassic[(int)color1 - 1]);
            Vector3 pos = box2.GetComponent<BoxClassic>().CalculatationPosition(x, y);
            box2.transform.position = pos;
            box2.GetComponent<BoxClassic>().OnSpawn(x, y, color1);
            boxMatrixClassic[x][y] = box2;
        }
    }

    public void FindBreakBoxCasual()
    {
        for (int i = 0; i < breakBox.Count; i++)
        {
            int x = breakBox[i].GetComponent<Box>().x;
            int y = breakBox[i].GetComponent<Box>().y;
            if (x > 0 && boxMatrixCasual[x - 1][y] != null && boxMatrixCasual[x - 1][y].GetComponent<Box>().type == breakBox[i].GetComponent<Box>().type && !KTBoxCasual(boxMatrixCasual[x - 1][y]))
            {
                        breakBox.Add(boxMatrixCasual[x - 1][y]);
            }
            if (x < 9 && boxMatrixCasual[x + 1][y] != null && boxMatrixCasual[x + 1][y].GetComponent<Box>().type == breakBox[i].GetComponent<Box>().type && !KTBoxCasual(boxMatrixCasual[x + 1][y]))
            {
                        breakBox.Add(boxMatrixCasual[x + 1][y]);
            }
            if (y > 0 && boxMatrixCasual[x][y - 1] != null && boxMatrixCasual[x][y - 1].GetComponent<Box>().type == breakBox[i].GetComponent<Box>().type && !KTBoxCasual(boxMatrixCasual[x][y - 1]))
            {
                        breakBox.Add(boxMatrixCasual[x][y - 1]);
            }
            if (y < 9 && boxMatrixCasual[x][y + 1] != null && boxMatrixCasual[x][y + 1].GetComponent<Box>().type == breakBox[i].GetComponent<Box>().type && !KTBoxCasual(boxMatrixCasual[x][y + 1]))
            {
                        breakBox.Add(boxMatrixCasual[x][y + 1]);
            }
        }
        if (breakBox.Count > 1)
        {
            BreakBoxCasual();

            MoveBoxCasual();

            SaveBoxCasual();
           
        }
        breakBox.Clear();
        CheckWinLoseCasual();
    }

    public void FindBreakBoxClassic()
    {
        for (int i = 0; i < breakBox.Count; i++)
        {
            int x = breakBox[i].GetComponent<BoxClassic>().x;
            int y = breakBox[i].GetComponent<BoxClassic>().y;
            if (x > 0 && boxMatrixClassic[x - 1][y] != null && boxMatrixClassic[x - 1][y].GetComponent<BoxClassic>().type == breakBox[i].GetComponent<BoxClassic>().type && !KTBoxClassic(boxMatrixClassic[x - 1][y]))
            {
                breakBox.Add(boxMatrixClassic[x - 1][y]);
            }
            if (x < 9 && boxMatrixClassic[x + 1][y] != null && boxMatrixClassic[x + 1][y].GetComponent<BoxClassic>().type == breakBox[i].GetComponent<BoxClassic>().type && !KTBoxClassic(boxMatrixClassic[x + 1][y]))
            {
                breakBox.Add(boxMatrixClassic[x + 1][y]);
            }
            if (y > 0 && boxMatrixClassic[x][y - 1] != null && boxMatrixClassic[x][y - 1].GetComponent<BoxClassic>().type == breakBox[i].GetComponent<BoxClassic>().type && !KTBoxClassic(boxMatrixClassic[x][y - 1]))
            {
                breakBox.Add(boxMatrixClassic[x][y - 1]);
            }
            if (y < 9 && boxMatrixClassic[x][y + 1] != null && boxMatrixClassic[x][y + 1].GetComponent<BoxClassic>().type == breakBox[i].GetComponent<BoxClassic>().type && !KTBoxClassic(boxMatrixClassic[x][y + 1]))
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
            if (x < 14 && boxMatrixSurvival[x + 1][y] != null && boxMatrixSurvival[x + 1][y].GetComponent<BoxSurvival>().type == breakBox[i].GetComponent<BoxSurvival>().type && !KTBoxSurvival(boxMatrixSurvival[x + 1][y]))
            {
                breakBox.Add(boxMatrixSurvival[x + 1][y]);
            }
            if (y > 0 && boxMatrixSurvival[x][y - 1] != null && boxMatrixSurvival[x][y - 1].GetComponent<BoxSurvival>().type == breakBox[i].GetComponent<BoxSurvival>().type && !KTBoxSurvival(boxMatrixSurvival[x][y - 1]))
            {
                breakBox.Add(boxMatrixSurvival[x][y - 1]);
            }
            if (y < 14 && boxMatrixSurvival[x][y + 1] != null && boxMatrixSurvival[x][y + 1].GetComponent<BoxSurvival>().type == breakBox[i].GetComponent<BoxSurvival>().type && !KTBoxSurvival(boxMatrixSurvival[x][y + 1]))
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

    public void BreakBoxCasual()
    {
        for (int i = 0; i < breakBox.Count; i++)
        {
            int j = 5;
            j = j + i * 10;
            if(breakBox.Count == 2)
            {
                AudioManager.ins.PlaySFX("click");
            }
            if(breakBox.Count > 2 && breakBox.Count < 5 )
            {
                AudioManager.ins.PlaySFX("good");
            }
            if(breakBox.Count > 4 && breakBox.Count < 7)
            {
                AudioManager.ins.PlaySFX("great");
            }
            if (breakBox.Count > 6 && breakBox.Count < 9 )
            {
                AudioManager.ins.PlaySFX("excellent");
            }
            if (breakBox.Count > 8 && breakBox.Count < 11)
            {
                AudioManager.ins.PlaySFX("amazing");
            }
            if (breakBox.Count > 10)
            {
                AudioManager.ins.PlaySFX("unbelievable");
            }
            AddScoreCasual(j);
            GameObject explosion = Instantiate(explosionPrefabs);
            explosion.GetComponent<ParticleSystem>().Play();
            explosion.transform.position = breakBox[i].transform.position;
            Destroy(breakBox[i]);
            Destroy(explosion, 0.5f);
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
                AudioManager.ins.PlaySFX("click");
            }
            if (breakBox.Count > 2 && breakBox.Count < 5)
            {
                AudioManager.ins.PlaySFX("good");
            }
            if (breakBox.Count > 4 && breakBox.Count < 7)
            {
                AudioManager.ins.PlaySFX("great");
            }
            if (breakBox.Count > 6 && breakBox.Count < 9)
            {
                AudioManager.ins.PlaySFX("excellent");
            }
            if (breakBox.Count > 8 && breakBox.Count < 11)
            {
                AudioManager.ins.PlaySFX("amazing");
            }
            if (breakBox.Count > 10)
            {
                AudioManager.ins.PlaySFX("unbelievable");
            }
            AddScoreClassic(j);
            GameObject explosion = Instantiate(explosionPrefabs);
            explosion.GetComponent<ParticleSystem>().Play();
            explosion.transform.position = breakBox[i].transform.position;
            Destroy(breakBox[i]);
            Destroy(explosion, 0.5f);
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
                AudioManager.ins.PlaySFX("click");
            }
            if (breakBox.Count > 2 && breakBox.Count < 5)
            {
                AudioManager.ins.PlaySFX("good");
            }
            if (breakBox.Count > 4 && breakBox.Count < 7)
            {
                AudioManager.ins.PlaySFX("great");
            }
            if (breakBox.Count > 6 && breakBox.Count < 9)
            {
                AudioManager.ins.PlaySFX("excellent");
            }
            if (breakBox.Count > 8 && breakBox.Count < 11)
            {
                AudioManager.ins.PlaySFX("amazing");
            }
            if (breakBox.Count > 10)
            {
                AudioManager.ins.PlaySFX("unbelievable");
            }
            AddScoreSurvival(j);
            GameObject explosion = Instantiate(explosionPrefabs);
            explosion.GetComponent<ParticleSystem>().Play();
            explosion.transform.position = breakBox[i].transform.position;
            Destroy(breakBox[i]);
            Destroy(explosion, 0.5f);
        }
    }

    public void MoveBoxCasual()
    {
        for (int i = 0; i < breakBox.Count; i++)
        {

            int x = breakBox[i].GetComponent<Box>().x;
            int y = breakBox[i].GetComponent<Box>().y;
            for (int j = y; j < 9; j++)
            {
                boxMatrixCasual[x][j] = boxMatrixCasual[x][j + 1];
                if (boxMatrixCasual[x][j] != null)
                {
                    boxMatrixCasual[x][j].GetComponent<Box>().y--;
                    boxMatrixCasual[x][j].GetComponent<Box>().MoveDown();
                }
            }
            boxMatrixCasual[x][9] = null;
        }

        for (int i = 8; i >= 0; i--)
        {

            if (boxMatrixCasual[i][0] == null)
            {
                for (int j = i; j < 9; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        boxMatrixCasual[j][k] = boxMatrixCasual[j + 1][k];
                        if (boxMatrixCasual[j][k] != null)
                        {
                            boxMatrixCasual[j][k].GetComponent<Box>().x--;
                            boxMatrixCasual[j][k].GetComponent<Box>().MoveLeft();
                        }
                    }
                }
                for (int h = 0; h < 10; h++)
                {
                    boxMatrixCasual[9][h] = null;
                }
            }
        }
    }

    public void MoveBoxClassic()
    {
        for (int i = 0; i < breakBox.Count; i++)
        {

            int x = breakBox[i].GetComponent<BoxClassic>().x;
            int y = breakBox[i].GetComponent<BoxClassic>().y;
            for (int j = y; j < 9; j++)
            {
                boxMatrixClassic[x][j] = boxMatrixClassic[x][j + 1];
                if (boxMatrixClassic[x][j] != null)
                {
                    boxMatrixClassic[x][j].GetComponent<BoxClassic>().y--;
                    boxMatrixClassic[x][j].GetComponent<BoxClassic>().MoveDown();
                }
            }
            boxMatrixClassic[x][9] = null;
        }

        for (int i = 9; i >= 0; i--)
        {
            if (boxMatrixClassic[i][0] == null)
            {
                for (int j = i; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {                       
                        if (boxMatrixClassic[j][k] == null)
                        {
                            SpawnBoxClassic(j, k);
                        }
                    }
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
            for (int j = y; j < 14; j++)
            {
                boxMatrixSurvival[x][j] = boxMatrixSurvival[x][j + 1];
                if (boxMatrixSurvival[x][j] != null)
                {
                    boxMatrixSurvival[x][j].GetComponent<BoxSurvival>().y--;
                    boxMatrixSurvival[x][j].GetComponent<BoxSurvival>().MoveDown();
                }
            }
            boxMatrixSurvival[x][14] = null;
        }

        for (int i = 14; i >= 0; i--)
        {
            if (boxMatrixSurvival[i][0] == null)
            {
                for (int k = 0; k < 15; k++)
                {
                    if (boxMatrixSurvival[i][k] == null)
                    {
                        SpawnBoxSurvival(i, k);
                    }
                }
            }       
        }
    }

    public void SaveBoxCasual()
    {
        for (int i = 0; i < boxMatrixCasual.Count; i++)
        {
            for (int j = 0; j < boxMatrixCasual[i].Count; j++)
            {
                if (boxMatrixCasual[i][j] == null)
                {
                    DataManager.ins.colorMatrixCasual[i][j] = BoxType.None;
                }
                else
                {
                    DataManager.ins.colorMatrixCasual[i][j] = boxMatrixCasual[i][j].GetComponent<Box>().type;
                }
            }
        }
        DataManager.ins.SaveJsonCasual();
    }

    public void SaveBoxClassic()
    {
        for (int i = 0; i < boxMatrixClassic.Count; i++)
        {
            for (int j = 0; j < boxMatrixClassic[i].Count; j++)
            {
                if (boxMatrixClassic[i][j] == null)
                {
                    DataManager.ins.colorMatrixClassic[i][j] = BoxType1.None;
                }
                else
                {
                    DataManager.ins.colorMatrixClassic[i][j] = boxMatrixClassic[i][j].GetComponent<BoxClassic>().type;
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

    public void SaveBombSurvival()
    {
        for(int i = 0; i < bombMatrix.Count; i++)
        {
            for(int j = 0; j < bombMatrix[i].Count; j++)
            {
                if(bombMatrix[i][j] == null)
                {
                    DataManager.ins.bombMatrix[i][j] = Bom.None;
                }
                else
                {
                    DataManager.ins.bombMatrix[i][j] = bombMatrix[i][j].GetComponent<Bomb>().bomb;
                }
            }
        }
        DataManager.ins.SaveJsonBomb();
    }

    public void CheckWinLoseCasual()
    {
        if (KTGameLoseCasual())
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Destroy(boxMatrixCasual[j][i]);
                    boxMatrixCasual[j][i] = null;
                }
            }
            if (DataManager.ins.scoreCasual >= DataManager.ins.target)
            {
                DataManager.ins.level++;
                DataManager.ins.coin++;
                DataManager.ins.SaveLevel();
                DataManager.ins.SaveCoin();
                DataManager.ins.target = DataManager.ins.target + 1750;
                DataManager.ins.SaveTarget();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        AudioManager.ins.PlaySFX("gamestart");
                        SpawnBoxCasual(i, j);
                        DataManager.ins.colorMatrixCasual[i][j] = boxMatrixCasual[i][j].GetComponent<Box>().type;
                    }
                }
                DataManager.ins.SaveJsonCasual();
            }
            else
            {
                UIController.ins.ShowGameOverCasual();
                ((GameOverScreenCasual)UIController.ins.currentScreen).ScoreCasual();
                ((GameOverScreenCasual)UIController.ins.currentScreen).HighScoreCasual();
            }
        }
    }

    public void CheckWinLoseClassic()
    {
        if (KTGameLoseClassic())
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Destroy(boxMatrixClassic[j][i], 0.05f);
                    boxMatrixClassic[j][i] = null;
                }
            }
            UIController.ins.ShowGameOverClassic();
            ((GameOverScreenClassic)UIController.ins.currentScreen).ScoreClassic();
            ((GameOverScreenClassic)UIController.ins.currentScreen).HighScoreClassic();
        }
    }

    public void CheckWinLoseSurvival()
    {
        if (KTGameLoseSurvival())
        {                         
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Destroy(boxMatrixSurvival[j][i], 0.05f);
                    boxMatrixSurvival[j][i] = null;
                }
            }
            UIController.ins.ShowGameOverSurvival();
            ((SurvivalGameOverScreen)UIController.ins.currentScreen).ScoreSurvival();
            ((SurvivalGameOverScreen)UIController.ins.currentScreen).HighScoreSurvival();
        }
    }

    public void AddScoreCasual(int addedScore)
    {
        DataManager.ins.scoreCasual += addedScore;
        DataManager.ins.SaveScoreCasual();
        ((UICasual)UIController.ins.currentScreen).UpdateScoreText();
        if(DataManager.ins.scoreCasual > DataManager.ins.highScoreCasual)
        {
            DataManager.ins.highScoreCasual = DataManager.ins.scoreCasual;
            DataManager.ins.SaveHighScoreCasual();
        }
        ((UICasual)UIController.ins.currentScreen).UpdateHighScoreText();
        ((UICasual)UIController.ins.currentScreen).UpdateTargetText();
        ((UICasual)UIController.ins.currentScreen).UpdateLevelText();
        ((UICasual)UIController.ins.currentScreen).UpdateCoinText();
    }

    public void AddScoreClassic(int addScore)
    {
        DataManager.ins.scoreClassic += addScore;
        DataManager.ins.SaveScoreClassic();
        ((UIClassic)UIController.ins.currentScreen).UpdateScoreText();
        if (DataManager.ins.scoreClassic > DataManager.ins.highScoreClassic)
        {
            DataManager.ins.highScoreClassic = DataManager.ins.scoreClassic;
            DataManager.ins.SaveHighScoreClassic();
        }
        ((UIClassic)UIController.ins.currentScreen).UpdateHighScoreText();
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

    public bool KTGameLoseCasual()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {

                if ( j < 9 && boxMatrixCasual[j + 1][i] != null && boxMatrixCasual[j][i] != null)
                {
                    bool kt1 = boxMatrixCasual[j][i].GetComponent<Box>().type == boxMatrixCasual[j + 1][i].GetComponent<Box>().type;
                    if (kt1)
                    {           
                        return false;
                    }
                }

                if (i < 9 && boxMatrixCasual[j][i + 1] != null && boxMatrixCasual[j][i] != null)
                {
                    bool kt1 = boxMatrixCasual[j][i].GetComponent<Box>().type == boxMatrixCasual[j][i + 1].GetComponent<Box>().type;
                    if (kt1)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public bool KTGameLoseClassic()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {

                if (j < 9 && boxMatrixClassic[j + 1][i] != null && boxMatrixClassic[j][i] != null)
                {
                    bool kt1 = boxMatrixClassic[j][i].GetComponent<BoxClassic>().type == boxMatrixClassic[j + 1][i].GetComponent<BoxClassic>().type;
                    if (kt1)
                    {
                        return false;
                    }
                }

                if (i < 9 && boxMatrixClassic[j][i + 1] != null && boxMatrixClassic[j][i] != null)
                {
                    bool kt1 = boxMatrixClassic[j][i].GetComponent<BoxClassic>().type == boxMatrixClassic[j][i + 1].GetComponent<BoxClassic>().type;
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
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                if (j < 14 && boxMatrixSurvival[j + 1][i] != null && boxMatrixSurvival[j][i] != null)
                {                    
                    bool kt1 = boxMatrixSurvival[j][i].GetComponent<BoxSurvival>().type == boxMatrixSurvival[j + 1][i].GetComponent<BoxSurvival>().type;
                    if (kt1)
                    {
                        return false;
                    }                    
                }

                if (i < 14 && boxMatrixSurvival[j][i + 1] != null && boxMatrixSurvival[j][i] != null)
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

    public bool KTBoxCasual(GameObject box)
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

    public bool KTBoxClassic(GameObject box)
    {
        for (int i = 0; i < breakBox.Count; i++)
        {
            int boxX = box.GetComponent<BoxClassic>().x;
            int boxY = box.GetComponent<BoxClassic>().y;

            int breakBoxX = breakBox[i].GetComponent<BoxClassic>().x;
            int breakBoxY = breakBox[i].GetComponent<BoxClassic>().y;

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

    public void ClickMoveBoxCasual1(int x, int y)
    {
        AudioManager.ins.PlaySFX("it1");
        moveBox.Add(boxMatrixCasual[x][y]);
        clickBox1 = true;       
    }

    public void ClickMoveBoxClassic1(int x, int y)
    {
        AudioManager.ins.PlaySFX("it1");
        moveBox.Add(boxMatrixClassic[x][y]);
        clickBox1 = true;
    }

    public void ClickMoveBoxCasual2(int x, int y)
    {
        AudioManager.ins.PlaySFX("it1");
        moveBox.Add(boxMatrixCasual[x][y]);
        clickBox2 = true;       
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

    public void Item1Casual()
    {
        if (clickBox1 == true && clickBox2 == true)
        {
            if (moveBox.Count == 2)
            {
                int x1 = moveBox[0].GetComponent<Box>().x;
                int y1 = moveBox[0].GetComponent<Box>().y;
                int x2 = moveBox[1].GetComponent<Box>().x;
                int y2 = moveBox[1].GetComponent<Box>().y;

                BoxType color1 = boxMatrixCasual[x1][y1].GetComponent<Box>().type;
                BoxType color2 = boxMatrixCasual[x2][y2].GetComponent<Box>().type;
                BoxType temp;

                if (x1 > 0 && x2 == x1 - 1 && y1 == y2 && boxMatrixCasual[x2][y2] != null && boxMatrixCasual[x1][y1].GetComponent<Box>().type != boxMatrixCasual[x2][y2].GetComponent<Box>().type)
                {

                    boxMatrixCasual[x1][y1].GetComponent<Box>().x--;
                    boxMatrixCasual[x1][y1].GetComponent<Box>().MoveLeft1();
                    boxMatrixCasual[x2][y2].GetComponent<Box>().x++;
                    boxMatrixCasual[x2][y2].GetComponent<Box>().MoveRight();
                    boxMatrixCasual[x1][y1] = boxMatrixCasual[x2][y2];
                    x1 = x2;
                    x2 = x1 + 1;
                    temp = color1;
                    color1 = color2;
                    color2 = temp;
                    boxMatrixCasual[x1][y1].transform.position = boxMatrixCasual[x1][y1].GetComponent<Box>().CalculatationPosition(x1, y1);
                    DataManager.ins.colorMatrixCasual[x1][y1] = boxMatrixCasual[x1][y1].GetComponent<Box>().type;

                    boxMatrixCasual[x2][y2].transform.position = boxMatrixCasual[x2][y2].GetComponent<Box>().CalculatationPosition(x2, y2);
                    DataManager.ins.colorMatrixCasual[x1][y1] = boxMatrixCasual[x1][y1].GetComponent<Box>().type;

                }
                if (x1 < 14 && boxMatrixCasual[x2][y2] != null &&  x2 == x1 + 1 && y1 == y2 && boxMatrixCasual[x1][y1].GetComponent<Box>().type != boxMatrixCasual[x2][y2].GetComponent<Box>().type)
                {
                    boxMatrixCasual[x1][y1].GetComponent<Box>().x++;
                    boxMatrixCasual[x1][y1].GetComponent<Box>().MoveRight();
                    boxMatrixCasual[x2][y2].GetComponent<Box>().x--;
                    boxMatrixCasual[x2][y2].GetComponent<Box>().MoveLeft1();
                    boxMatrixCasual[x2][y2] = boxMatrixCasual[x1][y1];
                    x1 = x2;
                    x2 = x1 - 1;
                    temp = color1;
                    color1 = color2;
                    color2 = temp;
                    boxMatrixCasual[x2][y2].transform.position = boxMatrixCasual[x2][y2].GetComponent<Box>().CalculatationPosition(x2, y2);
                    DataManager.ins.colorMatrixCasual[x2][y2] = boxMatrixCasual[x2][y2].GetComponent<Box>().type;

                    boxMatrixCasual[x1][y1].transform.position = boxMatrixCasual[x1][y1].GetComponent<Box>().CalculatationPosition(x1, y1);
                    DataManager.ins.colorMatrixCasual[x1][y1] = boxMatrixCasual[x1][y1].GetComponent<Box>().type;
                }
                if (y1 > 0 && boxMatrixCasual[x2][y2] != null &&  y2 == y1 - 1 && x1 == x2 && boxMatrixCasual[x1][y1].GetComponent<Box>().type != boxMatrixCasual[x2][y2].GetComponent<Box>().type)
                {
                    boxMatrixCasual[x1][y1].GetComponent<Box>().y--;
                    boxMatrixCasual[x1][y1].GetComponent<Box>().MoveDown1();
                    boxMatrixCasual[x2][y2].GetComponent<Box>().y++;
                    boxMatrixCasual[x2][y2].GetComponent<Box>().MoveUp();
                    boxMatrixCasual[x1][y1] = boxMatrixCasual[x2][y2];
                    y1 = y2;
                    y2 = y1 + 1;
                    temp = color1;
                    color1 = color2;
                    color2 = temp;
                    boxMatrixCasual[x1][y1].transform.position = boxMatrixCasual[x1][y1].GetComponent<Box>().CalculatationPosition(x1, y1);
                    DataManager.ins.colorMatrixCasual[x1][y1] = boxMatrixCasual[x1][y1].GetComponent<Box>().type;

                    boxMatrixCasual[x2][y2].transform.position = boxMatrixCasual[x2][y2].GetComponent<Box>().CalculatationPosition(x2, y2);
                    DataManager.ins.colorMatrixCasual[x2][y2] = boxMatrixCasual[x2][y2].GetComponent<Box>().type;
                }
                if (y1 < 14 && boxMatrixCasual[x2][y2] != null &&  y2 == y1 + 1 && x1 == x2 && boxMatrixCasual[x1][y1].GetComponent<Box>().type != boxMatrixCasual[x2][y2].GetComponent<Box>().type)
                {
                    boxMatrixCasual[x1][y1].GetComponent<Box>().y++;
                    boxMatrixCasual[x1][y1].GetComponent<Box>().MoveUp();
                    boxMatrixCasual[x2][y2].GetComponent<Box>().y--;
                    boxMatrixCasual[x2][y2].GetComponent<Box>().MoveDown1();
                    boxMatrixCasual[x2][y2] = boxMatrixCasual[x1][y1];
                    y1 = y2;
                    y2 = y1 - 1;
                    temp = color1;
                    color1 = color2;
                    color2 = temp;
                    boxMatrixCasual[x2][y2].transform.position = boxMatrixCasual[x2][y2].GetComponent<Box>().CalculatationPosition(x2, y2);
                    DataManager.ins.colorMatrixCasual[x1][y1] = boxMatrixCasual[x1][y1].GetComponent<Box>().type;

                    boxMatrixCasual[x1][y1].transform.position = boxMatrixCasual[x1][y1].GetComponent<Box>().CalculatationPosition(x1, y1);
                    DataManager.ins.colorMatrixCasual[x1][y1] = boxMatrixCasual[x1][y1].GetComponent<Box>().type;
                }
                CheckWinLoseCasual();
                SaveBoxCasual();
            }         
            moveBox.Clear();
            clickBox1 = false;
            clickBox2 = false;
            useIt1 = false;
        }      
    }

    public void Item2Casual(int x, int y)
    {
        AudioManager.ins.PlaySFX("it2");
        AddScoreCasual(5);
        GameObject explosion = Instantiate(explosionPrefabs);
        explosion.GetComponent<ParticleSystem>().Play();
        explosion.transform.position = boxMatrixCasual[x][y].transform.position;
        Destroy(boxMatrixCasual[x][y]);
        Destroy(explosion, 0.5f);
        boxMatrixCasual[x][y] = null;
        MoveBoxCasual();
        CheckWinLoseCasual();
        SaveBoxCasual();
        breakBox.Clear();
        useIt2 = false;
    }

    public void Item3Casual(int x, int y)
    {
        AudioManager.ins.PlaySFX("it3");
        GameObject explosion = Instantiate(explosionPrefabs);
        explosion.GetComponent<ParticleSystem>().Play();
        explosion.transform.position = boxMatrixCasual[x][y].transform.position;
        Destroy(boxMatrixCasual[x][y]);
        Destroy(explosion, 0.5f);
        boxMatrixCasual[x][y] = null;
        int color = Random.Range(1, 6);
        GameObject box1 = Instantiate(this.boxCasual[color - 1]);
        box1.GetComponent<Box>().OnSpawn(x, y, (BoxType)color);
        boxMatrixCasual[x][y] = box1;
        box1.transform.position = box1.GetComponent<Box>().CalculatationPosition(x, y);
        DataManager.ins.colorMatrixCasual[x][y] = boxMatrixCasual[x][y].GetComponent<Box>().type;
        CheckWinLoseCasual();
        SaveBoxCasual();     
        useIt3 = false;
    }

    public void Item1Classic()
    {
        if (clickBox1 == true && clickBox2 == true)
        {
            if (moveBox.Count == 2)
            {
                int x1 = moveBox[0].GetComponent<BoxClassic>().x;
                int y1 = moveBox[0].GetComponent<BoxClassic>().y;
                int x2 = moveBox[1].GetComponent<BoxClassic>().x;
                int y2 = moveBox[1].GetComponent<BoxClassic>().y;

                BoxType1 color1 = boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().type;
                BoxType1 color2 = boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().type;
                BoxType1 temp;
                if (x1 > 0 && x2 == x1 - 1 && y1 == y2 && boxMatrixClassic[x2][y2] != null && boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().type != boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().type)
                {

                    boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().x--;
                    boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().MoveLeft1();
                    boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().x++;
                    boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().MoveRight();
                    boxMatrixClassic[x1][y1] = boxMatrixClassic[x2][y2];
                    x1 = x2;
                    x2 = x1 + 1;
                    temp = color1;
                    color1 = color2;
                    color2 = temp;
                    boxMatrixClassic[x1][y1].transform.position = boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().CalculatationPosition(x1, y1);
                    DataManager.ins.colorMatrixClassic[x1][y1] = boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().type;

                    boxMatrixClassic[x2][y2].transform.position = boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().CalculatationPosition(x2, y2);
                    DataManager.ins.colorMatrixClassic[x1][y1] = boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().type;

                }
                if (x1 < 14 && boxMatrixClassic[x2][y2] != null && x2 == x1 + 1 && y1 == y2 && boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().type != boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().type)
                {
                    boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().x++;
                    boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().MoveRight();
                    boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().x--;
                    boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().MoveLeft1();
                    boxMatrixClassic[x2][y2] = boxMatrixClassic[x1][y1];
                    x1 = x2;
                    x2 = x1 - 1;
                    temp = color1;
                    color1 = color2;
                    color2 = temp;
                    boxMatrixClassic[x2][y2].transform.position = boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().CalculatationPosition(x2, y2);
                    DataManager.ins.colorMatrixClassic[x2][y2] = boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().type;

                    boxMatrixClassic[x1][y1].transform.position = boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().CalculatationPosition(x1, y1);
                    DataManager.ins.colorMatrixClassic[x1][y1] = boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().type;
                }
                if (y1 > 0 && boxMatrixClassic[x2][y2] != null &&  y2 == y1 - 1 && x1 == x2 && boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().type != boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().type)
                {
                    boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().y--;
                    boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().MoveDown1();
                    boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().y++;
                    boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().MoveUp();
                    boxMatrixClassic[x1][y1] = boxMatrixClassic[x2][y2];
                    y1 = y2;
                    y2 = y1 + 1;
                    temp = color1;
                    color1 = color2;
                    color2 = temp;
                    boxMatrixClassic[x1][y1].transform.position = boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().CalculatationPosition(x1, y1);
                    DataManager.ins.colorMatrixClassic[x1][y1] = boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().type;

                    boxMatrixClassic[x2][y2].transform.position = boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().CalculatationPosition(x2, y2);
                    DataManager.ins.colorMatrixClassic[x2][y2] = boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().type;
                }
                if (y1 < 14 && boxMatrixClassic[x2][y2] != null &&  y2 == y1 + 1 && x1 == x2 && boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().type != boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().type)
                {
                    boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().y++;
                    boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().MoveUp();
                    boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().y--;
                    boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().MoveDown1();
                    boxMatrixClassic[x2][y2] = boxMatrixClassic[x1][y1];
                    y1 = y2;
                    y2 = y1 - 1;
                    temp = color1;
                    color1 = color2;
                    color2 = temp;
                    boxMatrixClassic[x2][y2].transform.position = boxMatrixClassic[x2][y2].GetComponent<BoxClassic>().CalculatationPosition(x2, y2);
                    DataManager.ins.colorMatrixClassic[x1][y1] = boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().type;

                    boxMatrixClassic[x1][y1].transform.position = boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().CalculatationPosition(x1, y1);
                    DataManager.ins.colorMatrixClassic[x1][y1] = boxMatrixClassic[x1][y1].GetComponent<BoxClassic>().type;
                }
                CheckWinLoseClassic();
                SaveBoxClassic();
            }
            moveBox.Clear();
            clickBox1 = false;
            clickBox2 = false;
            useIt1 = false;
        }
    }

    public void Item2Classic(int x, int y)
    {
        AudioManager.ins.PlaySFX("it2");
        AddScoreClassic(5);
        GameObject explosion = Instantiate(explosionPrefabs);
        explosion.GetComponent<ParticleSystem>().Play();
        explosion.transform.position = boxMatrixClassic[x][y].transform.position;
        Destroy(boxMatrixClassic[x][y]);
        Destroy(explosion, 0.5f);
        boxMatrixClassic[x][y] = null;
        MoveBoxClassic();
        CheckWinLoseClassic();
        SaveBoxClassic();
        breakBox.Clear();
        useIt2 = false;
    }

    public void Item3Classic(int x, int y)
    {
        AudioManager.ins.PlaySFX("it3");
        GameObject explosion = Instantiate(explosionPrefabs);
        explosion.GetComponent<ParticleSystem>().Play();
        explosion.transform.position = boxMatrixClassic[x][y].transform.position;
        Destroy(boxMatrixClassic[x][y]);
        Destroy(explosion, 0.5f);
        boxMatrixClassic[x][y] = null;
        int color = Random.Range(1, 7);
        GameObject box1 = Instantiate(this.boxClassic[color - 1]);
        box1.GetComponent<BoxClassic>().OnSpawn(x, y, (BoxType1)color);
        boxMatrixClassic[x][y] = box1;
        box1.transform.position = box1.GetComponent<BoxClassic>().CalculatationPosition(x, y);
        DataManager.ins.colorMatrixClassic[x][y] = boxMatrixClassic[x][y].GetComponent<BoxClassic>().type;
        CheckWinLoseClassic();
        SaveBoxClassic();
        useIt3 = false;
    }

    public void Item1Survival()
    {
        if (clickBox1 == true && clickBox2 == true)
        {
            if (moveBox.Count == 2)
            {
                int x1 = moveBox[0].GetComponent<BoxSurvival>().x;
                int y1 = moveBox[0].GetComponent<BoxSurvival>().y;
                int x2 = moveBox[1].GetComponent<BoxSurvival>().x;
                int y2 = moveBox[1].GetComponent<BoxSurvival>().y;
                BoxType2 temp;
                BoxType2 color1 = boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().type;
                BoxType2 color2 = boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().type;

                if (x1 > 0 && x2 == x1 - 1 && y1 == y2 && boxMatrixSurvival[x2][y2] != null && boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().type != boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().type)
                {

                    boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().x--;
                    boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().MoveLeft1();
                    boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().x++;
                    boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().MoveRight();
                    boxMatrixSurvival[x1][y1] = boxMatrixSurvival[x2][y2];
                    x1 = x2;
                    x2 = x1 + 1;
                    temp = color1;
                    color1 = color2;
                    color2 = temp;
                    boxMatrixSurvival[x1][y1].transform.position = boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().CalculatationPosition(x1, y1);
                    DataManager.ins.colorMatrixSurvival[x1][y1] = boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().type;
                    boxMatrixSurvival[x2][y2].transform.position = boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().CalculatationPosition(x2, y2);
                    DataManager.ins.colorMatrixSurvival[x1][y1] = boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().type;

                }
                if (x1 < 14 && boxMatrixSurvival[x2][y2] != null && x2 == x1 + 1 && y1 == y2 && boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().type != boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().type)
                {
                    boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().x++;
                    boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().MoveRight();
                    boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().x--;
                    boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().MoveLeft1();
                    boxMatrixSurvival[x2][y2] = boxMatrixSurvival[x1][y1];
                    x1 = x2;
                    x2 = x1 - 1;
                    temp = color1;
                    color1 = color2;
                    color2 = temp;
                    boxMatrixSurvival[x2][y2].transform.position = boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().CalculatationPosition(x2, y2);
                    DataManager.ins.colorMatrixSurvival[x2][y2] = boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().type;

                    boxMatrixSurvival[x1][y1].transform.position = boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().CalculatationPosition(x1, y1);
                    DataManager.ins.colorMatrixSurvival[x1][y1] = boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().type;
                }
                if (y1 > 0 && boxMatrixSurvival[x2][y2] != null && y2 == y1 - 1 && x1 == x2 && boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().type != boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().type)
                {
                    boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().y--;
                    boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().MoveDown1();
                    boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().y++;
                    boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().MoveUp();
                    boxMatrixSurvival[x1][y1] = boxMatrixSurvival[x2][y2];
                    y1 = y2;
                    y2 = y1 + 1;
                    temp = color1;
                    color1 = color2;
                    color2 = temp;
                    boxMatrixSurvival[x1][y1].transform.position = boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().CalculatationPosition(x1, y1);
                    DataManager.ins.colorMatrixSurvival[x1][y1] = boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().type;

                    boxMatrixSurvival[x2][y2].transform.position = boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().CalculatationPosition(x2, y2);
                    DataManager.ins.colorMatrixSurvival[x2][y2] = boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().type;
                }
                if (y1 < 14 && boxMatrixSurvival[x2][y2] != null && y2 == y1 + 1 && x1 == x2 && boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().type != boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().type)
                {
                    boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().y++;
                    boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().MoveUp();
                    boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().y--;
                    boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().MoveDown1();
                    boxMatrixSurvival[x2][y2] = boxMatrixSurvival[x1][y1];
                    y1 = y2;
                    y2 = y1 - 1;
                    temp = color1;
                    color1 = color2;
                    color2 = temp;
                    boxMatrixSurvival[x2][y2].transform.position = boxMatrixSurvival[x2][y2].GetComponent<BoxSurvival>().CalculatationPosition(x2, y2);
                    DataManager.ins.colorMatrixSurvival[x1][y1] = boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().type;

                    boxMatrixSurvival[x1][y1].transform.position = boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().CalculatationPosition(x1, y1);
                    DataManager.ins.colorMatrixSurvival[x1][y1] = boxMatrixSurvival[x1][y1].GetComponent<BoxSurvival>().type;
                }
                CheckWinLoseSurvival();
                SaveBoxSurvival();
            }
            moveBox.Clear();
            clickBox1 = false;
            clickBox2 = false;
            useIt1 = false;
        }
    }

    public void Item2Survival(int x, int y)
    {
        AudioManager.ins.PlaySFX("it2");
        AddScoreSurvival(5);
        GameObject explosion = Instantiate(explosionPrefabs);
        explosion.GetComponent<ParticleSystem>().Play();
        explosion.transform.position = boxMatrixSurvival[x][y].transform.position;
        Destroy(boxMatrixSurvival[x][y]);
        Destroy(explosion, 0.5f);
        boxMatrixSurvival[x][y] = null;
        MoveBoxSurvival();
        CheckWinLoseSurvival();
        SaveBoxSurvival();
        breakBox.Clear();
        useIt2 = false;
    }

    public void Item3Survival(int x, int y)
    {
        AudioManager.ins.PlaySFX("it3");
        GameObject explosion = Instantiate(explosionPrefabs);
        explosion.GetComponent<ParticleSystem>().Play();
        explosion.transform.position = boxMatrixSurvival[x][y].transform.position;
        Destroy(boxMatrixSurvival[x][y]);
        Destroy(explosion, 0.5f);
        boxMatrixSurvival[x][y] = null;
        int color = Random.Range(1, 7);
        GameObject box1 = Instantiate(this.boxSurvival[color - 1]);
        box1.GetComponent<BoxSurvival>().OnSpawn(x, y, (BoxType2)color);
        boxMatrixSurvival[x][y] = box1;
        box1.transform.position = box1.GetComponent<BoxSurvival>().CalculatationPosition(x, y);
        DataManager.ins.colorMatrixSurvival[x][y] = boxMatrixSurvival[x][y].GetComponent<BoxSurvival>().type;
        CheckWinLoseSurvival();
        SaveBoxSurvival();
        useIt3 = false;
    }
}