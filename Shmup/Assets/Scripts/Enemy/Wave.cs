using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wave : MonoBehaviour
{
     [SerializeField] private string _Level = "SecondLevel";
    public static Wave instance;
    public GameObject Wave2;
    public GameObject Boss;
    public int fistwavecount;
    public int secondwavecount;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public AudioSource bgm1;
    public GameObject bgm2;
    public SpriteRenderer Player;
    public Sprite BossBgmName;



    int killcount = 0;
    bool wave2check = false;

    void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }
    void Update()
    {
        if (killcount == secondwavecount && wave2check == true){
            point2.SetActive(false);
            point3.SetActive(true);
            CallBoss();
        }
        if (killcount >= fistwavecount && wave2check == false)
        {
            Debug.Log("wave2called");
            CallWave2();
            killcount = 0;
            wave2check = true;
            point1.SetActive(false);
            point2.SetActive(true);
        }
        
    }
    public void CallWave2()
    {
            Wave2.SetActive(true);
    }
    public void EnemyKilled(){
        Debug.Log("check");
        Debug.Log(wave2check);
        killcount++;
    }
    public void BossKilled(){
         SceneManager.LoadScene(_Level);
    }

    public void CallBoss()
    {
        bgm1.Pause();
        bgm2.SetActive(true);
        Player.sprite = BossBgmName;
        Boss.SetActive(true);
    }
}
