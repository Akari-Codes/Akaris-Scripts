//C# Script Cachy by Akari-Codes; https://github.com/Akari-Codes/CSharp-Testing-Ground/tree/main/Working%20Custom%20Modules/varConverter.cs, https://github.com/Akari-Codes/Akaris-Scripts/scripts/bin/varConverter.cs
//Akari-Codes = Thomas Christopher Drury
//fcfe1d3b59ad007ebd683e8d847ee74e4b8e5be82280477df07b55255741df1c
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
internal partial class varConverter
{   public static dynamic convert(string type, dynamic data) {
        if (type.Contains("System.") == true) {type = type.Replace("System.","");}
        if (type == "String") {string newData = convert_to_string(data);
        return newData;
}
        if (type == "Boolean" || type == "Bool") {bool newData = convert_to_bool(data);
        return newData;
}
        else if (type == "Byte") {byte newData = convert_to_byte(data);
        return newData;
}
        else if (type == "SByte") {sbyte newData = convert_to_sbyte(data);
        return newData;
}
        else if (type == "Char") {char newData = convert_to_char(data);
        return newData;
}
        else if (type == "Decimal") {decimal newData = convert_to_decimal(data);
        return newData;
}
        else if (type == "Double") {double newData = convert_to_double(data);
        return newData;
}
        else if (type == "Single" || type == "Float") {float newData = convert_to_float(data);
        return newData;
}
        else if (type == "Int32" || type == "Int") {int newData = convert_to_int(data);
        return newData;
}
        else if (type == "UInt32" || type == "UInt") {uint newData = convert_to_uint(data);
        return newData;
}
        else if (type == "Int64" || type == "Long") {long newData = convert_to_long(data);
        return newData;
}
        else if (type == "UInt64" || type == "ULong") {ulong newData = convert_to_ulong(data);
        return newData;
}
        else if (type == "Int16" || type == "Short") {short newData = convert_to_short(data);
        return newData;
}
        else if (type == "UInt16" || type == "UShort") {ushort newData = convert_to_ushort(data);
        return newData;
}
        else if (type == "listDynamic") {dynamic[] newData = convert_to_dynamicList(data);
        return newData;
}
        else if (type == "listString") {dynamic[] newData = convert_to_stringList(data);
        return newData;
}
        else if (type == "listInt") {dynamic[] newData = convert_to_intList(data);
        return newData;
}
        else if (type == "listUInt") {dynamic[] newData = convert_to_uintList(data);
        return newData;}
        return "";
}
    public static dynamic[] convert_to_dynamicList(dynamic data) {
        string dataa = varConverter.convert_to_string(data);
        string[] z = dataa.Split(" {(#[,]#)} ");
        dynamic[] newData = new dynamic[z.Length];
        int c = 0;
        foreach (string x in z)
        {
            newData[c] = x;
            c++;
        }
        return newData;
        }
    public static string[] convert_to_stringList(dynamic data) {
        varConverter.convert_to_string(data);
        string[] newData = data.Split(" {(#[,]#)} ");
        return newData;
        }
    public static int[] convert_to_intList(dynamic data) {
        string dataa = varConverter.convert_to_string(data);
        string[] z = dataa.Split(" {(#[,]#)} ");
        int[] newData = new int[z.Length];
        int c = 0;
        foreach (string x in z)
        {
            newData[c] = varConverter.convert_to_int(x);
            c++;
        }
        return newData;
        }
    public static uint[] convert_to_uintList(dynamic data) {
        string dataa = varConverter.convert_to_string(data);
        string[] z = dataa.Split(" {(#[,]#)} ");
        uint[] newData = new uint[z.Length];
        int c = 0;
        foreach (string x in z)
        {
            newData[c] = varConverter.convert_to_uint(x);
            c++;
        }
        return newData;
        }
    public static string get_type_short(dynamic data)
    {
        string type = data.GetType().Name.ToString();
        return type;
    }
    public static string get_type_long(dynamic data)
    {
        string type = data.GetType().ToString();
        return type;
    }
    public static bool convert_to_bool(dynamic data)
    {
        if (data.GetType().ToString() == "System.Boolean")
        {
            bool newData = data;
            return newData;
        }
        else
        {
            bool newData = Convert.ToBoolean(data);
            return newData;
        };
        
    }
                                                                                          
