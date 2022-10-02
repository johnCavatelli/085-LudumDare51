using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandbox : WorldObjectInteractable
{
    private void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        print("Hello");
        if (FlagManager.current.GetFlag(flags.hasShovel) && !FlagManager.current.GetFlag(flags.gotMoneyFromSandbox))
        {
            TextManager.current.DisplayMessage("Found $3 in the sanbox");
            FlagManager.current.SetFlag(flags.gotMoneyFromSandbox, true);
        }
    }
}
