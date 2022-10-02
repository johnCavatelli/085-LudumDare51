using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonCards : WorldObjectInteractable
{
    private void Start()
    {
        setTipText(tip);
    }

    public override void Interact()
    {
        FlagManager.current.SetFlag(flags.hasCards, true);
        TextManager.current.DisplayMessage("Picked up Pokemon Cards");
        AudioManager.current.coinSource1.Play();
        Destroy(gameObject);
    }
}
