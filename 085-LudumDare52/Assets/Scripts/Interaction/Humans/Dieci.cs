using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dieci : HumanInteraction
{
    bool has = false;
    void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        TextManager.current.StartDialogue(firstName, talkingSpriteFirst, talkingSpriteSecond);
        if (FlagManager.current.GetFlag(flags.hasApple))
        {
            TextManager.current.MakeChoice("Can I buy your apple for $5?");
            TextManager.current.getYesChoiceButton().onClick.AddListener(delegate { BuySpellBook(); });
            TextManager.current.getNoChoiceButton().onClick.AddListener(delegate { DontBuySpellBook(); });
        }
        else
        {
            if (has)
            {
                TextManager.current.DisplayDialogue("Thanks for the apple. I'm going to kill the principal tommorow");
            }
            else
            {
                TextManager.current.DisplayDialogue("I'm going to poison the principal, if you find an apple, let me know");
            }
            
        }
    }

    public void BuySpellBook()
    {
        FlagManager.current.GainMoney(5);
        FlagManager.current.SetFlag(flags.hasApple, false);
        has = true;
        TextManager.current.EndChoice("Thanks, I won't mention your name in prison");
    }

    public void DontBuySpellBook()
    {
        TextManager.current.EndChoice("What's your deal? You won't even be an accomplice to murder?");
    }
}
