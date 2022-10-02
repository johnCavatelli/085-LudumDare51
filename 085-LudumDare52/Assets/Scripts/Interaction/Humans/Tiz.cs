using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiz : HumanInteraction
{
    void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        TextManager.current.StartDialogue(firstName, talkingSpriteFirst, talkingSpriteSecond);
        if (FlagManager.current.GetFlag(flags.hasCandyBar))
        {
            TextManager.current.MakeChoice("i need that candy bar... i might pass out");
            TextManager.current.getYesChoiceButton().onClick.AddListener(delegate { BuySpellBook(); });
            TextManager.current.getNoChoiceButton().onClick.AddListener(delegate { DontBuySpellBook(); });
        }
        else
        {
            TextManager.current.DisplayDialogue("I'm diabetic and terribly low on blood sugar. Please find my some candy or something....");
        }
    }

    public void BuySpellBook()
    {
        FlagManager.current.GainMoney(15);
        FlagManager.current.SetFlag(flags.hasCandyBar, false);
        TextManager.current.EndChoice("thanks ten, i should be okay now. I'll just lie here a little longer");
        Destroy(gameObject, 15f);
    }

    public void DontBuySpellBook()
    {
        TextManager.current.EndChoice("I'm going to pass out...");
        Destroy(gameObject, 1);
    }
}
