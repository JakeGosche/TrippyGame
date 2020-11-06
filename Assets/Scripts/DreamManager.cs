using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DreamManager : MonoBehaviour
{
    public Text dreamerName, dreamerOccupation;
    public PlayerController player;
    public VideoPlayer videoPlayer;
    public List<Dream> dreamButtons;
    public bool active, videoPlaying;
    public int activeDreamId = 0;
    public int playingVideoId = -1;
    public VideoClip one1, one2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                int previousId = activeDreamId;
                int newId = activeDreamId;
                bool foundNew = false;

                if (Input.GetKeyDown(KeyCode.S))
                {
                    while (foundNew == false)
                    {
                        if (newId == 0)
                        {
                            newId = dreamButtons.Count - 1;
                        }
                        else
                        {
                            newId--;
                        }
                        if (dreamButtons[newId].unlocked || newId == previousId)
                        {
                            activeDreamId = newId;
                            foundNew = true;
                        }
                    }
                }
                else
                {
                    while (foundNew == false)
                    {
                        if (newId == dreamButtons.Count - 1)
                        {
                            newId = 0;
                        }
                        else
                        {
                            newId++;
                        }

                        if (dreamButtons[newId].unlocked || newId == previousId)
                        {
                            activeDreamId = newId;
                            foundNew = true;
                        }
                    }
                }

                
                dreamButtons[previousId].GetComponent<Image>().color = Color.white;
                dreamButtons[activeDreamId].GetComponent<Image>().color = Color.green;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if(activeDreamId != playingVideoId || !videoPlaying)
                {
                    videoPlayer.enabled = true;
                    playingVideoId = activeDreamId;
                    videoPlayer.clip = dreamButtons[activeDreamId].video;
                    videoPlaying = true;
                    videoPlayer.Play();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                player.canMove = true;
                active = false;
                this.gameObject.SetActive(false);
            }
        }
    }

    public void DisplayDream(int podId)
    {
        player.canMove = false;
        videoPlayer.clip = null;
        //Play screen opening animation?
        string podName = "";
        string podOccupation = "";
        activeDreamId = 0;
        playingVideoId = -1;
        switch (podId)
        {
            case 0:
                podName = "John Doe";
                podOccupation = "Scientist";
                dreamButtons[0].dreamName.text = "Dream_1";
                dreamButtons[0].video = one1;
                dreamButtons[1].dreamName.text = "Dream_2";
                dreamButtons[1].video = one2;
                break;
        }
        dreamerName.text = "Name: " + podName;
        dreamerOccupation.text = "Occupation: " + podOccupation;
        for (int i = 0; i < dreamButtons.Count; i++)
        {
            
            dreamButtons[i].GetComponent<Image>().color = i == 0 ? Color.green : Color.white;
        }
        videoPlayer.enabled = false;
        this.gameObject.SetActive(true);
        active = true;
    }
}
