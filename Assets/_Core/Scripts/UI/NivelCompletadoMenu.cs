using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class NivelCompletadoMenu : MonoBehaviour
{
    public Button okButton;
    public List<UI_Estrella> estrellas;
    void OnEnable() 
    {
        ResetMenu();

        int estrellas = GameManager.Instancia.nivelActual.CalcularEstrellas();

        PrenderEstrellas(estrellas);
        DataManager.Instancia.GuardarEstrellas("Nivel_" + LevelManager.Instancia.nivelActual, estrellas);
    }

    public void PrenderEstrellas(int _cuantas)
    {
        estrellasPorPrender = _cuantas;
        InvokeRepeating("PrenderEstrellaDelay",0,1);
    }

    int iterador = 0;
    int estrellasPorPrender = 0;

    private void PrenderEstrellaDelay()
    {
        estrellas[iterador].PrenderEstrella();
        iterador++;

        if(iterador >= estrellasPorPrender)
        {
            CancelInvoke("PrenderEstrellaDelay");
            okButton.interactable = true;
        }
    }

    public void OnOkClick()
    {
        gameObject.SetActive(false);
        LevelManager.Instancia.SiguienteNivel();
    }
    public void ResetMenu()
    {
        iterador = 0;
        estrellasPorPrender = 0;

        foreach(var estrella in estrellas)
        {
            estrella.ApagarEstrella();
        }
    }
}
