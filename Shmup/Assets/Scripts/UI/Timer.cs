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
    public GameObject[] Covers;
    public GameObject CoverFather;
    public Transform[] children;
    int count = 0;
    public int timermult = 5;

    float timePassed = 0;
    void Start()
    {
        children = GetComponentsInChildren<Transform>(true).Where(child => child != transform).ToArray();

    }
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= timermult)
        {
            clock1.color = Color.yellow;
        }
        if (timePassed >= timermult * 2)
        {
            clock2.color = Color.yellow;
        }
        if (timePassed >= timermult * 3)
        {
            clock3.color = Color.yellow;
        }
        if (timePassed >= timermult * 4)
        {
            clock4.color = Color.yellow;
        }
        if (timePassed >= timermult * 5)
        {
            timePassed = 0;
            children[count].gameObject.SetActive(true);
            count++;
            clock1.color = Color.black;
            clock2.color = Color.black;
            clock3.color = Color.black;
            clock4.color = Color.black;
        }
    }
}
