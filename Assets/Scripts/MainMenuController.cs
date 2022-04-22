//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class MainMenuController : MonoBehaviour
//{
//    [SerializeField] AudioClip _openingSong;
//    //[SerializeField] AudioClip _startingSong;
//    [SerializeField] Text _highScoreTextView = null;
//    [SerializeField] Slider volumeSlider = null;

//    private void Start()
//    {
//        Cursor.lockState = CursorLockMode.None;

//        //Load high score display
//        int highScore = PlayerPrefs.GetInt("HighScore");
//        _highScoreTextView.text = highScore.ToString();

//        //Play starting song on Menu Start
//        if (_openingSong != null)
//        {
//            global::Audio.Instance.PlaySong(_openingSong);
//        }

//        volumeSlider.value = global::Audio.Instance._audioSource.volume;
//        volumeSlider.maxValue = global::Audio.Instance._audioSource.maxDistance;
//        volumeSlider.maxValue = global::Audio.Instance._audioSource.minDistance;
//    }

//    public void AdjustVolume()
//    {
//        global::Audio.Instance.AdjustVolume(volumeSlider.value);
//        Debug.Log("New volume: " + volumeSlider.value.ToString());
//    }

//    public void ResetHighScore()
//    {
//        PlayerPrefs.SetInt("HighScore", 0);
//        Debug.Log("High score reset.");

//        int highScore = PlayerPrefs.GetInt("HighScore");
//        _highScoreTextView.text = highScore.ToString();
//    }

//    /*public void StartMusic()
//    {
//        global::Audio.Instance.PlaySong(_startingSong);
//    }*/

//    public void QuitGame()
//    {
//        Application.Quit();
//    }
//}
