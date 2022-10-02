using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eashra : HumanInteraction
{
    void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        TextManager.current.StartDialogue(firstName, talkingSpriteFirst, talkingSpriteSecond);
        if (!FlagManager.current.GetFlag(flags.hasBadge))
        {
            TextManager.current.MakeChoice("Do you wanna join our secret guild? $5 is all");
            TextManager.current.getYesChoiceButton().onClick.AddListener(delegate { BuySpellBook(); });
            TextManager.current.getNoChoiceButton().onClick.AddListener(delegate { DontBuySpellBook(); });
        }
        else
        {
            TextManager.current.DisplayDialogue("I hear our leader is looking for an apple to give to Yahweh");
        }
    }

    public void BuySpellBook()
    {
        FlagManager.current.TakeMoney(5);
        FlagManager.current.SetFlag(flags.hasBadge, true);
        TextManager.current.EndChoice("Welcome my brother in Christ, you will not regret this");
    }

    public void DontBuySpellBook()
    {
        TextManager.current.EndChoice("You'll burn in hell for your decision today!");
    }
}
