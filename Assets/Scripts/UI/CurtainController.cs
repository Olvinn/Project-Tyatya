using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainController : Widget
{
    [SerializeField] LoaderController gc;

    private void Start()
    {
        _cg.alpha = 1;
        StartCoroutine(HideCoroutine());
    }

    public void StartRestart()
    {
        StartCoroutine(ShowCoroutine(() => gc.Restart()));
    }

    public void StartLoadingMain()
    {
        StartCoroutine(ShowCoroutine(() => gc.LoadMain()));
    }

    public void StartLoadingScene(string scene)
    {
        StartCoroutine(ShowCoroutine(() => gc.LoadScene(scene)));
    }

    public void StartLoadingNextScene()
    {
        StartCoroutine(ShowCoroutine(() => gc.LoadNext()));
    }
}
