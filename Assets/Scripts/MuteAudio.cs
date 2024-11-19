using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    private bool isMuted = false;

    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : 1;
    }
}