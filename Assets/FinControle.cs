using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class FinControle : MonoBehaviour
{
    private UIDocument _uiDocument;
    private Button _playButton;

    void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
        _playButton= _uiDocument.rootVisualElement.Q<Button>("Suivant");
        _playButton.clicked += playButtonClicked;
               
    }
void playButtonClicked()
{
        Application.OpenURL("http://localhost:3000/Tir");
}
}
