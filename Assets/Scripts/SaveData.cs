using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class SaveData
{
    [MenuItem("Tools/Write Line")]

    static void writeLine() {
        string path = @"F:\linco\GameDev2.0\Space Station\Assets\ResourcesSaveData.txt";

        StreamWriter writer = new StreamWriter(path, true);

        File.WriteAllText(path, "");

        writer.Write("1");
        writer.Write("2");
        writer.Close();

        string readText = File.ReadAllText(path);
        Console.WriteLine(readText);
    }
}
