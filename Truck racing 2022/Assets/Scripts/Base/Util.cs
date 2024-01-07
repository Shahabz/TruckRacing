//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
////using Facebook.MiniJSON;
//
//public class Util : ScriptableObject
//{
//    public static string GetPictureURL(string facebookID, int? width = null, int? height = null, string type = null)
//    {
//        string url = string.Format("/{0}/picture", facebookID);
//        string query = width != null ? "&width=" + width.ToString() : "";
//        query += height != null ? "&height=" + height.ToString() : "";
//        query += type != null ? "&type=" + type : "";
//        query += "&redirect=false";
//        if (query != "") url += ("?g" + query);
//        return url;
//    }
//
//
//    public static Dictionary<string, string> RandomFriend(List<object> friends)
//    {
//        var fd = ((Dictionary<string, object>)(friends[Random.Range(0, friends.Count)]));
//        var friend = new Dictionary<string, string>();
//        friend["id"] = (string)fd["id"];
//        friend["first_name"] = (string)fd["first_name"];
//        var pictureDict = ((Dictionary<string, object>)(fd["picture"]));
//        var pictureDataDict = ((Dictionary<string, object>)(pictureDict["data"]));
//        friend["image_url"] = (string)pictureDataDict["url"];
//        return friend;
//    }
//
//	private static List<string> friendsIds = new List<string> ();
//
//	public static void GetFriendList(List<object> friends, bool isInvitable) {
//		FriendsDetails friendDetails;
//		for (int i = 0; i < friends.Count; i++) {
//			var friendData = ((Dictionary<string, object>)(friends[i]));
//			friendDetails = new FriendsDetails ();
////			Util.Log("name before id : ");
//			friendDetails.ID = (string)friendData["id"];
//			if(friendsIds.Contains(friendDetails.ID)) {
//				continue;
//			}else {
//				friendsIds.Add(friendDetails.ID);
//			}
//			friendDetails.FirstName = (string)friendData["first_name"];
////			Util.Log("name before picture : ");
//			var pictureDict = ((Dictionary<string, object>)(friendData["picture"]));
////			Util.Log("name before data : ");
//			var pictureDataDict = ((Dictionary<string, object>)(pictureDict["data"]));
////			Util.Log("name before url : ");
//			friendDetails.ImageURL = (string)pictureDataDict["url"];
//			if(isInvitable) {
//				FBMainMenu.InvitableFriends.Add(friendDetails);
//			}else {
//				FBMainMenu.PlayingFriends.Add(friendDetails);
//				if(FBMainMenu.AppFriendIds == null) {
//					FBMainMenu.AppFriendIds = new List<string>();
//				}
//				//Debug.Log("friends ID "+friendDetails.ID);
//				FBMainMenu.AppFriendIds.Add(friendDetails.ID);
////				MainMenu.Instance.AddProfilePic(friendDetails.ID);
//			}
//		}
//
//		if (!isInvitable) {
//			//parseScoreLoaderScript.obj.SetAppFriendsArray();
//		}
//
//	}
//
//    public static Dictionary<string, string> DeserializeJSONProfile(string response)
//    {
//        var responseObject = Json.Deserialize(response) as Dictionary<string, object>;
//        object nameH;
//        var profile = new Dictionary<string, string>();
//        if (responseObject.TryGetValue("first_name", out nameH))
//        {
//            profile["first_name"] = (string)nameH;
//        }
//        return profile;
//    }
//
//	public static List<RequestData> DeserializeRequests(string setOfRequests) {
//		var requestsObj = Json.Deserialize (setOfRequests) as Dictionary<string,object>;
//		//var requests = new Dictionary<string,string>[10];
//		object request;
//		var allRequests = new List<object> ();
//		if (requestsObj.TryGetValue ("data", out request)) {
//			allRequests = (List<object>)request;
//			Util.Log ("name request : " + allRequests.Count);
//
//			List<RequestData> requestsData = new List<RequestData>();
//
//			for(int i = 0,j = 0; j < allRequests.Count; j++) {
//				var currentRequestData = (Dictionary<string,object>)allRequests[j];
//				string message = (string)currentRequestData["message"];
//				if(message.Contains("Invite")) {
//					continue;
//				}
//				string[] requestAndSendrIDs = ((string)currentRequestData["id"]).Split(new char[]{'_'});
//				string reqID =  requestAndSendrIDs[0];
//				if(FBMainMenu.RemovedRequestIDS.Contains(reqID)){
//					continue;
//				}
//
//				requestsData.Add(new RequestData());
//				requestsData[i].AskingFor = (string)currentRequestData["message"];
//				requestsData[i].RequestID = requestAndSendrIDs[0];
//				var from = currentRequestData["from"]as object;
//				requestsData[i].SenderName = (string)((Dictionary<string,object>)from)["name"];
//				requestsData[i].SenderID = ((string)((Dictionary<string,object>)from)["id"]).Trim();
//				Util.Log("name of request sender : "+requestsData[i].SenderName +" : "+requestsData[i].AskingFor +" : "+requestsData[i].RequestID
//				         +" : "+requestsData[i].SenderID);
//				i++;
//				
//			}
//			return requestsData;
//
//		} else {
//			Util.Log("Unable to parse requests name(tag)");
//			return null;
//		}
//	}
//    
//    public static List<object> DeserializeScores(string response) 
//    {
//
//        var responseObject = Json.Deserialize(response) as Dictionary<string, object>;
//        object scoresh;
//        var scores = new List<object>();
//        if (responseObject.TryGetValue ("data", out scoresh)) 
//        {
//            scores = (List<object>) scoresh;
//        }
//
//        return scores;
//    }
//
//    public static List<object> DeserializeJSONFriends(string response)
//    {
//        var responseObject = Json.Deserialize(response) as Dictionary<string, object>;
//        object friendsH;
//        var friends = new List<object>();
//		Util.Log ("name : "+response);
//		if (responseObject.TryGetValue("friends", out friendsH))//invitable_friends
//        {
////			Debug.Log("name : friends "+friends);
//            friends = (List<object>)(((Dictionary<string, object>)friendsH)["data"]);
//        }
////        if (responseObject.TryGetValue("friends", out friendsH))
////        {
////            friends.AddRange((List<object>)(((Dictionary<string, object>)friendsH)["data"]));
////        }
//        return friends;
//    }
//
//	public static List<object> DeserializeJSONFriends(string response, bool isInvitable)
//	{
//		var responseObject = Json.Deserialize(response) as Dictionary<string, object>;
//		object friendsH;
//		var friends = new List<object>();
//		Util.Log ("name : "+response);
//		if (isInvitable) {
//			if (responseObject.TryGetValue ("invitable_friends", out friendsH)) {//
//			//			Debug.Log("name : friends "+friends);
//			friends = (List<object>)(((Dictionary<string, object>)friendsH) ["data"]);
//			}
//		} else {
//			if (responseObject.TryGetValue ("friends", out friendsH)) {
//					friends = ((List<object>)(((Dictionary<string, object>)friendsH) ["data"]));
//			}
//		}
//		return friends;
//	}
//
//    public static string DeserializePictureURLString(string response)
//    {
//        return DeserializePictureURLObject(Json.Deserialize(response));
//    }
//
//    public static string DeserializePictureURLObject(object pictureObj)
//    {
//        
//        
//        var picture = (Dictionary<string, object>)(((Dictionary<string, object>)pictureObj)["data"]);
//        object urlH = null;
//        if (picture.TryGetValue("url", out urlH))
//        {
//            return (string)urlH;
//        }
//        
//        return null;
//    }
//
//
//    
//    
//    public static void DrawActualSizeTexture (Vector2 pos, Texture texture, float scale = 1.0f)
//    {
//        Rect rect = new Rect (pos.x, pos.y, texture.width * scale , texture.height * scale);
//        GUI.DrawTexture(rect, texture);
//    }
//    public static void DrawSimpleText (Vector2 pos, GUIStyle style, string text)
//    {
//        Rect rect = new Rect (pos.x, pos.y, Screen.width, Screen.height);
//        GUI.Label (rect, text, style);
//    }
//
//    private static void JavascriptLog(string msg)
//    {
//        Application.ExternalCall("console.log", msg);
//    }
//
//    public static void Log (string message)
//    {
//        //U5 Debug.Log(message);
//        if (Application.isWebPlayer)
//            JavascriptLog(message);
//    }
//    public static void LogError (string message)
//    {
//        Debug.LogError(message);
//        if (Application.isWebPlayer)
//            JavascriptLog(message);
//    }
//    
//}
//
//public class RequestData {
//	public string SenderName;
//	public string SenderID;
//	public string AskingFor;
//	public string RequestID;
//	public bool IsSelected;
//}
//public class FriendsDetails {
//	public string ID;
//	public string FirstName;
//	public string ImageURL;
//
//}
//
//
