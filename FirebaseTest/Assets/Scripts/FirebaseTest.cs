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

    void Awake()
    {
        //Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
        //    var dependencyStatus = task.Result;
        //    if (dependencyStatus == Firebase.DependencyStatus.Available)
        //    {
        //        // Create and hold a reference to your FirebaseApp, i.e.
        //        //   app = Firebase.FirebaseApp.DefaultInstance;
        //        // where app is a Firebase.FirebaseApp property of your application class.

        //        // Set a flag here indicating that Firebase is ready to use by your
        //        // application.
        //    }
        //    else
        //    {
        //        UnityEngine.Debug.LogError(System.String.Format(
        //          "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
        //        // Firebase Unity SDK is not safe to use here.
        //    }
        //});
    }

    void Start()
    {
        //// Set up the Editor before calling into the realtime database.
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://unitytest-a7eaa.firebaseio.com/");

        //// Get the root reference location of the database.
        //DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        //// 이는 앱 고유한 값을 가지게 됨, 이를 이용한 아이디와 비밀번호를 저장
        //Debug.Log(SystemInfo.deviceUniqueIdentifier);
        //// reference.Child("USER").Child(SystemInfo.deviceUniqueIdentifier).SetRawJsonValueAsync(json);

        //user = new User("PSB", "123");
        //json = JsonUtility.ToJson(user);
        //reference.Child("USER").Child("SB").SetRawJsonValueAsync(json);

        //nextUser = new Dictionary<string, object>();
        //nextUser["ID"] = "CGH";
        //nextUser["password"] = "456";
        //reference.Child("USER").Child("GH").UpdateChildrenAsync(nextUser);

        //nextUser = new Dictionary<string, object>();
        //nextUser["ID"] = "KHS";
        //nextUser["password"] = "789";
        //reference.Child("USER").Child("HS").UpdateChildrenAsync(nextUser);

        //user = new User("Test", "t1");
        //json = JsonUtility.ToJson(user);
        //reference.Child(SystemInfo.deviceUniqueIdentifier).SetRawJsonValueAsync(json);

        //reference.Child("USER").GetValueAsync().ContinueWith(task => {
        //    if (task.IsFaulted)
        //        Debug.Log("failed");
        //    else if (task.IsCompleted)
        //    {
        //        DataSnapshot snapshot = task.Result;
        //        Debug.Log(snapshot.Child("SB").Child("ID").Value);
        //    }
        //});

        //reference.Child(SystemInfo.deviceUniqueIdentifier).GetValueAsync().ContinueWith(task => {
        //    if (task.IsFaulted)
        //        Debug.Log("failed");
        //    else if (task.IsCompleted)
        //    {
        //        DataSnapshot snapshot = task.Result;
        //        Debug.Log(snapshot.Child("ID").Value);
        //        Debug.Log(snapshot.Child("password").Value);
        //    }
        //});
    }
}
