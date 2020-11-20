using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodScript : MonoBehaviour
{
    public int podId;
    public DreamManager dreamManager;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        if (podId == 7)
        {
           
            gameManager.StartCoroutine(gameManager.InteractWithInterface());
        }
        else
        {
            if (gameManager.stage > 0)
            {
                dreamManager.DisplayDream(podId);
            }
            else
            {
                StartCoroutine(gameManager.DisplayInnerThoughts("I should check out the terminal below that large blue screen."));
            }
        }
    }
}
