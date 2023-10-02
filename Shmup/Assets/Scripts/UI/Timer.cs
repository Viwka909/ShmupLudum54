using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class Timer : MonoBehaviour
{
    public GameObject clock1;
    public GameObject clock2;
    public GameObject clock3;
    public GameObject clock4;
    
    public GameObject LeftSide;
    public GameObject RightSide;
    public float ClosingForce = 25;
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
            clock1.SetActive(true);
        }
        if (timePassed >= timermult * 2)
        {
            clock2.SetActive(true);
        }
        if (timePassed >= timermult * 3)
        {
            clock3.SetActive(true);
        }
        if (timePassed >= timermult * 4)
        {
            clock4.SetActive(true);
        }
        if (timePassed >= timermult * 5)
        {
            clock1.SetActive(false);
            clock2.SetActive(false);
            clock3.SetActive(false);
            clock4.SetActive(false);
            LeftSide.transform.Translate(new Vector2(1f,0f)* ClosingForce * Time.deltaTime);
            RightSide.transform.Translate(new Vector2(-1f,0f)* ClosingForce * Time.deltaTime);
            timePassed = 0;
        }
    }
}
