using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int lives = 3;

    public int Lives { get { return lives; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void LostHealth()
    {
        if (lives > 0)
        {
            lives--;
            ResetLevel();
        }
        else
        {
            lives = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    public void ResetLevel()
    {
        FindObjectOfType<Ball>().ResetBall();
        FindObjectOfType<PlayerMovement>().ResetPlayer();
    }

    public void CompleteLevel()
    {
        if(transform.childCount <= 1)
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene++);
        }
    }
}
