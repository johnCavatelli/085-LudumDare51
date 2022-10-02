using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : WorldObjectInteractable
{
    public flags toSet;
    private void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        FlagManager.current.SetFlag(toSet, true);
        TextManager.current.DisplayMessage("Picked up bug... Eww");
        AudioManager.current.coinSource1.Play();
        Destroy(gameObject);
    }
}
