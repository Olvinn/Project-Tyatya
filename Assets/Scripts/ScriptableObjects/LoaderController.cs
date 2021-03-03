using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Loader controller")]
public class LoaderController : ScriptableObject
{
    public string mainMenu, playScene;
    public List<string> testLevels;
    public List<string> easyLevels;

    private string currentScene;

    public void Restart()
    {
        LoadScene(currentScene);
    }

    public void LoadScene(string name)
    {
        if (!testLevels.Contains(name) && !easyLevels.Contains(name))
            return;

        currentScene = name;
        AsyncOperation play = SceneManager.LoadSceneAsync(playScene, LoadSceneMode.Single);
        AsyncOperation level = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }

    public void LoadNext()
    {
        if (testLevels.Contains(currentScene))
            for (int i = 0; i < testLevels.Count; i++)
                if (testLevels[i] == currentScene)
                    if(i < testLevels.Count - 1)
                    {
                        LoadScene(testLevels[i+1]);
                        return;
                    }
                    else
                    {
                        LoadScene(easyLevels[0]);
                        return;
                    }

        if (easyLevels.Contains(currentScene))
            for (int i = 0; i < easyLevels.Count; i++)
                if (easyLevels[i] == currentScene)
                    if(i < easyLevels.Count - 1)
                    {
                        LoadScene(easyLevels[i+1]);
                        return;
                    }

        LoadMain();
    }

    public void LoadMain()
    {
        AsyncOperation proc = SceneManager.LoadSceneAsync(mainMenu, LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
