using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JoinLobbyMenu : MonoBehaviour
{
    [SerializeField] private NetworkManagerLobby networkManager;

    [SerializeField] private GameObject landingPanel;
    [SerializeField] private TMP_InputField ipAddressInputField;
    [SerializeField] private Button joinButton;

    private void Update()
    {
    }

    private void OnEnable()
    {
        NetworkManagerLobby.OnClientConnected += HandleClientConnected;
        NetworkManagerLobby.OnClientDisconnected += HandleClientDisconnected;

    }

    private void OnDisable()
    {
        NetworkManagerLobby.OnClientConnected -= HandleClientConnected;
        NetworkManagerLobby.OnClientDisconnected -= HandleClientDisconnected;
    }

    public void JoinLobby()
    {
        string ipAddress = ipAddressInputField.text;
       
        networkManager.StartClient();
        networkManager.networkAddress = ipAddress;

        joinButton.interactable = false;

    }

    void HandleClientConnected()
    {
        joinButton.interactable = false;
        Debug.Log("Client joined");

        gameObject.SetActive(false);
        landingPanel.SetActive(true);
    }

    void HandleClientDisconnected()
    {
        joinButton.interactable = true;
        Debug.Log("Disconnected");
    }
}
