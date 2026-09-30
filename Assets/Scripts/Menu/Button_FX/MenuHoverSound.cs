using UnityEngine;
using UnityEngine.Audio;

public class MenuHoverSound : MonoBehaviour {
    public AudioSource sfx;

    public void PlayHoverSound() {
        if(!sfx.isPlaying)
            sfx.Play();
    }

    public void TurnOffAudio() {
        if(sfx != null)
            sfx.enabled = false; // desativa o AudioSource
    }
}
