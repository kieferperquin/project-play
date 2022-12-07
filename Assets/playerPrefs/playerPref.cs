using UnityEngine;

public class playerPref
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
    public int jumpCount;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;

    public playerPref(int life, float spd, float jumpF, int jumpC, float dashingP, float dashingT, float dashingC)
    {
        this.lives = life;
        this.speed = spd;
        this.jumpforce = jumpF;
        this.jumpCount = jumpC;
        this.dashingPower = dashingP;
        this.dashingTime = dashingT;
        this.dashingCooldown = dashingC;
    }
}