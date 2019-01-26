using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Utilities : MonoBehaviour
{
    public enum tileType
    {
        delimitador = 0, calleVertical, calleHorizontal, inteserccion, Tleft, Tdown, Tright, Tup, residencia, cesped, reloj, homeSpawner, dogSpawner, guardSpawner, calleUpRight, calleUpLeft, calleDownLeft, calleDownRight, unknow
    }

    public enum OPRESULT
    {
        fileNotFound = 0, ok
    }

    static public int setType(tileType type)
    {
        return (int)type;
    }

    static public tileType GiveTileType(string textNumber)
    {

        switch (textNumber)
        {
            case "0": case "0\r":
                {
                    return tileType.delimitador;
                }
            case "1": case "1\r":
                {
                    return tileType.calleVertical;
                }
            case "2": case "2\r":
                {
                    return tileType.calleHorizontal;
                }
            case "T":
            case "T\r":
                {
                    return tileType.inteserccion;
                }
            case "3":
            case "3\r":
                {
                    return tileType.Tleft;
                }
            case "4":
            case "4\r":
                {
                    return tileType.Tdown;
                }
            case "5":
            case "5\r":
                {
                    return tileType.Tright;
                }
            case "6":
            case "6\r":
                {
                    return tileType.Tup;

                }
            case "C":
            case "C\r":
                {
                    return tileType.residencia;
                }
            case "8":
            case "8\r":
                {
                    return tileType.cesped;
                }
            case "9":
            case "9\r":
                {
                    return tileType.reloj;
                }
            case "10":
            case "10\r":
                {
                    return tileType.homeSpawner;
                }
            case "11":
            case "11\r":
                {
                    return tileType.dogSpawner;
                }
            case "12":
            case "12\r":
                {
                    return tileType.calleUpLeft;
                }
            case "13":
            case "13\r":
                {
                    return tileType.calleUpRight;
                }
            case "14":
            case "14\r":
                {
                    return tileType.calleDownLeft;
                }
            case "15":
            case "15\r":
                {
                    return tileType.calleDownRight;
                }
            case "16":
            case "16\r":
                {
                    return tileType.calleUpLeft;
                }
            default:
                return tileType.unknow;
        }
    }
}
