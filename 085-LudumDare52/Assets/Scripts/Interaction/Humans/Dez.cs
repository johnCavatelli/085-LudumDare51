using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dez : HumanInteraction
{
    bool has = false;
    void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        TextManager.current.StartDialogue(firstName, talkingSpriteFirst, talkingSpriteSecond);
        if (FlagManager.current.GetFlag(flags.hasBall))
        {
            TextManager.current.MakeChoice("YOU FOUND MY BALL! I'll give you $10 for it");
            TextManager.current.getYesChoiceButton().onClick.AddListener(delegate { BuySpellBook(); });
            TextManager.current.getNoChoiceButton().onClick.AddListener(delegate { DontBuySpellBook(); });
        }
        else
        {
            if (has)
            {
                TextManager.current.DisplayDialogue("Thanks for my ball Ten");
            }
            else
            {
                TextManager.current.DisplayDialogue("I've been looking forward for my Basketball forever now! Please help me find it...");
            }
        }
    }

    public void BuySpellBook()
    {
        FlagManager.current.GainMoney(10);
        FlagManager.current.SetFlag(flags.hasBall, false);
        has = true;
        TextManager.current.EndChoice("You're a real one, I don't know when I would've found that");
    }

    public void DontBuySpellBook()
    {
        TextManager.current.EndChoice("I'll swat your house you piece of poop! Give me the ball!");
    }
}
