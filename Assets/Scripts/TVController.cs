using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TVController : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoPlayer;

    public Text volumeText;
    public Text speedText;

    private float volume = 1.0f;
    private float playbackSpeed = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = this.GetComponent<UnityEngine.Video.VideoPlayer>();
        volumeText.text = "Volume: " + (volume * 100);
        speedText.text = "Speed: x" + System.Math.Round(playbackSpeed, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChannelChange()
    {
        if (EventSystem.current.currentSelectedGameObject.GetComponent<ClipButton>().myClip != null)
        {
            videoPlayer.clip = EventSystem.current.currentSelectedGameObject.GetComponent<ClipButton>().myClip;
        }        

    }

    public void OnVolumeUp()
    {
        if (volume < 1) { volume += 0.05f; } else { volume = 1.0f; }

        videoPlayer.SetDirectAudioVolume(0, volume);
        volumeText.text = "Volume: " + Mathf.RoundToInt(volume * 100);
    }

    public void OnVolumeDown()
    {
        if (volume > 0) { volume -= 0.05f; } else { volume = 0.0f; }
        
        videoPlayer.SetDirectAudioVolume(0, volume);
        volumeText.text = "Volume: " + Mathf.RoundToInt(volume * 100);
    }

    public void OnSpeedUp()
    {
        if (playbackSpeed < 3)
        {
            playbackSpeed += 0.5f;
        }
        else if (playbackSpeed < 10)
        {
            playbackSpeed += 1.0f;
        }
        else
        {
            playbackSpeed = 10.0f;
        }
        videoPlayer.playbackSpeed = playbackSpeed;
        speedText.text = "Speed: x" + System.Math.Round(playbackSpeed, 1);
    }

    public void OnSpeedDown()
    {
        if (playbackSpeed > 3)
        {
            playbackSpeed -= 1.0f;
        }else if(playbackSpeed > 0)
        {
            playbackSpeed -= 0.5f;
        }else
        {
            playbackSpeed = 0.0f;
        }
        videoPlayer.playbackSpeed = playbackSpeed;
        speedText.text = "Speed: x" + System.Math.Round(playbackSpeed, 1);

    }

}
