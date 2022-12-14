using UnityEngine;

public class playerPref
{
    public int lives;
    public float speed;
    public float damage;
    public float health;
    public float jumpforce;
    public int jumpCount;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;

    public playerPref(int life, float spd, float dmg, float hp,float jumpF, int jumpC, float dashingP, float dashingT, float dashingC)
    {
        this.lives = life;
        this.speed = spd;
        this.damage = dmg;
        this.health = hp;
        this.jumpforce = jumpF;
        this.jumpCount = jumpC;
        this.dashingPower = dashingP;
        this.dashingTime = dashingT;
        this.dashingCooldown = dashingC;
    }
}