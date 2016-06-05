using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
    public int Energy;
    private int forAllEnergy;

    public System.Collections.Generic.List<GameObject> Consumers = new System.Collections.Generic.List<GameObject>();

    void Update()
    {
        
        if (checkEnergyForAll())
        {
            foreach (GameObject consumer in Consumers) {
                consumer.GetComponent<Consumers>().SetActive();
            }
        }
        else
        {
            if (checkEnergyForImportant())
            {
                foreach (GameObject consumer in Consumers)
                {
                    Consumers selectedConsumer = consumer.GetComponent<Consumers>();
                    if (selectedConsumer.isImportant)
                    {
                        selectedConsumer.SetActive();
                    }
                }
            }
        }
    }
    private bool checkEnergyForAll()
    {
        foreach (GameObject consumer in Consumers)
        {
            forAllEnergy += consumer.GetComponent<Consumers>().needEnergy;
        }
        bool returnedValue = (forAllEnergy <= Energy) ? true : false;
        forAllEnergy = 0;
        return returnedValue;
    }
    private bool checkEnergyForImportant()
    {
        foreach (GameObject consumer in Consumers)
        {
            Consumers selectedConsumer = consumer.GetComponent<Consumers>();
            if (selectedConsumer.isImportant)
            {
                forAllEnergy += selectedConsumer.needEnergy;
            }
        }
        bool returnedValue = (forAllEnergy <= Energy) ? true : false;
        forAllEnergy = 0;
        return returnedValue;
    }
    void SortForPriority()
    {
    }
}
