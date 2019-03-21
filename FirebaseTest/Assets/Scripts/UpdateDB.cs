using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDB : MonoBehaviour
{
    public Text foodText;
    public Text goldText;
    public Text jewelryText;

    int foodCount, goldAmount, jewelryCount;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    void Click()
    {
        int.TryParse(foodText.text, out foodCount);
        int.TryParse(goldText.text, out goldAmount);
        int.TryParse(jewelryText.text, out jewelryCount);

        Dictionary<string, object> data = new Dictionary<string, object>();
        data["Food"] = foodCount;
        data["Gold"] = goldAmount;
        data["Jewelry"] = jewelryCount;

        GameManager.Instance.Reference.Child(GameManager.Instance.UDID).UpdateChildrenAsync(data);

        GameManager.Instance.Reference.Child(GameManager.Instance.UDID).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
                Debug.Log("failed");
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                Debug.Log(snapshot.Child("Food").Value);
                Debug.Log(snapshot.Child("Gold").Value);
                Debug.Log(snapshot.Child("Jewelry").Value);
            }
        });
    }
}
