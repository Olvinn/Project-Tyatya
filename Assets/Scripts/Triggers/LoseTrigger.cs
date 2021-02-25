using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : PlayerTrigger
{
    protected override void PlayerIn(GameObject player)
    {
        if (!sc.playerInvulnerable)
        {
            base.PlayerIn(player);
            SceneController.Instance?.PlayerLose();
        }
    }
}
