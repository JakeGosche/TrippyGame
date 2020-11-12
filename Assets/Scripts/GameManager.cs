using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuBackground, mainMenu, optionsMenu,  quitMenu;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
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
