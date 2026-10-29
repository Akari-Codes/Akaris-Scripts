//C# Script Cachy by Akari-Codes; https://github.com/Akari-Codes/CSharp-Testing-Ground/tree/main/Working%20Custom%20Modules/cachy.cs, https://github.com/Akari-Codes/Akaris-Scripts/scripts/bin/cachy.cs
//Akari-Codes = Thomas Christopher Drury
//152787d8bbcc0ababcce6c0643632c4ac853cd5615fbb92c4a1647a88b43a227
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Collections.Generic;
using System.Collections;

internal partial class cachy
{
    public static string[] Archive_fetch()
    {
        string wd = System.IO.Directory.GetCurrentDirectory();
        if (!Directory.Exists(wd + "/cache"))
        {
            Directory.CreateDirectory(wd + "/cli");
        }
        if (File.Exists(wd + "/cache/cachy.tmp"))
        {
            string[] dataArchive = File.ReadAllLines(wd + "/cache/cachy.tmp");
            return dataArchive;
        }
        else
        {
            string[] dataArchive = [];
            return dataArchive;
        }
        
    }
       public static void Archive_dump(string[] dataArchive) 
{string wd = System.IO.Directory.GetCurrentDirectory();
    if (File.Exists(wd + "/cache/cachy.tmp"))
        {
            File.WriteAllLines(wd + "/cache/cachy.tmp", dataArchive);
        }
        else
        {
            File.Create(wd + "/cache/cachy.tmp").Close();
            File.WriteAllLines(wd + "/cache/cachy.tmp", dataArchive);
        }
    }
    public static void set(string name, dynamic data, string type = "[Unknown]")
    {
        string[] dataArchive = Archive_fetch();
        int index = 0;
        string[] newDataArchive = new string[dataArchive.Length + 1];
        if (type == "[Unknown]") {
        type = varConverter.get_type_short(data);}
        string x = name + "[*&*]" + varConverter.convert_to_string(data) + "[*&*]" + type;
        int count = 0;
        foreach (string y in dataArchive) {
            newDataArchive[count] = y;
            count++;
        }
        bool exists = false;
        foreach (string ad in dataArchive)
        {
            string[] y = ad.Split("[*&*]");
            if (name == y[0].ToString()) {
                exists = true;
                break;}
            index++;
        }
        if(exists == true) {newDataArchive[index] = x;}
        else {newDataArchive[dataArchive.Length] = x;}
        dataArchive = newDataArchive;
        Archive_dump(dataArchive);
        return;
    }

    public static dynamic get(string name, string type = "[Unknown]")
    {
        string[] dataArchive = Archive_fetch();
        dynamic data = "";
        foreach (string x in dataArchive)
        {
            string[] y = x.Split("[*&*]");
            if (name == y[0].ToString()) {
                data = y[1];
                if (type == "[Unknown]") {
                type = y[2];}
                break;}
            }
        if(data != "") {
        data = varConverter.convert(type,data);}
        if(data == "")
        {
            data = "Error Item Does Not Exist";
        }
        return data;
    }

    public static void edit(string name, dynamic data, string type = "[Unknown]")
    {string[] dataArchive = Archive_fetch();
    if (type == "[Unknown]") {
        type = varConverter.get_type_short(data);}
        foreach (string x in dataArchive)
        {
            string[] y = x.Split("[*&*]");
            int count = 0;
            if (y[0] == name)
            {
                dataArchive[count] = y[0] + "[*&*]" + varConverter.convert_to_string(data) + "[*&*]" + type;
                break;
            }
            count++;
        };
        Archive_dump(dataArchive);
        return;
    }
    public static void clear()
    {
        string wd = System.IO.Directory.GetCurrentDirectory();
        File.Delete(wd + "/cache/cachy.tmp");
        return;
    }

    public static void delete(string name)
    {
        string[] dataArchive = Archive_fetch();
        int count = 0;
        string[] newDataArchive = new string[dataArchive.Length-2];
        foreach (string x in dataArchive)
        {
            string[] y = x.Split("[*&*]");
            if (y[0] != name)
            {
                newDataArchive[count] = x;
            }
            count++;
        };
        dataArchive = newDataArchive;
        Archive_dump(dataArchive);
        return;
    }
}
//C# Script Cachy by Akari-Codes; https://github.com/Akari-Codes/CSharp-Testing-Ground/tree/main/Working%20Custom%20Modules/cachy.cs, https://github.com/Akari-Codes/Akaris-Scripts/scripts/bin/cachy.cs
//Akari-Codes = Thomas Christopher Drury
//152787d8bbcc0ababcce6c0643632c4ac853cd5615fbb92c4a1647a88b43a227