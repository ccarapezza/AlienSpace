using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCommonData : Singleton<GameCommonData>
{
    private Vector2 minVector;
    public Vector2 MinVector
    {
        get { return minVector; }
    }
    private Vector2 maxVector;
    public Vector2 MaxVector
    {
        get { return maxVector; }
    }

    private void Awake()
    {
        minVector = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxVector = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

}