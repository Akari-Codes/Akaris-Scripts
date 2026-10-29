//C# Script Cachy by Akari-Codes; https://github.com/Akari-Codes/CSharp-Testing-Ground/tree/main/Working%20Custom%20Modules/interfaces.cs, https://github.com/Akari-Codes/Akaris-Scripts/scripts/bin/interfaces.cs, https://akari-codes.github.io/Akaris-Scripts/
//Akari-Codes = Thomas Christopher Drury
//beb9ddf33b713356bdadf269028c0c6f1bc1f5d384dbbcef71811ed262761c43
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
internal partial class tui
{
    public static void cls()
    {
        Console.Clear();
        return;
    }
    public static string[] get() {
    string[] tui = ui_db.fetch();
    return tui;
    }
    public static string interfaces(string name)
{
    string[] uiArchive = get();
    int c = 0;
    string ui = "Error No Ui Found Called '" + name + "'";
    foreach (string x in uiArchive)
    {
        if (x == name)
        {
            ui = uiArchive[c+1];
            break;
        }
        c++;
    }
    return ui;
}
public static int interMem(string name)
{
    string[] memArchive = get();
    int c = 0;
    int mem = -1;
    foreach (string x in memArchive)
    {
        if (x == name)
        {
            mem = varConverter.convert_to_int(memArchive[c+2]);
            break;
        }
        c++;
    }
    return mem;
}
public static string keyListen()
    {
        return varConverter.convert_to_string(Console.ReadKey().Key);
    }
public static dynamic[] Menu(int mem, int cMem = 1, params string[] vars)
    {
        string dep = "null";
        dynamic[] dataOutput = new dynamic[2];
        while (dep == "null")
        {
            dataOutput = interMenu(mem,cMem,vars);
            dep = dataOutput[0];
            cMem = dataOutput[1];
        }
        return dataOutput;
    }
public static dynamic[] cMenu(int mem, string[] accepted_options, int cMem = 1, params string[] vars)
    {
        string dep = "null";
        dynamic[] dataOutput = new dynamic[2];
        while (accepted(accepted_options, dep) == false)
        {
            dataOutput = interMenu(mem,cMem,vars);
            dep = dataOutput[0];
            cMem = dataOutput[1];
        }
        if(dep == "null")
        {
            dataOutput[0] = dataOutput[2];
        }
        static bool accepted(string[] accepted_options, string dep)
        {
            bool output = false;
            foreach(string x in accepted_options)
            {
                if(dep == x)
                {
                    output = true;
                    break;
                }
            }
            return output;
        }
        return dataOutput;
    }
public static dynamic[] interMenu(int mem, int cMem, string[] vars)
    {
        string key = keyListen();
        if(key == "Enter")
        {
            return ["clicked",cMem];
        }
        else if(key == "Spacebar")
        {
            return ["selected",cMem];
        }
        else if(key == "Backspace")
        {
            return ["back",cMem];
        }
        else if(key == "Escape")
        {
            System.Environment.Exit(1);
        }
        else {
        if (key == "UpArrow")
        {
            if(cMem == 1)
            {
                cMem = mem;
                Reload(cMem,vars);
                return ["null",cMem];
            }else
            {
                cMem--;
                Reload(cMem,vars);
                return ["null",cMem];
            }
        }
            else if(key == "DownArrow")
            {
                if(cMem == mem)
            {
                cMem = 1;
                Reload(cMem, vars);
                return ["null",cMem];
            } else
            {
                cMem++;
                Reload(cMem, vars);
                return ["null",cMem];
            }
        }}
        return ["null",cMem,key];
    }
public static int load(string name, int cMem = 1,params string[] vars)
    {   string interf = interfaces(name);
        string[] lines = interf.Split(Environment.NewLine);
        int mem = 0;
        int count = 0;
        int varsCount = 1;
        foreach (string x in lines)
        {
            if (x.Contains("var(" + varConverter.convert_to_string(varsCount) + ")") && vars != null)
            {
                StringBuilder builder = new StringBuilder(x);
            builder.Replace("var(" + varConverter.convert_to_string(varsCount) + ")", vars[varsCount - 1]);
                lines[count] = builder.ToString();
                varsCount++;
            }
            if (x.Contains("menuItem()"))
            {
                mem++;
                if(mem == cMem)
                {
                    string line = lines[count];
                    lines[count] = "* " + line + " *";
                }
            }
            count++;
        };
        string ui = string.Join(Environment.NewLine,lines);
        ui = ui.Replace("menuItem()","");
        Console.WriteLine(ui);
        cachy.set("currentTui",name,"String");
        return mem;
    }
public static void Reload(int cMem, string[] vars)
    {
        cls();
        string interf = interfaces(cachy.get("currentTui","String"));
        string[] lines = interf.Split(Environment.NewLine);
        int count = 0;
        int mem = 0;
        int varsCount = 1;
        foreach (string x in lines)
        {
             if (x.Contains("var(" + varConverter.convert_to_string(varsCount) + ")"))
            {   
            StringBuilder builder = new StringBuilder(x);
            builder.Replace("var(" + varConverter.convert_to_string(varsCount) + ")", vars[varsCount - 1]);
                lines[count] = builder.ToString();
                varsCount++;
            }
            if (x.Contains("menuItem()"))
            {
                mem++;
                if(mem == cMem)
                {
                    string line = lines[count];
                    lines[count] = "* " + line + " *";
                }
            }
            count++;
            };
            string ui = string.Join(Environment.NewLine,lines);
            ui = ui.Replace("menuItem()","");
            Console.WriteLine(ui);
            return;
        }
public static void set_color(int color)
    {
        cachy.set("uiColor",color,"Int");
        return;
    }
}
//C# Script Cachy by Akari-Codes; https://github.com/Akari-Codes/CSharp-Testing-Ground/tree/main/Working%20Custom%20Modules/interfaces.cs, https://github.com/Akari-Codes/Akaris-Scripts/scripts/bin/interfaces.cs, https://akari-codes.github.io/Akaris-Scripts/
//Akari-Codes = Thomas Christopher Drury
//beb9ddf33b713356bdadf269028c0c6f1bc1f5d384dbbcef71811ed262761c43
