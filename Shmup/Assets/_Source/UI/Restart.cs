using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private string _firstLevel = "FirstLevel";
    public void OnClick()
    {
        SceneManager.LoadScene(_firstLevel);
    }
}
