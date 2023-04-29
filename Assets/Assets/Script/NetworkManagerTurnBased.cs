using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkManagerTurnBased : NetworkManager
{
    public List<Transform> spawnLocation;

    public static int totalPlayers;
    public static bool addedPlayers = false;
    public BattleSystem battleSystem;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // add player at correct spawn position
        Transform start;

        switch (numPlayers)
        {
            case 0:
                start = spawnLocation[0];
                InstantiatePlayer(1, start, conn);
                break;
            case 1:
                start = spawnLocation[1];
                InstantiatePlayer(2, start, conn);
                break;
            case 2:
                start = spawnLocation[2];
                InstantiatePlayer(3, start, conn);
                break;
            case 3:
                start = spawnLocation[3];
                InstantiatePlayer(4, start, conn);
                break;
            case 4:
                start = spawnLocation[4];
                InstantiatePlayer(5, start, conn);
                break;
            case 5:
                start = spawnLocation[5];
                InstantiatePlayer(6, start, conn);
                break;
            case 6:
                start = spawnLocation[6];
                InstantiatePlayer(7, start, conn);
                break;
            case 7:
                start = spawnLocation[7];
                InstantiatePlayer(8, start, conn);
                break;
            default:
                start = spawnLocation[0];
                InstantiatePlayer(1, start, conn);
                break;
        }
        
       
        addedPlayers = true;
        totalPlayers = numPlayers;
        Debug.Log("number of players: " + totalPlayers);

    }

    void InstantiatePlayer(int playerID, Transform start, NetworkConnectionToClient conn)
    {
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        player.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        AddPlayerToBattle(player);
        player.GetComponent<Unit>().playerID = playerID;

        NetworkServer.AddPlayerForConnection(conn, player);
    }

    void AddPlayerToBattle(GameObject player)
    {
        Unit unit = player.GetComponent<Unit>();
        BattleHUD hud = player.GetComponent<BattleHUD>();
        battleSystem.playerPrefabs.Add(unit);
        battleSystem.playerHUDs.Add(hud);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }
}
