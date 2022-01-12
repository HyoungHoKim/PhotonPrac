using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    #region Public Fields
    public GameObject[] playerPrefabs;
    public Transform[] spawnPoints;
    #endregion

    #region MonoBehaviour CallBacks
    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNumber];
        GameObject playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
