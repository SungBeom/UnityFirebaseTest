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
    [HideInInspector]
    public string UDID;

    DatabaseReference reference;
    public DatabaseReference Reference
    {
        get { return reference; }
    }

    ArrayList data = new ArrayList();

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

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
                InitializeFirebase();
            else
                Debug.LogError(string.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
        });


        //// Set up the Editor before calling into the realtime database.
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://unitytest-a7eaa.firebaseio.com/");
        ////FirebaseApp.DefaultInstance.SetEditorP12FileName("unitytest-a7eaa-ddb4aaa27e34.p12");
        ////FirebaseApp.DefaultInstance.SetEditorServiceAccountEmail("unitytest-a7eaa@appspot.gserviceaccount.com");
        ////FirebaseApp.DefaultInstance.SetEditorP12Password("notasecret");

        //// Get the root reference location of the database.
        //reference = FirebaseDatabase.DefaultInstance.RootReference;

        //reference.Child(UDID).GetValueAsync().ContinueWith(initTask =>
        //{
        //    if (initTask.IsFaulted)
        //        Debug.Log("failed");
        //    else if (initTask.IsCompleted)
        //    {
        //        DataSnapshot snapshot = initTask.Result;

        //        Debug.Log(snapshot.Child("Food").Value);
        //        Debug.Log(snapshot.Child("Gold").Value);
        //        Debug.Log(snapshot.Child("Jewelry").Value);
        //    }
        //});

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

    void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        // NOTE: You'll need to replace this url with your Firebase App's database
        // path in order for the database connection to work correctly in editor.
        app.SetEditorDatabaseUrl("https://unitytest-a7eaa.firebaseio.com/");
        if (app.Options.DatabaseUrl != null)
            app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
        StartListener();
    }

    void StartListener()
    {
        //FirebaseDatabase.DefaultInstance.GetReference(UDID).
        //    ValueChanged += (object sender, ValueChangedEventArgs e) =>
        //    {
        //        if (e.DatabaseError != null)
        //        {
        //            Debug.LogError(e.DatabaseError.Message);
        //            return;
        //        }
        //        if (e.Snapshot != null && e.Snapshot.ChildrenCount > 0)
        //        {
        //            foreach (var childSnapshot in e.Snapshot.Children)
        //            {
        //                //if (childSnapshot.Child("Food") == null
        //                //|| childSnapshot.Child("Food").Value == null)
        //                //{
        //                //    Debug.LogError("Bad data in sample.  Did you forget to call SetEditorDatabaseUrl with your project id?");
        //                //    break;
        //                //}
        //                //else
        //                //{
        //                    Debug.Log("data : " +
        //                        childSnapshot.Child("Food").Value.ToString() + " - " +
        //                        childSnapshot.Child("Gold").Value.ToString() + " - " +
        //                        childSnapshot.Child("Jewelry").Value.ToString());
        //                    data.Insert(0, childSnapshot.Child("Food").Value.ToString()
        //                        + " " + childSnapshot.Child("Gold").Value.ToString()
        //                        + " " + childSnapshot.Child("Jewelry").Value.ToString());
        //                //}
        //            }
        //        }
        //    };
    }

    string food = "100";
    string gold = "200";
    string jewelry = "300";

    public void AddData()
    {
        if (string.IsNullOrEmpty(food) || string.IsNullOrEmpty(gold) || string.IsNullOrEmpty(jewelry))
        {
            Debug.Log("fail...");
            return;
        }

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference(UDID);

        reference.RunTransaction(AddDataTransaction).ContinueWith(task =>
        {
            if (task.Exception != null)
                Debug.Log(task.Exception.ToString());
            else if (task.IsCompleted)
                Debug.Log("Transaction complete.");
        });
    }

    TransactionResult AddDataTransaction(MutableData mutableData)
    {
        List<object> datas = mutableData.Value as List<object>;

        if (datas == null)
        {
            datas = new List<object>();
        }

        Dictionary<string, object> newData = new Dictionary<string, object>();
        newData["Food"] = food;
        newData["Gold"] = gold;
        newData["Jewelry"] = jewelry;
        datas.Add(newData);

        mutableData.Value = datas;
        return TransactionResult.Success(mutableData);
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
