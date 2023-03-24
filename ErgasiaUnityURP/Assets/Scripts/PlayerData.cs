using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public float[] position;

    public PlayerData(Player player) {
        health = player.currentHealth;

        position = new float[3];
        position[0] = player.transform.localPosition.x;
        position[1] = player.transform.localPosition.y;
        position[2] = player.transform.localPosition.z;
    }
}
