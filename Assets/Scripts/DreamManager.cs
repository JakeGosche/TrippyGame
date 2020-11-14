using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DreamManager : MonoBehaviour
{
    public Text dreamerName, dreamerOccupation, dreamerRank;
    public Image dreamerPicture;
    public Sprite[] dreamerPortraits;
    public PlayerController player;
    public VideoPlayer videoPlayer;
    public DialogueManager dialogueManager;
    public List<Dream> dreamButtons;
    public GameManager gameManager;
    public GameObject background, mainMenu, videoObject, convoObject, errorObject, dreamPanel;
    public bool active, videoPlaying;
    public int activeDreamId = 0;
    public int playingVideoId = -1;
    public int currentPodId = 0;
    public VideoClip one1, one2, three1, three2;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            //{
            //    int previousId = activeDreamId;
            //    int newId = activeDreamId;
            //    bool foundNew = false;

            //    if (Input.GetKeyDown(KeyCode.S))
            //    {
            //        while (foundNew == false)
            //        {
            //            if (newId == 0)
            //            {
            //                newId = dreamButtons.Count - 1;
            //            }
            //            else
            //            {
            //                newId--;
            //            }
            //            if (dreamButtons[newId].unlocked || newId == previousId)
            //            {
            //                activeDreamId = newId;
            //                foundNew = true;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        while (foundNew == false)
            //        {
            //            if (newId == dreamButtons.Count - 1)
            //            {
            //                newId = 0;
            //            }
            //            else
            //            {
            //                newId++;
            //            }

            //            if (dreamButtons[newId].unlocked || newId == previousId)
            //            {
            //                activeDreamId = newId;
            //                foundNew = true;
            //            }
            //        }
            //    }


            //    dreamButtons[previousId].GetComponent<Image>().color = Color.white;
            //    dreamButtons[activeDreamId].GetComponent<Image>().color = Color.green;
            //}
            //if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     if(activeDreamId != playingVideoId || !videoPlaying)
            //     {
            //         videoPlayer.enabled = true;
            //         playingVideoId = activeDreamId;
            //         videoPlayer.clip = dreamButtons[activeDreamId].video;
            //         videoPlaying = true;
            //         videoPlayer.Play();
            //     }
            // }
            // else 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ExitDreamPlayer();
            }
        }
    }

    public void DisplayDream(int podId)
    {
        videoObject.SetActive(false);
        errorObject.SetActive(false);
        player.canMove = false;
        videoPlayer.clip = null;
        //Play screen opening animation?
        string podName = "";
        string podOccupation = "";
        string podRank = "";
        activeDreamId = 0;
        playingVideoId = -1;
        switch (podId)
        {
            case 1:
                podName = "Shapley, Hal";
                podOccupation = "Neural Technicial";
                podRank = "Class B";
                break;
            case 2:
                podName = "Chong, Leon";
                podOccupation = "Chemist";
                podRank = "Class D";
                break;
            case 3:
                podName = "";
                podOccupation = "";
                podRank = "";
                break;
            case 4:
                podName = "Mitropoulos, Samantha";
                podOccupation = "Director of terraforming";
                podRank = "Class A";
                break;
            case 5:
                podName = "Lund, Britta";
                podOccupation = "Botanist";
                podRank = "Class D";
                break;
            case 6:
                podName = "Cassidy, Marlowe";
                podOccupation = "Reclamation Engineer";
                podRank = "Class C";
                break;
        }
        dreamerName.text = podName;
        dreamerOccupation.text = podOccupation;
        dreamerRank.text = podRank;
        dreamerPicture.sprite = dreamerPortraits[podId - 1];
        currentPodId = podId;
        //for (int i = 0; i < dreamButtons.Count; i++)
        //{
            
        //    dreamButtons[i].GetComponent<Image>().color = i == 0 ? Color.green : Color.white;
        //}
        videoPlayer.enabled = false;
        this.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
        ShowScreen(0);
        active = true;
    }

    public void LoadVideos()
    {
        
        if (gameManager.unlockedDreams[currentPodId] == true)
        {
            mainMenu.gameObject.SetActive(false);
            switch (currentPodId)
            {
                case 1:

                    dreamButtons[0].dreamName.text = "Dream_1";
                    dreamButtons[0].video = one1;
                    dreamButtons[1].dreamName.text = "Dream_2";
                    dreamButtons[1].video = one2;
                    break;
                case 4:
                    dreamButtons[0].dreamName.text = "Dream_1";
                    dreamButtons[0].video = three1;
                    dreamButtons[1].dreamName.text = "Dream_2";
                    dreamButtons[1].video = three2;
                    break;
            }
            ShowScreen(1);
        }
        else
        {
            ShowScreen(3);
        }
    }

    public void GetConvo()
    {
       
        if (gameManager.unlockedConvos[currentPodId] == true)
        {
            mainMenu.gameObject.SetActive(false);
            dreamPanel.gameObject.SetActive(false);
            ShowScreen(2);
            switch (currentPodId)
            {
                case 1:

                    dreamButtons[0].dreamName.text = "Dream_1";
                    dreamButtons[0].video = one1;
                    dreamButtons[1].dreamName.text = "Dream_2";
                    dreamButtons[1].video = one2;
                    break;
                case 4:

                    StartCoroutine(dialogueManager.test());
                    break;
            }
        }
        else
        {
            ShowScreen(3);
        }
    }

    public void ShowScreen(int screenId)
    {
   
                mainMenu.SetActive(screenId == 0);
              
                videoObject.SetActive(screenId == 1);
              
                convoObject.SetActive(screenId == 2);
       
            
                errorObject.SetActive(screenId == 3);
         
    }

    public void ExitDreamPlayer()
    {
        active = false;
        background.SetActive(false);
        this.gameObject.SetActive(false);
        dialogueManager.gameObject.SetActive(false);
        player.canMove = true;
    }

    public void PlayVideo(int videoId)
    {
        videoPlayer.enabled = true;
        playingVideoId = videoId;
        videoPlayer.clip = dreamButtons[videoId].video;
        videoPlaying = true;
        videoPlayer.Play();
    }
}
