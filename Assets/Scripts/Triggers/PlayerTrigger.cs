using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    protected SceneController sc;
    public UnityEvent onTriggered, onExit;

    private void Start()
    {
        sc = SceneController.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            PlayerIn(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            PlayerOut();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            PlayerStay();
    }

    protected virtual void PlayerIn(GameObject player)
    {
        onTriggered?.Invoke();
    }

    protected virtual void PlayerOut()
    {
        onExit?.Invoke();
    }

    protected virtual void PlayerStay()
    {

    }
}
