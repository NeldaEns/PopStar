using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClassic : MonoBehaviour
{ 
    public int x;
    public int y;
    public BoxType1 type;

    Vector3 firstPos = new Vector3(-4.45f, -4.45f);
    float boxSize = 0.986f;

    public Vector3 CalculatationPosition(int x, int y)
    {
        return new Vector3(firstPos.x + boxSize * x, firstPos.y + boxSize * y, 0);
    }

    public void OnSpawn(int _x, int _y, BoxType1 _type)
    {
        x = _x;
        y = _y;
        type = _type;
    }

    public void MoveDown()
    {
        StartCoroutine(MoveCoroutine());

    }

    public IEnumerator MoveCoroutine()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.position -= new Vector3(0, boxSize / 10, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void MoveLeft1()
    {
        StartCoroutine(MoveCoroutine2());
    }

    public IEnumerator MoveCoroutine2()
    {

        transform.position -= new Vector3(boxSize, 0, 0);
        yield return new WaitForSeconds(1f);

    }

    public void MoveRight()
    {
        StartCoroutine(MoveCoroutine3());
    }

    public IEnumerator MoveCoroutine3()
    {

        transform.position += new Vector3(boxSize, 0, 0);
        yield return new WaitForSeconds(1f);

    }

    public void MoveDown1()
    {
        StartCoroutine(MoveCoroutine4());
    }

    public IEnumerator MoveCoroutine4()
    {

        transform.position -= new Vector3(0, boxSize, 0);
        yield return new WaitForSeconds(1f);

    }

    public void MoveUp()
    {
        StartCoroutine(MoveCoroutine5());
    }

    public IEnumerator MoveCoroutine5()
    {

        transform.position += new Vector3(0, boxSize, 0);
        yield return new WaitForSeconds(1f);

    }

    private void OnMouseDown()
    {

        if (!GameController.instance.useIt1 && !GameController.instance.useIt2 && !GameController.instance.useIt3)
        {
            GameController.instance.breakBox.Add(gameObject);
            GameController.instance.FindBreakBoxClassic();
        }
        else if (GameController.instance.useIt1)
        {
            if (GameController.instance.clickBox1)
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

public enum BoxType1
{
    None = 0,
    Blue,
    Orange,
    Red,
    Yellow,
    Green,
}


