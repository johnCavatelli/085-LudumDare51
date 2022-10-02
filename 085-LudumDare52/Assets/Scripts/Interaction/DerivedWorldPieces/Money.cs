using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : WorldObjectInteractable
{
    public int dollarAmount;
    private void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        FlagManager.current.GainMoney(dollarAmount);
        TextManager.current.DisplayMessage("Found $" + dollarAmount);
        AudioManager.current.coinSource1.Play();
        Destroy(gameObject);
    }
}
