using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }
    //public static GameManager Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            GameObject tempGM = new GameObject("GameManager");
    //            instance = tempGM.AddComponent<GameManager>();
    //            DontDestroyOnLoad(tempGM);
    //        }
    //        return instance;
    //    }
    //}
    public string UDID;

    DatabaseReference reference;
    public DatabaseReference Reference
    {
        get { return reference; }
    }

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        UDID = SystemInfo.deviceUniqueIdentifier;
        Debug.Log(UDID);

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp, i.e.
                //   app = Firebase.FirebaseApp.DefaultInstance;
                // where app is a Firebase.FirebaseApp property of your application class.

                // Set a flag here indicating that Firebase is ready to use by your
                // application.
            }
            else
            {
                Debug.LogError(string.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://unitytest-a7eaa.firebaseio.com/");

        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        reference.Child(UDID).GetValueAsync().ContinueWith(initTask =>
        {
            if (initTask.IsFaulted)
                Debug.Log("failed");
            else if (initTask.IsCompleted)
            {
                DataSnapshot snapshot = initTask.Result;

                Debug.Log(snapshot.Child("Food").Value);
                Debug.Log(snapshot.Child("Gold").Value);
                Debug.Log(snapshot.Child("Jewelry").Value);
            }
        });

        //if (reference != null)
        //{
        //    reference.Child(SystemInfo.deviceUniqueIdentifier).GetValueAsync().ContinueWith(task =>
        //    {
        //        if (task.IsFaulted)
        //            Debug.Log("failed");
        //        else if (task.IsCompleted)
        //        {
        //            DataSnapshot snapshot = task.Result;

        //            Debug.Log(snapshot.Child("Food").Value);
        //            Debug.Log(snapshot.Child("Gold").Value);
        //            Debug.Log(snapshot.Child("Jewelry").Value);
        //        }
        //    });
        //}
        //else
        //{
        //    Debug.Log("Failed...");
        //}
    }

    class GoodsCount
    {
        // 재화가 3개일 경우를 가정
        private ulong[] goodsCount;

        public GoodsCount() { goodsCount = new ulong[3]; }

        public ulong this[int index]
        {
            get { return goodsCount[index]; }
            set { goodsCount[index] = value; }
        }
    }
    GoodsCount goodsCount;
}
