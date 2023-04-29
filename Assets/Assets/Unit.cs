using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Unit : NetworkBehaviour
{
	[SyncVar] public string playerName;

	[SyncVar] public int damage;

    public int maxHP;
	[SyncVar] public int currentHP;
	[SyncVar] int turn;

	public int playerID = 0;


	bool attack = false;
	bool choosePlayer = true;
	public BattleSystem battleSystem;


    private void Start()
    {
		battleSystem = GameObject.FindGameObjectWithTag("Battle").GetComponent<BattleSystem>();
    }

    public void Update()
    {
		//turn = gameObject.GetComponent<BattleSystem>().playerTurn;
		
		gameObject.GetComponent<BattleHUD>().healthBar.text = currentHP.ToString();
		transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
		OnAttackButton();
		OnHealButton();
    }


    public bool TakeDamage(int dmg)
	{
		currentHP -= dmg;

		if (currentHP <= 0)
			return true;
		else
			return false;
	}

	public void Heal(int amount)
	{
		currentHP += amount;
		if (currentHP > maxHP)
			currentHP = maxHP;
	}



	IEnumerator PlayerAttack(int attackPlayer)
	{
		Debug.Log("Player attacked");
		//state = BattleState.PLAYERATTACKED;
		battleSystem.playerPrefabs[attackPlayer].TakeDamage(5);

		battleSystem.playerHUDs[attackPlayer].SetHP(5);

		//state = BattleState.PLAYERTURN;
		choosePlayer = true;
		battleSystem.PlayerTurn();
		battleSystem.hasActed = true;
		yield return null;

	}

	IEnumerator PlayerHeal()
	{
		battleSystem.playerPrefabs[battleSystem.playerTurn].Heal(5);
		//battleSystem.playerPrefabs[battleSystem.playerTurn].SetHP(battleSystem.playerPrefabs[turn].currentHP);

		
		battleSystem.PlayerTurn();
		battleSystem.hasActed = true;
		//playerHUD.SetHP(playerUnit.currentHP);
		//dialogueText.text = "You feel renewed strength!";

		yield return null;

	}

	public void OnAttackButton()
	{
		int attackPlayer = 0;
		if (isLocalPlayer) return;
		Debug.Log("Press Z");

		if (Input.GetKeyDown(KeyCode.Z))
		{
			Debug.Log("Press Z");
			attack = true;
		}

		Attack();
	}

	void Attack()
	{
		int attackPlayer = 0;
		Debug.Log("AAAAAAAa");
		if (attack && choosePlayer)
		{
			
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				attackPlayer = 0;
				attack = false;
				choosePlayer = false;
				Debug.Log("Attack Player 1");
				StartCoroutine(PlayerAttack(attackPlayer));
			}

			if (turn != 1)
			{
				if (Input.GetKeyDown(KeyCode.Alpha2))
				{
					attackPlayer = 1; attack = false;
					choosePlayer = false;
					Debug.Log("Attack Player 2");
					StartCoroutine(PlayerAttack(attackPlayer));

				}
			}

			if (turn != 2)
			{
				if (Input.GetKeyDown(KeyCode.Alpha3))
				{
					attackPlayer = 2; attack = false;
					choosePlayer = false;
					Debug.Log("Attack Player 3");
					StartCoroutine(PlayerAttack(attackPlayer));
				}

			}

			if (turn != 3)
			{
				if (Input.GetKeyDown(KeyCode.Alpha4))
				{
					attackPlayer = 3; attack = false;
					choosePlayer = false;
					StartCoroutine(PlayerAttack(attackPlayer));

				}
			}

			if (turn != 4)
			{
				if (Input.GetKeyDown(KeyCode.Alpha5))
				{
					attackPlayer = 4; attack = false;
					choosePlayer = false;
					StartCoroutine(PlayerAttack(attackPlayer));

				}
			}

			if (turn != 5)
			{
				if (Input.GetKeyDown(KeyCode.Alpha6))
				{
					attackPlayer = 5; attack = false;
					choosePlayer = false;
					StartCoroutine(PlayerAttack(attackPlayer));

				}
			}

			if (turn != 6)
			{
				if (Input.GetKeyDown(KeyCode.Alpha7))
				{
					attackPlayer = 6; attack = false;
					choosePlayer = false;
					StartCoroutine(PlayerAttack(attackPlayer));

				}
			}

			if (turn != 7)
			{
				if (Input.GetKeyDown(KeyCode.Alpha8))
				{
					attackPlayer = 7; attack = false;
					choosePlayer = false;
					StartCoroutine(PlayerAttack(attackPlayer));

				}
			}
		}
	}
	
	public void OnHealButton()
	{
		if (Input.GetKeyDown(KeyCode.X))
		{
			Debug.Log("Heal");
			StartCoroutine(PlayerHeal());
		}

	}

}
