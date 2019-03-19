using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string ID;
    public string password;

    public User() { }

    public User(string ID, string password)
    {
        this.ID = ID;
        this.password = password;
    }
}

public class FirebaseTest : MonoBehaviour
{
    User user;
    Dictionary<string, object> nextUser = new Dictionary<string, object>();
    string json;

    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://unitytest-a7eaa.firebaseio.com/");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        user = new User("PSB", "123");
        json = JsonUtility.ToJson(user);
        reference.Child("USER").Child("SB").SetRawJsonValueAsync(json);

        nextUser = new Dictionary<string, object>();
        nextUser["ID"] = "CGH";
        nextUser["password"] = "456";
        reference.Child("USER").Child("GH").UpdateChildrenAsync(nextUser);

        nextUser = new Dictionary<string, object>();
        nextUser["ID"] = "KHS";
        nextUser["password"] = "789";
        reference.Child("USER").Child("HS").UpdateChildrenAsync(nextUser);
    }
}
