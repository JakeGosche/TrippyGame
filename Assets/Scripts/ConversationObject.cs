using UnityEngine;
using System.Collections;
using UnityEngine.Video;
using UnityEngine.UI;
using static Enums;

public class ConversationObject
{
    public Speaker Speaker { get; set; }
    public int ExpressionId { get; set; }
    public string Message { get; set; }
}
