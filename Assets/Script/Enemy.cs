using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharecterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharecterStats myStats;

    private void Start()
    {
        playerManager = PlayerManager.instence;
        myStats = GetComponent<CharecterStats>();
    }
    public override void interact()
    {
        base.interact();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if(playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }
}
