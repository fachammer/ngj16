using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Assertions;

public class GameOverHandler : MonoBehaviour {
    
    public GameplayManager gameplayManager;
    public GameOverScreen gameOverScreen;
    
    private void Awake() {
        Assert.IsNotNull(gameOverScreen);
        Assert.IsNotNull(gameplayManager);
        gameplayManager.PlayerWins += OnPlayerWins;
    }
    
    private void OnPlayerWins(Player winningPlayer) {
        IEnumerable<MonoBehaviour> controllers = GameObject.FindObjectsOfType<Controlls>();
        IEnumerable<MonoBehaviour> deathTriggers = GameObject.FindObjectsOfType<DeathTrigger>();    
            
        var componentsToDisable = controllers.Concat(deathTriggers);
        foreach(var component in componentsToDisable) {
            component.enabled = false;
        }
        
        gameOverScreen.SetWinningPlayer(winningPlayer);
    }
}