using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    //warrior text
    public Text htWA;
    public Text stWA;
    //valk text
    public Text htV;
    public Text stV;
    //wiz text
    public Text htWZ;
    public Text stWZ;
    //elf text
    public Text htE;
    public Text stE;


    private void Update()
    {
        stWA.text = "Score  " + Warrior.Uscore.ToString();
        htWA.text = "Health  " + Warrior.Uhealth.ToString();

        stV.text = "Score  " + Valkyrie.Uscore.ToString();
        htV.text = "Health  " + Valkyrie.Uhealth.ToString();

        stWZ.text = "Score  " + Wizard.Uscore.ToString();
        htWZ.text = "Health  " + Wizard.Uhealth.ToString();

        stE.text = "Score  " + Elf.Uscore.ToString();
        htE.text = "Health  " + Elf.Uhealth.ToString();
    }
}
