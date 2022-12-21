using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPrefLoad : MonoBehaviour
{
    private static readonly string CharacterP1Pref = "CharacterP1Pref";
    private static readonly string CharacterP2Pref = "CharacterP2Pref";
    int P1ChosenCharacter;
    int P2ChosenCharacter;

    int messagesSent = 0;
    void awake()
    {
        loadCharacterChosen();
    }

    void loadCharacterChosen()
    {
        P1ChosenCharacter = PlayerPrefs.GetInt(CharacterP1Pref);
        P2ChosenCharacter = PlayerPrefs.GetInt(CharacterP2Pref);
    }

    private void Update()
    {
        if (messagesSent == 1)
        {
            Debug.Log(PlayerPrefs.GetInt(CharacterP1Pref));
            Debug.Log(PlayerPrefs.GetInt(CharacterP2Pref));
        }
        messagesSent++;
    }
}