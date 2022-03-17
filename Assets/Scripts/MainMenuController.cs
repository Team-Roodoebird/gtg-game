using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip _openingSong;
    //[SerializeField] AudioClip _startingSong;
    [SerializeField] Text _highScoreTextView = null;
    [SerializeField] Slider volumeSlider = null;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        //Load high score display
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();

        //Play starting song on Menu Start
        if (_openingSong != null)
        {
            global::AudioManager.Instance.PlaySong(_openingSong);
        }

        volumeSlider.value = global::AudioManager.Instance._audioSource.volume;
        volumeSlider.maxValue = global::AudioManager.Instance._audioSource.maxDistance;
        volumeSlider.maxValue = global::AudioManager.Instance._audioSource.minDistance;
    }

    public void AdjustVolume()
    {
        global::AudioManager.Instance.AdjustVolume(volumeSlider.value);
        Debug.Log("New volume: " + volumeSlider.value.ToString());
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        Debug.Log("High score reset.");

        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();
    }

    /*public void StartMusic()
    {
        global::AudioManager.Instance.PlaySong(_startingSong);
    }*/

    public void QuitGame()
    {
        Application.Quit();
    }
}
