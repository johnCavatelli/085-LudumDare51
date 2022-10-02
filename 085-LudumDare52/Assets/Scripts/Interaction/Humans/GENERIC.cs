using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GENERIC : HumanInteraction
{
    public string text;
    void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        TextManager.current.StartDialogue(firstName, talkingSpriteFirst, talkingSpriteSecond);
        TextManager.current.DisplayDialogue(text);
    }
}
