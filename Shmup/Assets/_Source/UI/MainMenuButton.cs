using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private string _firstLevel = "FirstLevel";
    public Animator transition;
    public AudioData _MusicVol;
    public AudioData _SFXVol;
    public AudioSource audioSource;
    public AudioSource ButtonSound;
    public AudioSource WarningSound;
    public void OnClick()
    { 
        WarningSound.Play();
        ButtonSound.Play();
        StartCoroutine(LoadLevel());
        StartCoroutine(StartFade(audioSource, 2, 0,WarningSound));
    }
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume,AudioSource WarningSound)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        float start2 = WarningSound.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            WarningSound.volume = Mathf.Lerp(start2, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
    IEnumerator LoadLevel()
    {
        _MusicVol.Value = PlayerPrefs.GetFloat(_MusicVol.ToString(), 1);
        _SFXVol.Value = PlayerPrefs.GetFloat(_SFXVol.ToString(), 1);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(_firstLevel);
    }
}
