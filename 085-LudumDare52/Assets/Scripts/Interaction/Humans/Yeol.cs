using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeol : HumanInteraction
{
    void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        TextManager.current.StartDialogue(firstName, talkingSpriteFirst, talkingSpriteSecond);
        if (FlagManager.current.GetFlag(flags.hasCards))
        {
            TextManager.current.MakeChoice("Can I buy your Pokemon Cards for $10?");
            TextManager.current.getYesChoiceButton().onClick.AddListener(delegate { BuySpellBook(); });
            TextManager.current.getNoChoiceButton().onClick.AddListener(delegate { DontBuySpellBook(); });
        }
        else
        {
            TextManager.current.DisplayDialogue("If you find any Pokemon cards, I'll buy them off ya");
        }
    }

    public void BuySpellBook()
    {
        FlagManager.current.GainMoney(10);
        FlagManager.current.SetFlag(flags.hasCards, false);
        TextManager.current.EndChoice("Thanks dummy, these resell on Ebay for like $450!");
    }

    public void DontBuySpellBook()
    {
        TextManager.current.EndChoice("Why're you such a looser, sell me the cards!");
    }
}
