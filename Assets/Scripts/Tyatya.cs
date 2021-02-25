using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tyatya : MonoBehaviour
{
    public int r = 10, quality =3;
    void Start()
    {
        int i;
        Vector2 x0 = new Vector2(0, r);

        for (i = 1; i <= quality; i++)
        {
            float angle = (360f / (float)quality) * i * Mathf.Deg2Rad;
            Vector2 x1 = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * r;
            Debug.DrawLine(x0, x1, Color.red, 60);
            x0 = x1;
        }
        Debug.DrawLine(x0, new Vector2(0, r), Color.red, 60);

        // + - * / (%)
    }
}
