using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Utilities : MonoBehaviour
{
    public enum tileType
    {
        delimitador = 0, calleVertical, calleHorizontal, inteserccion, Tleft, Tdown, Tright, Tup, residencia, cesped, reloj, homeSpawner, dogSpawner, guardSpawner, unknow
    }

    public enum OPRESULT
    {
        fileNotFound = 0, ok
    }


    static public tileType GiveTileType(string textNumber)
    {

        switch (textNumber)
        {
            case "0":
                {
                    return tileType.delimitador;
                }
            case "1":
                {
                    return tileType.calleVertical;
                }
            case "2":
                {
                    return tileType.calleHorizontal;
                }
            case "T":
                {
                    return tileType.inteserccion;
                }
            case "3":
                {
                    return tileType.Tleft;
                }
            case "4":
                {
                    return tileType.Tdown;
                }
            case "5":
                {
                    return tileType.Tright;
                }
            case "6":
                {
                    return tileType.Tup;

                }
            case "7":
                {
                    return tileType.residencia;
                }
            case "8":
                {
                    return tileType.cesped;
                }
            case "9":
                {
                    return tileType.reloj;
                }
            case "10":
                {
                    return tileType.homeSpawner;
                }
            case "11":
                {
                    return tileType.dogSpawner;
                }
            case "12":
                {
                    return tileType.guardSpawner;
                }
            default:
                return tileType.unknow;
        }
    }
}
