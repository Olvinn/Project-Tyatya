using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] protected LoaderController sm;
    [SerializeField] protected CurtainController cc;
    Dictionary<string, Button> buttons;

    protected void CreateButtons(List<string> names)
    {
        buttons = new Dictionary<string, Button>();
        foreach (string name in names)
        {
            Button b = Instantiate(button, transform);
            b.onClick.AddListener(() => cc.StartLoadingScene(name));
            b.GetComponentInChildren<Text>().text = name;
            buttons.Add(name, b);
        }
    }
}
