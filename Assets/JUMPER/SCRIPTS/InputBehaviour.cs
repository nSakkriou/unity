using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputBehaviour : MonoBehaviour
{
    public TMP_Text inputText;
    public static string choseUserName;
    // Start is called before the first frame update
    public void setCurrentUserName()
    {
        choseUserName = inputText.text;
    }
}
