using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Widget : MonoBehaviour
{
    public float speedModifier = 4f;
    protected CanvasGroup _cg;
    protected delegate void Del();

    private void Awake()
    {
        _cg = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        if (_cg.alpha != 0)
        {
            StartCoroutine(ShowCoroutine());
        }
        else
        {
            StartCoroutine(HideCoroutine());
        }
    }

    public void Show()
    {
        StopAllCoroutines();
        StartCoroutine(ShowCoroutine());
    }

    public void Hide()
    {
        StopAllCoroutines();
        StartCoroutine(HideCoroutine());
    }

    protected IEnumerator ShowCoroutine(Del callback = null)
    {
        _cg.blocksRaycasts = true;
        _cg.interactable = true;
        while (_cg.alpha < 1f)
        {
            _cg.alpha += Time.unscaledDeltaTime * speedModifier;

            yield return new WaitForEndOfFrame();
        }
        _cg.alpha = 1;
        callback?.Invoke();
    }

    protected IEnumerator HideCoroutine(Del callback = null)
    {
        _cg.blocksRaycasts = false;
        _cg.interactable = false;
        while (_cg.alpha > 0f)
        {
            _cg.alpha -= Time.unscaledDeltaTime * speedModifier;

            yield return new WaitForEndOfFrame();
        }
        _cg.alpha = 0;
        callback?.Invoke();
    }
}
