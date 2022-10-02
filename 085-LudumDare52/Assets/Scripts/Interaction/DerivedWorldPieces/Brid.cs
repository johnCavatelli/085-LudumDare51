using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brid : WorldObjectInteractable
{
    private void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        FlagManager.current.SetFlag(flags.hasDeadBird, true);
        TextManager.current.DisplayMessage("Slid Decaying Bird Into Pocket");
        AudioManager.current.coinSource1.Play();
        Destroy(gameObject);
    }
}
