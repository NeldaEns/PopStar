using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int x;
    public int y;
    public Bom bomb;

    Vector3 firstPos = new Vector3(-3.015f, -3.015f);
    float boxSize = 0.67f;

    public Vector3 CalculatationPosition(int x, int y)
    {
        return new Vector3(firstPos.x + boxSize * x, firstPos.y + boxSize * y, 0);
    }
    public void OnSpawn(int _x, int _y, Bom _bomb)
    {
        x = _x;
        y = _y;
        bomb = _bomb;
    }
}

public enum Bom
{
    None = 0,
    bomb,
}
