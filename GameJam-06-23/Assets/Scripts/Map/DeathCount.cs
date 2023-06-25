using UnityEngine;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
    public int nbDeath;
    public Text nbDeathText;

    public void addDeath() {
        nbDeath += 1;
        nbDeathText.text = nbDeath.ToString();
    }
}