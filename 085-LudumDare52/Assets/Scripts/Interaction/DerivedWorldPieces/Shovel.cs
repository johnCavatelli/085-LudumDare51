using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : WorldObjectInteractable
{
    private void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        FlagManager.current.SetFlag(flags.hasShovel, true);
        TextManager.current.DisplayMessage("Picked up shovel");
        AudioManager.current.coinSource1.Play();
        Destroy(gameObject);
    }
}
