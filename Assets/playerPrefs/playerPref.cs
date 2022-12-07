using UnityEngine;

public class playerPref : MonoBehaviour
{
    public int audio;
    public int sfx;
    public int ambience;
    public int brightness;

    public int player1Caracter;
    public int player2Caracter;

    public int lives;
    public float speed;
    public float jumpforce;
    public int jumpCount = 2;

    public playerPref(int life, float spd, float jumpf, int jumpc)
    {
        this.lives = life;
        this.speed = spd;
        this.jumpforce = jumpf;
        this.jumpCount = jumpc;
    }
}