using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostWiseEvent : MonoBehaviour
{
    public AK.Wwise.Event akEvent;

    public void ActivateSound()
    {
        akEvent.Post(gameObject);
    }
}
