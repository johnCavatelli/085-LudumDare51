using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diez : HumanInteraction
{
    public int spellCost = 50;
    void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        TextManager.current.StartDialogue(firstName, talkingSpriteFirst, talkingSpriteSecond);
        if (FlagManager.current.GetMoney() > spellCost)
        {
            TextManager.current.MakeChoice("Do you want to buy my spellbook?");
            TextManager.current.getYesChoiceButton().onClick.AddListener(delegate { BuySpellBook(); });
            TextManager.current.getNoChoiceButton().onClick.AddListener(delegate { DontBuySpellBook(); });
        }
        else
        {
            TextManager.current.DisplayDialogue("You don't have enough cash for the spellbook... Come back when you have $" + spellCost);
        }
    }

    public void BuySpellBook()
    {
        SceneManager.LoadScene(3);
    }

    public void DontBuySpellBook()
    {
        TextManager.current.EndChoice("LAME! How will you ever change your fate if you don't buy the spell?");
    }
}
