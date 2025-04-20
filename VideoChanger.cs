using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoChanger : MonoBehaviour
{
    public GameObject PracticeSelectionPanel;
    public string isMode = "home";
    public string isLevel = "classroom";
    public GameObject GameSelectionPanel;
    public GameObject EnvironmentSphere;
    public GameObject WristMenu;
    public timer Timer;

    [SerializeField] private List<VideoClip> videos = new();
    private VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        // Make sure this click is only responding to the EnvironmentSphere
        if (EnvironmentSphere.activeSelf)
        {
            ExitVideo();
        }
    }
    //Change to a new 360 video
    public void changeVideo(int index)
    {
        //return if the index is out of range
        if (index < 0 || index >= videos.Count)
            return;

        //Replace current video with new video
        videoPlayer.clip = videos[index];
        videoPlayer.Play();
        EnvironmentSphere.SetActive(true);

        if (isMode == "practice")
        {
            PracticeSelectionPanel.SetActive(false);
        }
        else if (isMode == "game")
        {
            WristMenu.SetActive(true);
            GameSelectionPanel.SetActive(false);
        }
       
        
    }
    

    public void ExitVideo()
    {
        videoPlayer.Stop();  // Stop the 360 video
        changeVideo(4);

        Timer.StopTimer();
        Timer.ResetTimer();

        if (isMode == "practice")
        {
            PracticeSelectionPanel.SetActive(true);
        }
        else if (isMode == "game")
        {
            GameSelectionPanel.SetActive(true);
            WristMenu.SetActive(false);
        }
        EnvironmentSphere.SetActive(false);
    }

    public void ChangeScene(string value)
    {
        isMode = value;
    }
    public void ChangeLevel(string value)
    {
        Timer.gameObject.SetActive(true);
        if (isLevel == "classroom")
        {
            
            Timer.startingTime = 600;


        }
        else
        {
           
            Timer.startingTime = 300;
        }
        isLevel = value;
    }
}
