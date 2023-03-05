using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuControle : MonoBehaviour
{
    private UIDocument _uiDocument;
    private Button _playButton;
    void Awake()
    {
        _uiDocument= GetComponent<UIDocument>();
        _playButton= _uiDocument.rootVisualElement.Q<Button>("Jouer");

        _playButton.clicked += playButtonClicked;
               
    }
    void playButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
