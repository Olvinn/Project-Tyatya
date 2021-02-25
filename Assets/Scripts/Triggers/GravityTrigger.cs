using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTrigger : PlayerTrigger
{
    protected override void PlayerStay()
    {
        base.PlayerStay();
        sc.SetGravity(180-transform.rotation.eulerAngles.z);
    }
    protected override void PlayerOut()
    {
        base.PlayerOut();
        sc.ResetGravity();
    }
}
