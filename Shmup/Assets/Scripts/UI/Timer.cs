using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class Timer : MonoBehaviour
{
    public SpriteRenderer clock1;
    public SpriteRenderer clock2;
    public SpriteRenderer clock3;
    public SpriteRenderer clock4;
    public GameObject LeftSide;
    public GameObject RightSide;
    int count = 0;
    public int timermult = 5;

    float timePassed = 0;
    void Start()
    {
       
    }
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= timermult)
        {
            
        }
        if (timePassed >= timermult * 2)
        {
            
        }
        if (timePassed >= timermult * 3)
        {
            
        }
        if (timePassed >= timermult * 4)
        {
            
        }
        if (timePassed >= timermult * 5)
        {
            
        }
    }
}
