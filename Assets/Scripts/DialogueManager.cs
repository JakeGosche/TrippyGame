using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    
    public GameObject textBubble;
    public DreamManager dreamManager;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(test());
        //Debug.Log("The block is text contains " + textMesh.textInfo.lineCount + " lines of text.");
        //textMesh.text = "A longer line of text which will be truncated.";

        //// Unless I force an update of the text object, querying the textInfo.lineCount will be incorrect since the text object hasn't been updated yet to reflect the changes I just made.
        //textMesh.ForceMeshUpdate();

        //image.rectTransform.sizeDelta = new Vector2(image.rectTransform.sizeDelta.x, (1 + ((textMesh.textInfo.lineCount - 1) * .9f) * image.rectTransform.sizeDelta.y));
        //Debug.Log("The block is text contains " + textMesh.textInfo.lineCount + " lines of text.");
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    
    public IEnumerator test()
    {
        yield return new WaitForSeconds(2);
        NewTextBubble("Lorem Ipsum");
        yield return new WaitForSeconds(2);
        NewTextBubble("Here's a code");
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
        dreamManager.dreamPanel.SetActive(true);
        dreamManager.ShowScreen(0);
    }

    public void NewTextBubble(string newText)
    {
        TextBubbleScript[] rectTransforms = GetComponentsInChildren<TextBubbleScript>();
        GameObject newBubble = Instantiate(textBubble);//Instantiate(textBubble, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        newBubble.transform.parent = gameObject.transform;
       
        TMP_Text textMesh = newBubble.GetComponentInChildren<TMP_Text>();

        Image image = newBubble.GetComponent<Image>();
        Debug.Log("The block is text contains " + textMesh.textInfo.lineCount + " lines of text.");
        textMesh.text = newText;

        // Unless I force an update of the text object, querying the textInfo.lineCount will be incorrect since the text object hasn't been updated yet to reflect the changes I just made.
        textMesh.ForceMeshUpdate();
        float newSize = ((1 + ((textMesh.textInfo.lineCount - 1) * .9f)) * image.rectTransform.sizeDelta.y);
        image.rectTransform.sizeDelta = new Vector2(image.rectTransform.sizeDelta.x, newSize);
        Debug.Log("The block is text contains " + textMesh.textInfo.lineCount + " lines of text.");
        newBubble.GetComponent<RectTransform>().position = new Vector3(this.transform.position.x, .5f * newSize + 10, transform.position.z);
        //TextBubbleScript[] tbsArray = FindObjectsOfType
        foreach (TextBubbleScript tbs in rectTransforms)
        {
            RectTransform rectTransform = tbs.GetComponent<RectTransform>();
            rectTransform.position = new Vector2(rectTransform.position.x, (rectTransform.position.y + newSize + 10));
            //if (rectTransform.position.y > 100)
            //{
            //    Destroy(tbs.gameObject);
            //}
        }

    }
}
