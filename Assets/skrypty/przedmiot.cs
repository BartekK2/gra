using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class przedmiot : MonoBehaviour
{
    // skrypt na przedmiot ktory sie uzywa ale nie podnosi
    public GameObject player;
    public InputField textInput;
    public string haslo = "Witecka";
    public Text text;
    Canvas laptopCanvas;
    private string input;

    public float maxDistance = 5f;

    public void sprawdzhaslo()
    {
        text.text = textInput.text == haslo ? "Zgadles" : "Noob";
    }
    void Awake()
    {
        laptopCanvas = GameObject.Find("Laptop Canvas").GetComponent<Canvas>();
        laptopCanvas.enabled = false;
    }
    void Update()
    {
        if (isClose() && Input.GetKeyDown(KeyCode.X))
        {
            laptopCanvas.enabled = !laptopCanvas.enabled;
            Time.timeScale = laptopCanvas.enabled ? 0 : 1;
        }
        var x = GameObject.Find("laptop interakcja");

        if (isClose())
        {
            x.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            x.GetComponent<MeshRenderer>().enabled = false;

        }
    }
    bool isClose()
    {
        return Vector3.Distance(transform.position, player.transform.position) < maxDistance;
    }
}
