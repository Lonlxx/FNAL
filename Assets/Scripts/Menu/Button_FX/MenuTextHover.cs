using UnityEngine;
using TMPro;

public class MenuTextHover : MonoBehaviour {
    public TextMeshProUGUI menuText;

    public string normalText = "New Game";
    public string hoverText = "New Game - Night 1";

    public void OnHoverEnter() {
        menuText.text = hoverText;
    }

    public void OnHoverExit() {
        menuText.text = normalText;
    }
}
