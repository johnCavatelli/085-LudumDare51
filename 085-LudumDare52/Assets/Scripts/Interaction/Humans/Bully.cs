using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bully : HumanInteraction
{
    void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        TextManager.current.StartDialogue(firstName, talkingSpriteFirst, talkingSpriteSecond);
        TextManager.current.DisplayDialogue("Don't talk to me dweeb, I'm busy being upset becaue my parents beat me!");
    }
}
