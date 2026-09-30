using UnityEngine;
using System.Collections;

public class NewGameSequence : MonoBehaviour {
    public LightBlink lightBlink;
    public SpriteFade spriteFade;
    public CanvasFade canvasFade;
    public GlitchAnimation glitch;
    public TMPro.TextMeshProUGUI nightText;
    public GameObject loadScreen;
    public NightTextFade nightTextFade;

    public void OnNewGameClicked(int night) {
        lightBlink.enabled = false;
        spriteFade.StartFade();
        canvasFade.StartFade();
        StartCoroutine(Sequence(night));

    }

    private IEnumerator Sequence(int night) {
        yield return new WaitForSeconds(4f);

        glitch.StartGlitch();

        nightText.text = "Night " + night;
        nightText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        nightTextFade.StartFade();
        yield return new WaitForSeconds(2f);

        loadScreen.SetActive(true);
        yield return new WaitForSeconds(3.5f);

        UnityEngine.SceneManagement.SceneManager.LoadScene("Night_" + night);
    }

}
