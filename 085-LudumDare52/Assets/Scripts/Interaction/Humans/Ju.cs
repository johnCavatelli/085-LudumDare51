using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ju : HumanInteraction
{
    void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        TextManager.current.StartDialogue(firstName, talkingSpriteFirst, talkingSpriteSecond);
        if (FlagManager.current.GetFlag(flags.hasDeadBird))
        {
            TextManager.current.MakeChoice("Would you like to sacrifice that bird in the name of our Pillar God?");
            TextManager.current.getYesChoiceButton().onClick.AddListener(delegate { BuySpellBook(); });
            TextManager.current.getNoChoiceButton().onClick.AddListener(delegate { DontBuySpellBook(); });
        }
        else
        {
            TextManager.current.DisplayDialogue("The pillar has stood here for millenia. I am looking for animal sacrifices to appease our Pillar God");
        }
    }

    public void BuySpellBook()
    {
        FlagManager.current.GainMoney(5);
        FlagManager.current.SetFlag(flags.hasDeadBird, false);
        TextManager.current.EndChoice("The Pillar God will be pleased with you. Here's $5 for your troubles");        
    }

    public void DontBuySpellBook()
    {
        TextManager.current.EndChoice("If someone you love dies soon, assume its because of what you just did...");
        Destroy(gameObject, 1);
    }
}
