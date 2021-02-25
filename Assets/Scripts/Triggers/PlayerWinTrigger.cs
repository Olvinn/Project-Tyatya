using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinTrigger : PlayerTrigger
{
    protected override void PlayerIn(GameObject player)
    {
        base.PlayerIn(player);
        sc.PlayerWin();
    }
}
