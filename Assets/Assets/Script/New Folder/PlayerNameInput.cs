using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Button continueButton;
   
    public static string DisplayName { get; private set; }
    private const string PlayerPrefsNameKey = "PlayerName";
    

    
    void Start()
    {
        SetupInputField();    
    }

    private void Update()
    {
        //Debug.Log(nameInputField.text);
    }

    void SetupInputField()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) return;

        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

        nameInputField.text = defaultName;

        SetPlayerName();

    }

    public void SetPlayerName()
    {
        bool hasName = !string.IsNullOrEmpty(nameInputField.text);

        continueButton.interactable = hasName;
    }

    public void SavePlayerName()
    {
        DisplayName = nameInputField.text;
        PlayerPrefs.SetString(PlayerPrefsNameKey, DisplayName);
    }
}
