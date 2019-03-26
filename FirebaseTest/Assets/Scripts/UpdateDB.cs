using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDB : MonoBehaviour
{
    public Text log;
    public Text foodText;
    public Text goldText;
    public Text jewelryText;

    int foodCount, goldAmount, jewelryCount;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    void Click()
    {
        int.TryParse(foodText.text, out foodCount);
        int.TryParse(goldText.text, out goldAmount);
        int.TryParse(jewelryText.text, out jewelryCount);

        //Dictionary<string, object> data = new Dictionary<string, object>();
        //data["Food"] = foodCount;
        //data["Gold"] = goldAmount;
        //data["Jewelry"] = jewelryCount;

        AddData();
        //GameManager.Instance.Reference.Child(GameManager.Instance.UDID).UpdateChildrenAsync(data);

        //log.text = data["Food"].ToString() + ", " + data["Gold"].ToString() + ", " + data["Jewelry"].ToString();
        //GameManager.Instance.Reference.Child(GameManager.Instance.UDID).GetValueAsync().ContinueWith(task =>
        //{
        //    if (task.IsFaulted)
        //    {
        //        log.text = "Failed...";
        //        Debug.Log("failed");
        //    }
        //    else if (task.IsCompleted)
        //    {
        //        DataSnapshot snapshot = task.Result;

        //        log.text = snapshot.Child("Food").Value.ToString() + "/" +
        //        snapshot.Child("Gold").Value.ToString() + "/" +
        //        snapshot.Child("Jewelry").Value.ToString();
        //        Debug.Log(snapshot.Child("Food").Value);
        //        Debug.Log(snapshot.Child("Gold").Value);
        //        Debug.Log(snapshot.Child("Jewelry").Value);
        //    }
        //});
    }

    public void AddData()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference(GameManager.Instance.UDID);

        reference.RunTransaction(AddDataTransaction).ContinueWith(task =>
        {
            if (task.Exception != null)
                Debug.Log(task.Exception.ToString());
            else if (task.IsCompleted)
                Debug.Log("Transaction complete.");
        });
    }

    public void AddData2()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference(GameManager.Instance.UDID);

        reference.RunTransaction(AddDataTransaction2).ContinueWith(task =>
        {
            if (task.Exception != null)
                Debug.Log(task.Exception.ToString());
            else if (task.IsCompleted)
                Debug.Log("Transaction complete.");
        });
    }

    TransactionResult AddDataTransaction(MutableData mutableData)
    {
        //List<object> datas = mutableData.Value as List<object>;
        //Dictionary<string, object> newData = new Dictionary<string, object>();
        //// List<object> datas = new List<object>();

        //if (datas == null)
        //    datas = new List<object>();
        ////else if (datas[0] is Dictionary<string, object>)
        ////    newData = (Dictionary<string, object>)datas[0];
        //else
        //    newData = (Dictionary<string, object>)datas[0];

        ////foreach (var data in newData)
        ////    Debug.Log(data);

        //// Dictionary<string, object> newData = new Dictionary<string, object>();
        //newData["Food"] = foodCount;
        //newData["Gold"] = goldAmount;
        //newData["Jewelry"] = jewelryCount;
        //// datas.Clear();
        //datas.Add(newData);

        //mutableData.Value = datas;
        //return TransactionResult.Success(mutableData);

        Dictionary<string, object> datas = mutableData.Value as Dictionary<string, object>;
        if (datas == null) datas = new Dictionary<string, object>();

        datas["Food"] = foodCount;
        datas["Gold"] = goldAmount;
        datas["Jewelry"] = jewelryCount;

        mutableData.Value = datas;
        return TransactionResult.Success(mutableData);
    }

    TransactionResult AddDataTransaction2(MutableData mutableData)
    {
        ////List<object> datas = mutableData.Value as List<object>;
        //List<object> datas = new List<object>();

        ////if (datas == null)
        ////    datas = new List<object>();

        //Dictionary<string, object> newData = new Dictionary<string, object>();
        //newData["Test"] = "test";
        //datas.Add(newData);

        //mutableData.Value = newData;
        //return TransactionResult.Success(mutableData);

        //List<object> datas = mutableData.Value as List<object>;
        //Dictionary<string, object> newData = new Dictionary<string, object>();
        //// List<object> datas = new List<object>();

        //if (datas == null)
        //    datas = new List<object>();
        //else if (datas[0] is Dictionary<string, object>)
        //    newData = (Dictionary<string, object>)datas[0];

        //// Dictionary<string, object> newData = new Dictionary<string, object>();
        //newData["Test"] = "test";
        //datas.Clear();
        //datas.Add(newData);

        //mutableData.Value = newData;
        //return TransactionResult.Success(mutableData);

        //List<object> datas = mutableData.Value as List<object>;
        //Dictionary<string, object> newData = new Dictionary<string, object>();
        //// List<object> datas = new List<object>();

        //if (datas == null)
        //    datas = new List<object>();
        ////else if (datas[0] is Dictionary<string, object>)
        ////    newData = (Dictionary<string, object>)datas[0];
        //else
        //{
        //    Debug.Log(datas);
        //    newData = datas[0] as Dictionary<string, object>;
        //}

        ////foreach (var data in newData)
        ////    Debug.Log(data);

        //// Dictionary<string, object> newData = new Dictionary<string, object>();
        //newData["Test"] = "test";
        //// datas.Clear();
        //datas.Add(newData);

        //mutableData.Value = datas;
        //return TransactionResult.Success(mutableData);

        Dictionary<string, object> datas = mutableData.Value as Dictionary<string, object>;
        if (datas == null) datas = new Dictionary<string, object>();

        datas["Gold"] = "good";
        datas["Test"] = "test";

        mutableData.Value = datas;
        return TransactionResult.Success(mutableData);
    }
}
