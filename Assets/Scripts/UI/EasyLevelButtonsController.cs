using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyLevelButtonsController : ButtonsController
{
    void Start()
    {
        CreateButtons(sm.easyLevels);
    }
}
