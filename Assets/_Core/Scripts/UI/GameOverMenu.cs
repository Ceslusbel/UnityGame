using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void onRetryClick(){
        Debug.Log("Game Over - Retry Click");
        this.gameObject.SetActive(false);
        GameManager.Instancia.Retry();
    }
}
