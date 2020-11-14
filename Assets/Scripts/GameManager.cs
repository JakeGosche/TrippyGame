using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuBackground, mainMenu, optionsMenu,  quitMenu;
    public PlayerController player;
    public bool puzzle1Status = false;
    public Dictionary<int, bool> unlockedDreams;
    public Dictionary<int, bool> unlockedConvos;
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
        menuBackground.SetActive(false);
        mainMenu.SetActive(false);
        player.canMove = true;
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
