using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    
    public static void SaveUser(string name, int highScore, int achievements)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + name + ".ast";
        FileStream stream = new FileStream(path, FileMode.Create);

        UserData data = new UserData(name, highScore, achievements);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static UserData LoadUser(string name)
    {
        string path = Application.persistentDataPath + "/" + name + ".ast";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UserData data =  formatter.Deserialize(stream) as UserData;
            stream.Close();

            return data;
        } else {
            Debug.Log("User file not found in " + path);
            return null;
        }
    }

}
