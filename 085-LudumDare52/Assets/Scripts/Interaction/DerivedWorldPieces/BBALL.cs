using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBALL : WorldObjectInteractable
{
    private void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        FlagManager.current.SetFlag(flags.hasBall, true);
        TextManager.current.DisplayMessage("Picked up Basketball");
        AudioManager.current.coinSource1.Play();
        Destroy(gameObject);
    }
}
