using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenderButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text textLabel;

    public void Setup(string gender, Action<string> callback)
    {
        textLabel.text = gender;
            
        button.onClick.AddListener(delegate
        {
            callback?.Invoke(gender);
        });
    }
}
