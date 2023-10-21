using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TaskManager.Logic.Model;

namespace TaskManager.Logic.Util
{
    internal static class Serializer
    {
        public const string FILE_PATH = @"E:\projects\TaskManager\TaskManager\SerializedTaskGroups.txt";

        public static void serialize(Object obj)
        {
            string json = JsonSerializer.Serialize(obj);

            File.WriteAllText(FILE_PATH, json);
        }

        public static Object deserialize()
        {
            List<TaskGroup> obj;

            string json = File.ReadAllText(FILE_PATH);

            if (json != "") 
                obj = JsonSerializer.Deserialize<List<TaskGroup>>(json);
            else
                obj = new();

            return obj;
        }
    }
}
