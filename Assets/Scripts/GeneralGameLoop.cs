using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralGameLoop : MonoBehaviour
{
    [SerializeField] GameObject blocks;
    [SerializeField] GameObject balls;

    // Update is called once per frame
    void Update()
    {
        if (blocks.transform.childCount==0)
        {
            LoadNextLevel();
        }
        if (balls.transform.childCount==0)
        {
            LoadGameOver();
        }
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}
