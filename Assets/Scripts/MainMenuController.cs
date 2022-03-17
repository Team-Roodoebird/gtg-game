using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip _openingSong;
    [SerializeField] AudioClip _startingSong;
    [SerializeField] Slider volumeSlider = null;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;

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

    public void StartMusic()
    {
        global::AudioManager.Instance.PlaySong(_startingSong);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
