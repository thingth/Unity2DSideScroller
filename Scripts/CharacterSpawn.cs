using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    public GameObject[] Characters;
    //private int selected = PlayerPrefs.GetInt("SelectedChar");

	void Start ()
    {
        Instantiate(Characters[CharacterSelect.Char], Vector2.zero, Quaternion.identity); //standard preference location
    }
}
