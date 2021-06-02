using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Vector3 Position => new Vector3(position[0], position[1], position[2]);
    public Player Speed;

    public float[] position = new float[3];

    public PlayerData()
    {
        Speed = new Player(20);

        position[0] = position[1] = position[2] = 0;
    }

}
