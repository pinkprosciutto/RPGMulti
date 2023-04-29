using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
	public TextMeshProUGUI nameText;
	public Slider hpSlider;
	public Image battleHud;

	public TextMeshProUGUI healthBar;

	public void SetHUD(Unit unit)
	{
		Debug.Log("Set Hud");
		nameText.text = unit.playerName;
		

		healthBar.text = unit.currentHP.ToString();

		if (hpSlider != null)
        {
			hpSlider.maxValue = unit.maxHP;
			hpSlider.value = unit.currentHP;
		}
	
	}

	public void SetHP(int hp)
	{
		hpSlider.value = hp;
		healthBar.text = hp.ToString();

	}

}
