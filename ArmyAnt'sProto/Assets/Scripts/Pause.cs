using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    public GameObject PauseUI;
    public Transform player;
    public Transform enemy;
    public int score = 0;

    public int[] SceneID = new int[] { '0', '1', '2', '3' };
    private bool paused = false;

    void Start() {
        PauseUI.SetActive(false);
    }

    void Update() {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }
        if (paused) {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void save()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetFloat("PlayerPosX", player.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", player.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", player.position.z);

        PlayerPrefs.SetFloat("EnemyPosX", enemy.position.x);
        PlayerPrefs.SetFloat("EnemyPosY", enemy.position.y);
        PlayerPrefs.SetFloat("EnemyPosZ", enemy.position.z);
        PlayerPrefs.SetInt("SceneID", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();

        Debug.Log("save");
    }


    public void Load()
    {
        PlayerPrefs.GetInt("Score", 0);
        PlayerPrefs.GetInt("SceneID", SceneManager.GetActiveScene().buildIndex);
        player.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"), PlayerPrefs.GetFloat("PlayerPosZ"));
        enemy.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"), PlayerPrefs.GetFloat("PlayerPosZ"));
        Debug.Log("Load");
    }

    public void resume (){
        paused = false;
    }

    public void restart() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
    public void Quit() {
        Application.Quit();
    }
}
