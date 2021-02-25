using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelsButtonsController : ButtonsController
{
    void Start()
    {
        CreateButtons(sm.testLevels);
    }
}
