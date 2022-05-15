using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFeatures : MonoBehaviour
{
    public int size = 0;
    public bool fragile = false;
    public bool branded = false;
    public bool special = false;
    public bool fastDelivery = false;

    public bool Fragile { get => fragile; set => fragile = value; }
    public bool Branded { get => branded; set => branded = value; }
    public bool Special { get => special; set => special = value; }
    public bool FastDelivery { get => fastDelivery; set => fastDelivery = value; }

    void Start()
    {
        size = Random.Range(0, 2);
        fragile = randomBool();
        branded = randomBool();
        special = randomBool();
        fastDelivery = randomBool();

        //Tamaño por determinar
      //  transform.localScale = new Vector3(size+1, size+1, size+1);
    }

    bool randomBool()
    {
        return (Random.Range(0, 1) == 1);
    }


}
