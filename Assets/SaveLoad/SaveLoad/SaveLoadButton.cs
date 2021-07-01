using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Serialization;

[RequireComponent(typeof(Button))]
public class SaveLoadButton : MonoBehaviour
{
    public enum ButtonMode
    {
        Save,
        Load
    }

    [SerializeField] private ButtonMode mode = ButtonMode.Save;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();

        switch (mode)
        {
            case ButtonMode.Save:
                button.onClick.AddListener(SaveLoadSystem.instance.Save);
                break;
            case ButtonMode.Load:
                button.onClick.AddListener(SaveLoadSystem.instance.Load);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
