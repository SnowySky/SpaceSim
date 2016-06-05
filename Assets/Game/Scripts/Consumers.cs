using UnityEngine;
using System.Collections;

public class Consumers : MonoBehaviour {

    public bool isEnabled = false;
    public bool isImportant = false;
    public byte Priority = 0;

    public int needEnergy;
    public int nowEnergy;

    public void SetActive()
    {
        nowEnergy = needEnergy;
        isEnabled = true;
    }

}
