using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Text currentHP;
    public void updateHP(string incHp) {
        currentHP.text = incHp;
    }
}
