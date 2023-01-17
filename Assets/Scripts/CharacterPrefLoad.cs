using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPrefLoad : MonoBehaviour
{
    private static readonly string CharacterP1Pref = "CharacterP1Pref";
    private static readonly string CharacterP2Pref = "CharacterP2Pref";
    int P1ChosenCharacter;
    int P2ChosenCharacter;

    public GameObject P1scientist;
    public GameObject P1gladiator;
    public GameObject P2scientist;
    public GameObject P2gladiator;

    public GameObject P1scientistIcon;
    public GameObject P1gladiatorIcon;
    public GameObject P2scientistIcon;
    public GameObject P2gladiatorIcon;

    void Awake()
    {
        loadCharacterChosen();
        P1scientistIcon.SetActive(false);
        P2scientistIcon.SetActive(false);
        P1gladiatorIcon.SetActive(false);
        P2gladiatorIcon.SetActive(false);
        SpawnP1Player();
        SpawnP2Player();
    }

    void loadCharacterChosen()
    {
        P1ChosenCharacter = PlayerPrefs.GetInt(CharacterP1Pref);
        P2ChosenCharacter = PlayerPrefs.GetInt(CharacterP2Pref);
        Debug.Log(P1ChosenCharacter);
        Debug.Log(P2ChosenCharacter);
    }

    void SpawnP1Player()
    {
        switch (P1ChosenCharacter)
        {
            case 0:
                Instantiate(P1scientist, new Vector3(-6, -2.65f, 0), Quaternion.identity);
                P1scientistIcon.SetActive(true);
                break;
            case 1:
                Instantiate(P1gladiator, new Vector3(-6, -2.65f, 0), Quaternion.identity);
                P1gladiatorIcon.SetActive(true);
                break;
            case 2: //cyborg
                Instantiate(P1scientist, new Vector3(-6, -2.65f, 0), Quaternion.identity);
                break;
            case 3: //ice man
                Instantiate(P1scientist, new Vector3(-6, -2.65f, 0), Quaternion.identity);
                break;
            case 4: //cyberpunk
                Instantiate(P1scientist, new Vector3(-6, -2.65f, 0), Quaternion.identity);
                break;
            case 5: //piraat
                Instantiate(P1scientist, new Vector3(-6, -2.65f, 0), Quaternion.identity);
                break;
            default:
                break;
        }
    }

    void SpawnP2Player()
    {
        switch (P2ChosenCharacter)
        {
            case 0:
                Instantiate(P2scientist, new Vector3(6, -2.5f, 0), Quaternion.identity);
                P2scientistIcon.SetActive(true);
                break;
            case 1:
                Instantiate(P2gladiator, new Vector3(6, -2.5f, 0), Quaternion.identity);
                P2gladiatorIcon.SetActive(true);
                break;
            case 2: //cyborg
                Instantiate(P2scientist, new Vector3(6, -2.5f, 0), Quaternion.identity);
                break;
            case 3: //ice man
                Instantiate(P2scientist, new Vector3(6, -2.5f, 0), Quaternion.identity);
                break;
            case 4: //cyberpunk
                Instantiate(P2scientist, new Vector3(6, -2.5f, 0), Quaternion.identity);
                break;
            case 5: //piraat
                Instantiate(P2scientist, new Vector3(6, -2.5f, 0), Quaternion.identity);
                break;
            default:
                break;
        }
    }
}
