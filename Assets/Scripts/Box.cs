using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Box : MonoBehaviour
{
    public int x;
    public int y;
    public BoxType type;

    Vector3 firstPos = new Vector3(-4.3f, -4.3f);
    float boxSize = 0.9555f;

    public Vector3 CalculatationPosition(int x, int y)
    {
        return new Vector3(firstPos.x + boxSize * x, firstPos.y + boxSize * y, 0);
    }

    public void OnSpawn(int _x, int _y, BoxType _type)
    {
        x = _x;
        y = _y;
        type = _type;
    }

    public void MoveDown()
    {
        StartCoroutine(MoveCoroutine());

    }
     
    public void MoveLeft()
    {
        StartCoroutine(MoveCoroutine1());
    }

    public IEnumerator MoveCoroutine1()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.position -= new Vector3(boxSize / 10, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator MoveCoroutine()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.position -= new Vector3(0, boxSize / 10, 0);
            yield return new WaitForSeconds (0.01f);
        }
    }


    private void OnMouseDown()
    {      
        if (!GameController.instance.useIt1 && !GameController.instance.useIt2 && !GameController.instance.useIt3 )
        {
            GameController.instance.breakBox.Add(gameObject);
            GameController.instance.FindBreakBoxClassic();
        }
        else if(GameController.instance.useIt1)
        {
            if(GameController.instance.clickBox1)
            {
                GameController.instance.ClickMoveBoxClassic2(x, y);
            }
            else
            {
                GameController.instance.ClickMoveBoxClassic1(x, y);
            }
            
            GameController.instance.Item1Classic();    
        }
        else if (GameController.instance.useIt2)
        {
            GameController.instance.breakBox.Add(gameObject);
            GameController.instance.Item2Classic(x, y);
        }
        else
        {
            GameController.instance.Item3Classic(x, y);
        }
    }
}

public enum BoxType
{
    None = 0,
    Purple,
    Green,
    Orange,
    Red,
    Yellow,
}
