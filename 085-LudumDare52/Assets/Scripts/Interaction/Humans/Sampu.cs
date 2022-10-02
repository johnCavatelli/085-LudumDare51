using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sampu : HumanInteraction
{
    void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        TextManager.current.StartDialogue(firstName, talkingSpriteFirst, talkingSpriteSecond);
        if (FlagManager.current.GetFlag(flags.hasBadge))
        {
            if (FlagManager.current.GetFlag(flags.hasApple))
            {
                TextManager.current.MakeChoice("Can I buy apple? I'll double your money!!!");
                TextManager.current.getYesChoiceButton().onClick.AddListener(delegate { BuySpellBook(); });
                TextManager.current.getNoChoiceButton().onClick.AddListener(delegate { DontBuySpellBook(); });
            }
            else
            {
                TextManager.current.DisplayDialogue("Welcome valued brotherin. I am seeking an apple to appease our Lord");
            }
        }
        else
        {
            TextManager.current.DisplayDialogue("Don't talk to me unless you're in the Guild of the Lord");
        }
    }

    public void BuySpellBook()
    {
        FlagManager.current.GainMoney(FlagManager.current.GetMoney());
        FlagManager.current.SetFlag(flags.hasApple, false);
        TextManager.current.EndChoice("Thank you, we will both walk in the kingdom of Yahweh soon!");
    }

    public void DontBuySpellBook()
    {
        TextManager.current.EndChoice("The Lord wouldn't be happy with that choice. He speaks to me directly!");
    }
}
