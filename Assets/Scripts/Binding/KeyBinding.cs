using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Serialization;

public class KeyBinding : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    public void Save()
    {
        PlayerData data = new PlayerData();
        data.position = new float[] { transform.position.x, transform.position.y, transform.position.z };
        data.Speed = new Player(speed);
        SaveLoadSystem.playerData = data;
        SaveLoadSystem.instance.Save();
    }

    private void Start()
    {
        FindObjectOfType<SaveLoadSystem>().Load();
        PlayerData data = SaveLoadSystem.playerData;
        transform.position = data.Position;
        speed = data.Speed.speed;
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = speed * Time.deltaTime;

        if (BindingManager.BindingHeld("Forward"))
            transform.position += transform.forward * moveSpeed;

        if (BindingManager.BindingHeld("Right"))
            transform.position += transform.right * moveSpeed;

        if (BindingManager.BindingHeld("Backward"))
            transform.position -= transform.forward * moveSpeed;

        if (BindingManager.BindingHeld("Left"))
            transform.position -= transform.right * moveSpeed;
    }
}
