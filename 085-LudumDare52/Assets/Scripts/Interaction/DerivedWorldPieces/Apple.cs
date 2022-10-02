using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : WorldObjectInteractable
{
    private void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        FlagManager.current.SetFlag(flags.hasApple, true);
        TextManager.current.DisplayMessage("Picked up Apple");
        AudioManager.current.coinSource1.Play();
        Destroy(gameObject);
    }
}