    public static string convert_to_string(dynamic data)
    {
        if (data is Array)
        {
            string[] newData = new string[data.Length];
            int c = 0;
            foreach(dynamic x in data)
            {
                newData[c] = convert_to_string(x);
                c++;
            }
            string anewData = string.Join(" {(#[,]#)} ", newData);
            return anewData;
        }
        else if (data.GetType().ToString() == "System.String")
        {
            string newData = data;
            return newData;
        }
        else
        {
            string newData = Convert.ToString(data);
            return newData;
        };
        
    }

    public static byte convert_to_byte(dynamic data)
    {
        if (data.GetType().ToString() == "System.Byte")
        {
            byte newData = data;
            return newData;
        }
        else
        {
            byte newData = Convert.ToByte(data);
            return newData;
        };
    }

    public static sbyte convert_to_sbyte(dynamic data)
    {
        if (data.GetType().ToString() == "System.SByte")
        {
            sbyte newData = data;
            return newData;
        }
        else
        {
            sbyte newData = Convert.ToSByte(data);
            return newData;
        };
    }

    public static char convert_to_char(dynamic data)
    {
        if (data.GetType().ToString() == "System.Char")
        {
            char newData = data;
            return newData;
        }
        else
        {
            char newData = Convert.ToChar(data);
            return newData;
        };
    }

    public static decimal convert_to_decimal(dynamic data)
    {
        if (data.GetType().ToString() == "System.Decimal")
        {
            decimal newData = data;
            return newData;
        }
        else
        {
            decimal newData = Convert.ToDecimal(data);
            return newData;
        };
    }

    public static double convert_to_double(dynamic data)
    {
        if (data.GetType().ToString() == "System.Double")
        {
            double newData = data;
            return newData;
        }
        else
        {
            double newData = Convert.ToDouble(data);
            return newData;
        };
    }

    public static float convert_to_float(dynamic data)
    {
        if (data.GetType().ToString() == "System.Single")
        {
            float newData = data;
            return newData;
        }
        else
        {
            float newData = Convert.ToSingle(data);
            return newData;
        };
    }

    public static int convert_to_int(dynamic data)
    {
        if (data is Array)
        {
            int[] newData = new int[data.Length.Length];
            int c = 0;
            foreach(dynamic x in data)
            {
                newData[c] = convert_to_int(x);
            }
            string anewData = string.Join(" {(#[,]#)} ", newData);
            return convert_to_int(anewData);
        }
        else if (data.GetType().ToString() == "System.Int32")
        {
            int newData = data;
            return newData;
        }
        else
        {
            int newData = Convert.ToInt32(data);
            return newData;
        };
    }

    public static uint convert_to_uint(dynamic data)
    {
        if (data is Array)
        {
            uint[] newData = new uint[data.Length];
            int c = 0;
            foreach(dynamic x in data)
            {
                newData[c] = convert_to_uint(x);
            }
            string anewData = string.Join(" {(#[,]#)} ", newData);
            return convert_to_uint(anewData);
        }
        else if (data.GetType().ToString() == "System.UInt32")
        {
            uint newData = data;
            return newData;
        }
        else
        {
            uint newData = Convert.ToUInt32(data);
            return newData;
        };
    }

    public static long convert_to_long(dynamic data)
    {
        if (data.GetType().ToString() == "System.Int64")
        {
            long newData = data;
            return newData;
        }
        else
        {
            long newData = Convert.ToInt64(data);
            return newData;
        };
    }

    public static ulong convert_to_ulong(dynamic data)
    {
        if (data.GetType().ToString() == "System.UInt64")
        {
            ulong newData = data;
            return newData;
        }
        else
        {
            ulong newData = Convert.ToUInt64(data);
            return newData;
        };
    }

    public static short convert_to_short(dynamic data)
    {
        if (data.GetType().ToString() == "System.Int16")
        {
            short newData = data;
            return newData;
        }
        else
        {
            short newData = Convert.ToInt16(data);
            return newData;
        };
    }
    public static ushort convert_to_ushort(dynamic data)
    {
        if (data.GetType().ToString() == "System.UInt16")
        {
            ushort newData = data;
            return newData;
        }
        else
        {
            ushort newData = Convert.ToUInt16(data);
            return newData;
        };
    }
}
//C# Script Cachy by Akari-Codes; https://github.com/Akari-Codes/CSharp-Testing-Ground/tree/main/Working%20Custom%20Modules/varConverter.cs, https://github.com/Akari-Codes/Akaris-Scripts/scripts/bin/varConverter.cs
//Akari-Codes = Thomas Christopher Drury
//fcfe1d3b59ad007ebd683e8d847ee74e4b8e5be82280477df07b55255741df1c