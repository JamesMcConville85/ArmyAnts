using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveAndLoad : MonoBehaviour {

    public Transform player;
    public Transform enemy;
    public int score = 0;

    public int[] SceneID = new int[] { '0', '1', '2', '3' };


    public void save()
    {
        
        PlayerPrefs.SetFloat("PlayerPosX", player.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", player.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", player.position.z);

        PlayerPrefs.SetFloat("EnemyPosX", enemy.position.x);
        PlayerPrefs.SetFloat("EnemyPosY", enemy.position.y);
        PlayerPrefs.SetFloat("EnemyPosZ", enemy.position.z);
        PlayerPrefs.SetInt("SceneID", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        Debug.Log("Save");


    }


    public void Load()
    {
      
        PlayerPrefs.GetInt("SceneID", SceneManager.GetActiveScene().buildIndex);
        player.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"), PlayerPrefs.GetFloat("PlayerPosZ"));
        enemy.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"), PlayerPrefs.GetFloat("PlayerPosZ"));

    }
}
