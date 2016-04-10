using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Assertions;

public class GameOverHandler : MonoBehaviour
{
    public GameplayManager gameplayManager;

    public GameOverScreen gameOverScreen;

    public GameRestartController gameRestartController;

    public AudioSource[] audioSourcesToDeactivate;

    private void Awake()
    {
        Assert.IsNotNull(gameOverScreen);
        Assert.IsNotNull(gameplayManager);
        Assert.IsNotNull(gameRestartController);
        gameRestartController.enabled = false;
        gameplayManager.PlayerWins += OnPlayerWins;
    }

    private void OnPlayerWins(Player winningPlayer)
    {
        IEnumerable<MonoBehaviour> controllers = GameObject.FindObjectsOfType<Controlls>();
        IEnumerable<MonoBehaviour> deathTriggers = GameObject.FindObjectsOfType<DeathTrigger>();

        var componentsToDisable = controllers.Concat(deathTriggers);
        foreach (var component in componentsToDisable)
        {
            component.enabled = false;
        }

        foreach (var audioSource in audioSourcesToDeactivate)
        {
            audioSource.enabled = false;
        }

        gameOverScreen.SetWinningPlayer(winningPlayer);
        gameRestartController.enabled = true;
    }
}