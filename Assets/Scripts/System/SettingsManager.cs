using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MenuManager
{
    public void SetVolume(System.Single incVol) {
        AudioListener.volume = incVol;
    }
}
