using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    public InputField myInputField;
    private string playerName; 

        

    public void StartNew()
    {

        SceneManager.LoadScene(1);

        
    }

    public void SaveName()
    {
       playerName = myInputField.text;
       //UnityEngine.Debug.Log(playerName);
       PlayerPrefs.SetString("name", playerName);
    }
}
