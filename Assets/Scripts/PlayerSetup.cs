using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerCamera;

    void Start()
    {
        if (!photonView.IsMine)
        {
            // Desactivar la cámara para los jugadores remotos
            playerCamera.SetActive(false);
        }
    }
}