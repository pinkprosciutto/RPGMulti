using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private NetworkManagerLobby networkManager;

    [SerializeField] private GameObject landingPanel;

    public void HostLobby()
    {
        networkManager.StartHost();
        landingPanel.SetActive(false);
    }
}
