using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveGame : MonoBehaviour {
    public static GameController gameController;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameController.gameController.Delete();

        }

        if (Input.GetButtonDown("Save"))
        {
            GameController.gameController.playerPositionX = transform.position.x;
            GameController.gameController.playerPositionY = transform.position.y;
            GameController.gameController.playerPositionZ = transform.position.z;
            Debug.Log("save");
        }
        if (Input.GetButtonDown("Load"))
        {
            GameController.gameController.Load();
            transform.position = new Vector3
            (
                GameController.gameController.playerPositionX,
                GameController.gameController.playerPositionY,
                GameController.gameController.playerPositionZ
            );
        }
    }
}

