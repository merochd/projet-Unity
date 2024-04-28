using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    [SerializeField] private UIDocument _hud;

    private Label _ennemiesLabel;
    private Label _endGameLabel1;
    private Label _endGameLabel2;
    
    void Start()
    {
        VisualElement root = _hud.rootVisualElement;
        if (root is not null)
        {
            _ennemiesLabel = root.Q<Label>("EnnemiesLabel");
            _endGameLabel1 = root.Q<Label>("EndGameWin");
            _endGameLabel2 = root.Q<Label>("EndGameMessage");
            HideEndGame();
        }
    }


    public void SetEnnemiesLabel(string lbl)
    {
        if (_ennemiesLabel is not null)
        {
            _ennemiesLabel.text = lbl;
        }
    }

    public void HideEndGame()
    {
        Debug.Log("on cache les labels");
        if(_endGameLabel1 is not null)
        {
        	_endGameLabel1.style.display = DisplayStyle.None;
            
        }
        if(_endGameLabel2 is not null)
        {
            _endGameLabel2.style.display = DisplayStyle.None;
        }
    }
    public void ShowEndGame()
    {
        Debug.Log("on affiche les labels");
        if(_endGameLabel1 is not null)
        {
            _endGameLabel1.style.display = DisplayStyle.Flex;
        }
        if(_endGameLabel2 is not null)
        {
            _endGameLabel2.style.display = DisplayStyle.Flex;
        }
    }
}
