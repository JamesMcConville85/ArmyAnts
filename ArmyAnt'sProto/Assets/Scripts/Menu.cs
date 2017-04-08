using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Menu : MonoBehaviour {

    public GameObject optionsHolder;

    public Slider[] volumeSliders;
    public Toggle[] resolutionToggles;
    public int[] screenWidths;
    int activeScreenResIndex;

    public void SetScreenResolution(int i) {
        if (resolutionToggles[i].isOn) {
            activeScreenResIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);
        }
    }

    public void SetFullScreen(bool isFullscreen) {
        for (int i =0; i< resolutionToggles.Length; i++)
        {
            resolutionToggles [i].interactable = !isFullscreen;
        }
        if (isFullscreen) {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions[allResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);

        }
        else
        {
            SetScreenResolution(activeScreenResIndex);
        }
    }

    public void SetMasterVolume(float value) {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }

    public void SetMusicVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }

    public void SetSfxVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Sfx);
    }
}
