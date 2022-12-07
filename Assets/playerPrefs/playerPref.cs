using UnityEngine;

public class playerPref : MonoBehaviour
{
    public int audio;
    public int sfx;
    public int ambience;
    public int brightness;

    public int player1Caracter;
    public int player2Caracter;

    public int lifesP1;
    public int lifesP2;
    
    public playerPref(int life)
    {
        this.lifesP1 = life;
    }
}