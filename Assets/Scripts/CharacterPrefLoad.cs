using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public GameObject P1scientistUI;
    public GameObject P1gladiatorUI;
    public GameObject P2scientistUI;
    public GameObject P2gladiatorUI;

    public TMP_Text P1Health;
    public TMP_Text P2Health;

    void Awake()
    {
        loadCharacterChosen();
        P1scientistUI.SetActive(false);
        P1gladiatorUI.SetActive(false);
        P2scientistUI.SetActive(false);
        P2gladiatorUI.SetActive(false);
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
                P1scientistUI.SetActive(true);
                break;
            case 1:
                Instantiate(P1gladiator, new Vector3(-6, -2.65f, 0), Quaternion.identity);
                P1gladiatorUI.SetActive(true);
                break;
            case 2: //cyborg
                Instantiate(P1scientist, new Vector3(-6, -2.65f, 0), Quaternion.identity);
                P1scientistUI.transform.position = new Vector3(-7.22222233f, -3.93518519f, -8.90740776f);
                break;
            case 3: //ice man
                Instantiate(P1scientist, new Vector3(-6, -2.65f, 0), Quaternion.identity);
                P1scientistUI.transform.position = new Vector3(-7.22222233f, -3.93518519f, -8.90740776f);
                break;
            case 4: //cyberpunk
                Instantiate(P1scientist, new Vector3(-6, -2.65f, 0), Quaternion.identity);
                P1scientistUI.transform.position = new Vector3(-7.22222233f, -3.93518519f, -8.90740776f);
                break;
            case 5: //piraat
                Instantiate(P1scientist, new Vector3(-6, -2.65f, 0), Quaternion.identity);
                P1scientistUI.transform.position = new Vector3(-7.22222233f, -3.93518519f, -8.90740776f);
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
                P2scientistUI.SetActive(true);
                break;
            case 1:
                Instantiate(P2gladiator, new Vector3(6, -2.5f, 0), Quaternion.identity);
                P2gladiatorUI.SetActive(true);
                break;
            case 2: //cyborg
                Instantiate(P2scientist, new Vector3(6, -2.5f, 0), Quaternion.identity);
                P1scientistUI.transform.position = new Vector3(7.22222233f, -3.93518519f, -8.90740776f);
                break;
            case 3: //ice man
                Instantiate(P2scientist, new Vector3(6, -2.5f, 0), Quaternion.identity);
                P1scientistUI.transform.position = new Vector3(7.22222233f, -3.93518519f, -8.90740776f);
                break;
            case 4: //cyberpunk
                Instantiate(P2scientist, new Vector3(6, -2.5f, 0), Quaternion.identity);
                P1scientistUI.transform.position = new Vector3(7.22222233f, -3.93518519f, -8.90740776f);
                break;
            case 5: //piraat
                Instantiate(P2scientist, new Vector3(6, -2.5f, 0), Quaternion.identity);
                P1scientistUI.transform.position = new Vector3(7.22222233f, -3.93518519f, -8.90740776f);
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        P1Health.text = PlayerMovement1.P1Health.text;
        P2Health.text = PlayerMovement2.P2Health.text;
    }
}
