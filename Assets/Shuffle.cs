using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shuffle : MonoBehaviour
{

    public float duration;
    public string nextSceneToLoad;
    public List<Image> images;

    void Start()
    {
        //var children = GetComponentsInChildren<Image>();
        foreach (var image in images)
        {
            //images.Enqueue(image);

            image.enabled = false;
        }
        StartCoroutine(Shuffleing());
    }

    private IEnumerator Shuffleing()
    {
        while (images.Count > 0)
        {
            var image = images[0];
            images.RemoveAt(0);
            image.enabled = true;
            yield return new WaitForSeconds(duration);
            image.enabled = false;
        }
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
