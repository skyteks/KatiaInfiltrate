using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour, ITrigger
{
    public string sceneName;

    public void Trigger()
    {
        SceneManager.LoadScene(sceneName);
    }
}
