using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
using System;
using System.Linq;
using System.Collections.Generic;

public class SaveData :MonoBehaviour {

    public float money;
    string path;
    string currentMoney;
    bool exists;

    Dictionary<string, float> dataDict = new Dictionary<string, float>();
    List<string> stringData = new List<string>();
    private void Awake() {
        path = @"F:\linco\GameDev2.0\Space Station\Assets\Resources\SaveData.txt";
    }

    private void Update() {
        money = dataValueFromDict("money");
        stringData = new List<string>(dataDict.Keys);
        Debug.Log(stringData);
    }
    public void writeLine() {
        StreamWriter writer = new StreamWriter(path, true);

        writer.WriteLine(money);
        writer.Close();

        StreamReader reader = new StreamReader(path);
        string currentMoney = File.ReadLines(path).Last();
        reader.Close();
        Debug.Log(currentMoney);

        money = int.Parse(currentMoney, System.Globalization.NumberStyles.Float);
    }

    /// <summary>
    /// Clears the data file's history, with the option of saving the last value
    /// </summary>
    /// <param name="keepCurrentValue"></param>
    public void clearDataHistory(bool keepCurrentValue) {
        StreamReader reader = new StreamReader(path);
        string currentMoney = File.ReadLines(path).Last();
        reader.Close();

        File.Delete(path);

        if (keepCurrentValue)
            File.WriteAllLines(path, currentMoney.Split('\n'));
    }

    public void addDataType(string name, float startingValue = 0f, bool addToDataDict = true) {
        if (searchDataHistory(name, false, true)) { Debug.LogError("Variable string already exists in data history!"); } else {
            if(addToDataDict)
                searchDataHistory(name, true, false);
            var formattedVar = name + " : " + startingValue;

            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(formattedVar);
            writer.Close();
        }
    }

    public void addData(string dataType, float Amt) {
        float dataValue = 0f;
        for(int i = File.ReadAllLines(path).Length + 1; i-- > 0;) {
            StreamReader reader = new StreamReader(path);
            var line = reader.ReadLine();
            reader.Close();
            string dataValueMatch = Regex.Match(line, @"([-+]?[0-9]*\.?[0-9]+)").Value;
            dataValue = float.Parse(dataValueMatch);

            string name = new String(line.Where(Char.IsLetter).ToArray());

            if(dataValue != 0f) {
                break;
            }
        }


        if (dataValue != 0) {
            StreamWriter writer = new StreamWriter(path, true);
            dataValue += Amt;
            writer.WriteLine(name + " : " + dataValue);
            writer.Close();
        }
    }
    public void removeData(string dataType, float Amt) {
        float dataValue = 0f;
        for (int i = File.ReadAllLines(path).Length + 1; i-- > 0;) {
            StreamReader reader = new StreamReader(path);
            var line = reader.ReadLine();
            reader.Close();
            string dataValueMatch = Regex.Match(line, @"([-+]?[0-9]*\.?[0-9]+)").Value;
            dataValue = float.Parse(dataValueMatch);

            string name = new String(line.Where(Char.IsLetter).ToArray());

            if (dataValue != 0f) {
                break;
            }
        }


        if (dataValue != 0) {
            StreamWriter writer = new StreamWriter(path, true);
            dataValue -= Amt;
            writer.WriteLine(name + " : " + dataValue);
            writer.Close();
        }
    }

    public float dataValueFromDict(string name) {
        if (searchDataDict(name)) {
            return dataDict[name];
        } else {
            Debug.LogError("Data variable ' "+name+" 'does not exist");
            return 0.0f;
        }
    }

    /// <summary>
    /// Searches the save file for the name given, adds to the dataDict if it exists
    /// </summary>
    /// <param name="DataName"></param>
    /// <param name="AddToDict"></param>
    private bool searchDataHistory(string dataName, bool addToDict, bool returnBool) {

        for (int i = File.ReadAllLines(path).Length + 1; i-- > 0;) {
            StreamReader reader = new StreamReader(path);
            var line = reader.ReadLine();
            reader.Close();
            string dataValueMatch = Regex.Match(line, @"([-+]?[0-9]*\.?[0-9]+)").Value;
            float dataValue = float.Parse(dataValueMatch);

            string name = new String(line.Where(Char.IsLetter).ToArray());
            if (name == dataName) {
                if (addToDict)
                    if (!dataDict.ContainsKey(dataName))
                        dataDict.Add(dataName, dataValue);
                        exists = true;
            } else {
                Debug.LogError("Data Name Not Found: " + dataName);
                return false;
            }
        }
        if (exists && returnBool)
            return true;
        else
            return false;
    }

    private bool searchDataDict(string name) {
        if (dataDict.ContainsKey(name)) {
            return true;
        } else
            return false;
    }
    
}
