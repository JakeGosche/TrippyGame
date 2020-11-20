using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuBackground, mainMenu, optionsMenu,  quitMenu, screen, console, dialogueOption;
    public PlayerController player;
    public DialogueRepository dialogueManager;
    public bool puzzle1Status = false;
    public Dictionary<int, bool> unlockedDreams;
    public Dictionary<int, bool> unlockedConvos;
    public TMP_Text computerScreen;
    public Text reviveScreen, innerThoughts, dialogueOptionText;
    public RotateScript rotateScript;
    public Image image, lines1, lines2;
    public int liquidUnlockedPodId;
    public int stage = 0;
    public bool awaitingInput = false;

    // Start is called before the first frame update
    void Start()
    {
        unlockedDreams = new Dictionary<int, bool>() { { 1, false }, { 2, false }, { 3, false }, { 4, true }, { 5, false }, { 6, false } };
        unlockedConvos = new Dictionary<int, bool>() { { 1, false }, { 2, false }, { 3, false }, { 4, false }, { 5, false }, { 6, false } };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        stage = 0;
        StartCoroutine(StartGameRoutine());
    }

    public IEnumerator StartGameRoutine()
    {
        image.gameObject.SetActive(true);
    
        yield return StartCoroutine(FadeBlack());
        menuBackground.SetActive(false);
        mainMenu.SetActive(false);

        yield return new WaitForSeconds(1);
        reviveScreen.text = "Revive successful...";
        yield return new WaitForSeconds(1);
        reviveScreen.text = reviveScreen.text + Environment.NewLine + Environment.NewLine + "Ngo, Rosalyn";
        yield return new WaitForSeconds(1);
        reviveScreen.text = reviveScreen.text + Environment.NewLine + "Neuro - Network Technician";
        yield return new WaitForSeconds(1);
        reviveScreen.text = reviveScreen.text + Environment.NewLine + "Class C";
        yield return new WaitForSeconds(1);
        reviveScreen.text = reviveScreen.text + Environment.NewLine + Environment.NewLine + "Cryopod disengagement sequence engaged...";
        yield return new WaitForSeconds(1);
        reviveScreen.text = reviveScreen.text + Environment.NewLine + Environment.NewLine + "Please proceed to a neuro - terminal upon exiting...";
        yield return new WaitForSeconds(2);
        reviveScreen.text = "";
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(UnFadeBlack());
        image.gameObject.SetActive(false);
        StartCoroutine(StartWalking());
        yield return new WaitForSeconds(0.5f);
        while (player.transform.eulerAngles.y < 320)
        {
            player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, Math.Min(320, player.transform.eulerAngles.y + (50 * Time.deltaTime)), player.transform.eulerAngles.z);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);

        while (player.transform.eulerAngles.y > 220)
        {
            player.transform.eulerAngles = new Vector3(Math.Max(-20, player.transform.eulerAngles.z - (50 * Time.deltaTime)), player.transform.eulerAngles.y, player.transform.eulerAngles.z);
            player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, Math.Max(220, player.transform.eulerAngles.y - (50 * Time.deltaTime)), player.transform.eulerAngles.z);
            yield return null;
        }


        yield return new WaitForSeconds(1);
        computerScreen.text = "Ngo, Rosalyn";
        yield return new WaitForSeconds(1);
        computerScreen.text = computerScreen.text + Environment.NewLine + "Please proceed to neuro-terminal for further instruction...";
        yield return new WaitForSeconds(1);
        while (player.transform.eulerAngles.y < 270)
        {
            player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, Math.Min(270, player.transform.eulerAngles.y + (50 * Time.deltaTime)), player.transform.eulerAngles.z);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        player.canMove = true;
    }

    public void ReceiveInput()
    {
        awaitingInput =false;
    }

    public IEnumerator StartWalking()
    {
        while (player.transform.position.x > 8)
        {
            player.transform.position = new Vector3(Math.Max(5, player.transform.position.x - (5 * Time.deltaTime)), player.transform.position.y, player.transform.position.z);
            yield return null;
        }
    }

    public IEnumerator DisplayInnerThoughts(string display)
    {
        innerThoughts.text = display;
        innerThoughts.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        innerThoughts.text = "";
        innerThoughts.gameObject.SetActive(false);
    }

    public IEnumerator InteractWithInterface()
    {
        player.canMove = false;
        stage = 1;
        image.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        player.transform.position = new Vector3(-21.05f, 1, -39.23f);
        player.transform.eulerAngles = new Vector3(0, 210, 0);
        yield return new WaitForSeconds(1);
        while (player.transform.eulerAngles.x < 20)
        {
            player.transform.eulerAngles = new Vector3(Math.Min(20, player.transform.eulerAngles.x + (50 * Time.deltaTime)), player.transform.eulerAngles.y, player.transform.eulerAngles.z);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(FadeBlack());

        while (player.playerCamera.fieldOfView > 30)
        { 
            player.playerCamera.fieldOfView = Math.Max(30, player.playerCamera.fieldOfView - (50 * Time.deltaTime));
            yield return null;
        }

        yield return new WaitForSeconds(2);
        reviveScreen.text = "Neuro-connection engaged...";
        yield return new WaitForSeconds(1);
        reviveScreen.text = reviveScreen.text + Environment.NewLine + "Connection successful...";
        yield return new WaitForSeconds(1);
        reviveScreen.text = reviveScreen.text + Environment.NewLine + "Ngo, R credentials confirmed...";
        yield return new WaitForSeconds(1);
        reviveScreen.text = "";
        yield return new WaitForSeconds(2);

        player.playerCamera.fieldOfView = 60;
        menuBackground.SetActive(true);
        image.color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.5f);
        float timeLeft = 5;
        while(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            rotateScript.rotateSpeed += Time.deltaTime;
            lines1.color = new Color(lines1.color.r, lines1.color.g - (Time.deltaTime * .1f), lines1.color.b - (Time.deltaTime * .1f));
            lines2.color = new Color(lines1.color.r, lines1.color.g - (Time.deltaTime * .1f), lines1.color.b - (Time.deltaTime * .1f));
            yield return null;
        }

        image.color = new Color(0, 0, 0, 1);
        computerScreen.text = "";
        yield return new WaitForSeconds(1);
        rotateScript.rotateSpeed = .03f;
        lines1.color = Color.white;
        lines2.color = Color.white;
        menuBackground.SetActive(false);
        player.transform.position = new Vector3(-15.4f, player.transform.position.y, -29f);
        player.transform.LookAt(screen.transform);
        player.playerCamera.transform.LookAt(screen.transform);
        yield return StartCoroutine(UnFadeBlack());
        yield return new WaitForSeconds(1);
        //while (player.playerCamera.transform.eulerAngles.x > -20)
        //{
        //    player.playerCamera.transform.eulerAngles = new Vector3(Math.Max(-20, player.playerCamera.transform.eulerAngles.x - (50 * Time.deltaTime)), player.playerCamera.transform.eulerAngles.y, player.playerCamera.transform.eulerAngles.z);
        //    yield return null;
        //}

        while (player.transform.position.y < screen.transform.position.y)
        {
            player.transform.position = new Vector3(player.transform.position.x, Math.Min(screen.transform.position.y, player.transform.position.y + (15 * Time.deltaTime)), player.transform.position.z);
            player.transform.LookAt(screen.transform);
            player.playerCamera.transform.LookAt(screen.transform);
            yield return null;
        }

        List<ConversationObject> convo = dialogueManager.GetDialogue(Enums.Speaker.Eyre, 0);
        yield return new WaitForSeconds(2);
        Enums.Speaker lastSpeaker = Enums.Speaker.Eyre;
        foreach(ConversationObject co in convo)
        {
            if (co.Speaker == Enums.Speaker.Rosalyn)
            {
                awaitingInput = true;
                dialogueOptionText.text = co.Message;
                dialogueOption.gameObject.SetActive(true);
                while (awaitingInput)
                {
                    yield return null;
                }
                dialogueOptionText.text = "";
                computerScreen.text = "";
                dialogueOption.gameObject.SetActive(false);
            }
            else
            {
                if (co.Speaker != lastSpeaker)
                {
                    
                    yield return new WaitForSeconds(2);
                    lastSpeaker = co.Speaker;
                    //computerScreen.color = co.Speaker == Enums.Speaker.Eyre ? Color.white : Color.yellow;
                }


                computerScreen.text = computerScreen.text + co.Message + Environment.NewLine;
            }
                yield return new WaitForSeconds(2);
        }
        computerScreen.text = "";
        while (player.transform.position.y > 1)
        {
            player.transform.position = new Vector3(player.transform.position.x, Math.Max(1, player.transform.position.y - (15 * Time.deltaTime)), player.transform.position.z);
            
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        player.canMove = true;
    }

        public IEnumerator FadeBlack()
    {
        while(image.color.a < 1)
        {
            image.color = new Color(0,0,0, image.color.a +  Time.deltaTime);
            yield return null;
        }
        yield break;
    }

    public IEnumerator UnFadeBlack()
    {
        while (image.color.a > 0)
        {
            Debug.Log(image.color.a);
            image.color = new Color(0, 0, 0, image.color.a - Time.deltaTime);
            yield return null;
        }
        yield break;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DisplayMenu(int menuId)
    {
        menuBackground.SetActive(true);
        mainMenu.SetActive(menuId == 0);
        optionsMenu.SetActive(menuId == 1);
        quitMenu.SetActive(menuId == 2);
    }
}
