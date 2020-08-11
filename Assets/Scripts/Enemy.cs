using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable 
{
    PlayerManager playerManager;
    CharacterStat myStats;


    void Start()
    {
        myStats = GetComponent<CharacterStat>();
        playerManager = PlayerManager.instance;   
    }

    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = playerManager.Player.GetComponent<CharacterCombat>();
        if(playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }
}
