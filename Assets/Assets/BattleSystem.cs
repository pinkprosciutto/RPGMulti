using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public enum BattleState { START, PLAYERTURN, PLAYERATTACKED }

public class BattleSystem : NetworkBehaviour
{
	public List<Unit> playerPrefabs;

	public Text dialogueText;

	public List<BattleHUD> playerHUDs;

	GameObject[] players;

	[SyncVar] public BattleState state;
	[SyncVar] bool choosePlayer = true;
	[SyncVar] bool attack = false;
	[SyncVar] int numberOfPlayers = 7;
	[SyncVar] public int playerTurn = 0;
	[SyncVar] int turn = 0;
	[SyncVar] public bool hasActed = false;


	void Start()
    {
		state = BattleState.START;
		numberOfPlayers = NetworkManagerTurnBased.totalPlayers;
		//StartCoroutine(SetupBattle());
	}

    private void Update()
    {
		Debug.Log("Player Turn: " + playerTurn);
		players = GameObject.FindGameObjectsWithTag("Player");
		numberOfPlayers = NetworkManagerTurnBased.totalPlayers;
		turn = playerTurn;

		for (int i = 0; i < players.Length; i++)
		{
			if (!playerPrefabs.Contains(players[i].GetComponent<Unit>()))
            {
				playerPrefabs.Add(players[i].GetComponent<Unit>());
				playerHUDs.Add(players[i].GetComponent<BattleHUD>());
				StartCoroutine(SetupBattle());
			}
		}

		if (NetworkManagerTurnBased.addedPlayers)
        {
	        StartCoroutine(SetupBattle());
			NetworkManagerTurnBased.addedPlayers = false;
		}

        //OnAttackButton();
	    //OnHealButton();

		CalculatePlayerTurn();
	
		PlayerTurn();
    }

    IEnumerator SetupBattle()
	{
		for (int x = 0; x < playerHUDs.Count; x++)
        {
            playerHUDs[x].SetHUD(playerPrefabs[x]);
        }
       
        yield return null;
		
	}

	void CalculatePlayerTurn()
    {
		if (hasActed || playerPrefabs[playerTurn].currentHP <= 0)
		{
			playerTurn++;

			hasActed = false;
		}


		if (playerTurn > numberOfPlayers - 1)
		{
			playerTurn = 0;
		}
	}

	public void PlayerTurn()
	{
		int currentPlayerTurn = turn;// - 1;

		foreach (BattleHUD player in playerHUDs)
        {
			player.battleHud.color = Color.white;
        }

		playerHUDs[currentPlayerTurn].battleHud.color = Color.red;

	}

	IEnumerator PlayerAttack(int attackPlayer)
	{
		Debug.Log("Player attacked");
		//state = BattleState.PLAYERATTACKED;
		playerPrefabs[attackPlayer].TakeDamage(5);

		playerHUDs[attackPlayer].SetHP(5);


		//state = BattleState.PLAYERTURN;
		choosePlayer = true;
		PlayerTurn();
		hasActed = true;
		yield return null;

	}

	IEnumerator PlayerHeal()
	{
		playerPrefabs[turn].Heal(5);
		playerHUDs[turn].SetHP(playerPrefabs[turn].currentHP);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
		hasActed = true;
		//playerHUD.SetHP(playerUnit.currentHP);
		//dialogueText.text = "You feel renewed strength!";

		yield return null;

	}

	public void OnAttackButton()
	{
		int attackPlayer = 0;

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
			if (turn != 0)
			{
				if (Input.GetKeyDown(KeyCode.Alpha1))
				{
					attackPlayer = 0;
					attack = false;
					choosePlayer = false;
					Debug.Log("Attack Player 1");
					StartCoroutine(PlayerAttack(attackPlayer));
				}
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
