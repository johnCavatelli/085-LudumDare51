using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shib : HumanInteraction
{
    void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        TextManager.current.StartDialogue(firstName, talkingSpriteFirst, talkingSpriteSecond);
        if (FlagManager.current.GetFlag(flags.hasBug1) && FlagManager.current.GetFlag(flags.hasBug2) && FlagManager.current.GetFlag(flags.hasBug3))
        {
            TextManager.current.MakeChoice("YOU HAVE 3 BUGS! I'LL DOUBLE YOUR MONEY FOR ALL OF THEM");
            TextManager.current.getYesChoiceButton().onClick.AddListener(delegate { BuyBug(4); });
            TextManager.current.getNoChoiceButton().onClick.AddListener(delegate { DontBuyBug(); });
        }
        else if (FlagManager.current.GetFlag(flags.hasBug1))
        {
            TextManager.current.MakeChoice("I'll buy that Hercules Beetle off of you for $5");
            TextManager.current.getYesChoiceButton().onClick.AddListener(delegate { BuyBug(1); });
            TextManager.current.getNoChoiceButton().onClick.AddListener(delegate { DontBuyBug(); });
        }        
        else if (FlagManager.current.GetFlag(flags.hasBug2))
        {
            TextManager.current.MakeChoice("I'll buy that Dung Beetle off of you for $6");
            TextManager.current.getYesChoiceButton().onClick.AddListener(delegate { BuyBug(2); });
            TextManager.current.getNoChoiceButton().onClick.AddListener(delegate { DontBuyBug(); });
        }        
        else if (FlagManager.current.GetFlag(flags.hasBug3))
        {
            TextManager.current.MakeChoice("I'll buy that Rolly Polly off of you for $9");
            TextManager.current.getYesChoiceButton().onClick.AddListener(delegate { BuyBug(3); });
            TextManager.current.getNoChoiceButton().onClick.AddListener(delegate { DontBuyBug(); });
        }
        else
        {
            TextManager.current.DisplayDialogue("I'm the biggest bug maniac around! Bring me a bug, or a bunch, and I'll pay you!");
        }
    }

    public void BuyBug(int bug)
    {
        if(bug == 1)
        {
            FlagManager.current.GainMoney(5);
            FlagManager.current.SetFlag(flags.hasBug1, false);
            TextManager.current.EndChoice("Thanks Ten, bring me more bugs for more money!");
        }        
        if(bug == 2)
        {
            FlagManager.current.GainMoney(6);
            FlagManager.current.SetFlag(flags.hasBug2, false);
            TextManager.current.EndChoice("Thanks Ten, bring me more bugs for more money!");
        }        
        if(bug == 3)
        {
            FlagManager.current.GainMoney(9);
            FlagManager.current.SetFlag(flags.hasBug3, false);
            TextManager.current.EndChoice("Thanks Ten, bring me more bugs for more money!");
        }        
        if(bug == 4)
        {
            FlagManager.current.GainMoney(FlagManager.current.GetMoney());
            FlagManager.current.SetFlag(flags.hasBug1, false);
            FlagManager.current.SetFlag(flags.hasBug2, false);
            FlagManager.current.SetFlag(flags.hasBug3, false);
            TextManager.current.EndChoice("Thanks Ten, I'm not sure there's any more bugs around!");
        }
    }

    public void DontBuyBug()
    {
        TextManager.current.EndChoice("Ah, geez, please sell it to me!");
    }
}
