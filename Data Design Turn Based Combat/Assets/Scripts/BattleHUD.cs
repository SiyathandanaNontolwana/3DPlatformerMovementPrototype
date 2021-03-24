using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text minHP;
    public Text maxHP;
 

    public void setHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        maxHP.text = unit.maxHP.ToString();
        minHP.text = unit.currentHP.ToString();
    }

    public void SetHP(int hp)
    {
   
    }
}
