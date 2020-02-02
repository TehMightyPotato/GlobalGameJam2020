using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelTimer : MonoBehaviour
{
    public float time;
    public int levelNumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadNewLevel());
    }

    IEnumerator LoadNewLevel()
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(levelNumber);
    }
}
