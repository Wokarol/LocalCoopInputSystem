using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] NewPlayerInput playePrefab;
    Dictionary<int, NewPlayerInput> players = new Dictionary<int, NewPlayerInput>();

    public bool PlayerExist(int id) {
        return players.ContainsKey(id);
    }

    public void HandleConnection(PlayerActions actions, int id) {
        if (!players.ContainsKey(id)) {
            Debug.Log($"Connecting Player");

            var player = Instantiate(playePrefab);
            player.gameObject.name = $"Player {id}";
            player.Set(actions);

            players.Add(id, player);
        }
    }

    public void HandleDisconnection(int id) {
        if (players.ContainsKey(id)) {
            Debug.Log($"Removing Player");
            players[id].GetComponent<NewPlayerInput>().Unset();
            Destroy(players[id].gameObject);
            players.Remove(id);
        }
    }
}
