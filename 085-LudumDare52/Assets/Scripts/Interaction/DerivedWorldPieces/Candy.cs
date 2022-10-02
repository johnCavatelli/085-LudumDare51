using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : WorldObjectInteractable
{
    private void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        FlagManager.current.SetFlag(flags.hasCandyBar, true);
        TextManager.current.DisplayMessage("Picked up a Candy Bar");
        AudioManager.current.coinSource1.Play();
        Destroy(gameObject);
    }
}
