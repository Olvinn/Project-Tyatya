using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    public UnityEvent playerWin, playerLose;
    public bool playerInvulnerable;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
        Time.timeScale = 1;
        playerInvulnerable = false;
    }

    private void Start()
    {
        ResetGravity();
    }

    public void PlayerLose()
    {
        playerInvulnerable = true;
        playerLose?.Invoke();
        StartCoroutine(LerpTimeTo(0f));
    }

    public void PlayerWin()
    {
        playerInvulnerable = true;
        playerWin?.Invoke();
        StartCoroutine(LerpTimeTo(0f));
    }

    public void Pause()
    {
        StartCoroutine(LerpTimeTo(0f));
    }

    public void Resume()
    {
        StopAllCoroutines();
        StartCoroutine(LerpTimeTo(1f));
    }

    public void SetGravity(float angle)
    {
        Physics2D.gravity = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad)) * Physics2D.gravity.magnitude;
    }

    public void ResetGravity()
    {
        Physics2D.gravity = new Vector2(Mathf.Sin(180 * Mathf.Deg2Rad), Mathf.Cos(180 * Mathf.Deg2Rad)) * Physics2D.gravity.magnitude;
    }

    IEnumerator LerpTimeTo(float t)
    {
        while (Time.timeScale > t)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, t, Time.deltaTime * 10);
            yield return new WaitForEndOfFrame();
        }
        Time.timeScale = t;
    }
}
