using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomNameInputField;  // 방 이름 입력 필드
    public TMP_InputField roomNameEntryInputField;  // 방 이름 입력 필드


    void Start()
    {
        // 이 함수를 호출하여 Photon 서버에 연결합니다.
        PhotonNetwork.ConnectUsingSettings();
        
        PlayerPrefs.GetInt("isMultimode", 0);
        PlayerPrefs.SetInt("isMultimode", 1);
    }

    public override void OnConnectedToMaster()
    {
        // 서버에 연결되었을 때 호출됩니다.
        Debug.Log("Connected to Photon Server.");
        
        // 로비에 접속합니다.
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        // 로비에 접속했을 때 호출됩니다.
        Debug.Log("Joined a Lobby.");
    }
    // 방 생성 버튼이 클릭되었을 때 호출될 함수
    public void CreateRoom()
    {
        string roomName = roomNameInputField.text;  // 입력된 방 이름 가져오기
        if (string.IsNullOrEmpty(roomName))  // 방 이름이 비어있지 않은지 확인
        {
            Debug.LogError("Room name is empty or null.");
            return;
        }
        PhotonNetwork.CreateRoom(roomName);  // 방 생성
    }
    public void EnterRoom(){
        string enter_roomname = roomNameEntryInputField.text;
        if(string.IsNullOrEmpty(enter_roomname)){
            Debug.LogError("Room name is empty or null.");
            return;
        }
        JoinRoom(enter_roomname);
    }

    // 방 생성에 성공했을 때 호출되는 콜백
    public override void OnCreatedRoom()
    {
        Debug.Log("Room created successfully.");
    }

    // 방 생성에 실패했을 때 호출되는 콜백
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"Room creation failed: {message}");
    }
    // public override void OnRoomListUpdate(List<RoomInfo> roomList)
    // {
    //     // foreach (Transform child in roomlistpanel.transform){
    //     //     Destroy(child.gameObject); // 기존 방 목록 항목 제거
    //     // }

    //     // foreach (RoomInfo room in roomList){
    //     //     if (room.RemovedFromList){
    //     //         continue; // 제거된 방은 무시
    //     //     }

    //     //     InstantiateRoomListItem(room); // 새 방 목록 항목 생성
    //     // }
    // }

    public void JoinRoom(string roomName){
        PhotonNetwork.JoinRoom(roomName); // 선택한 방에 입장
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"Joined the room: {PhotonNetwork.CurrentRoom.Name}");
        if(PhotonNetwork.CurrentRoom.PlayerCount==2){
            SceneManager.LoadScene("MainScene");
        }
        // 추가적인 입장 로직 구현, 예를 들어 씬 전환 등

    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"Failed to join room: {message}");
    }
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer){
        // 새로운 플레이어가 방에 입장하면 현재 플레이어 수를 확인하고, 두 명일 경우 메인 씬을 로드합니다.
        if (PhotonNetwork.CurrentRoom.PlayerCount ==2 && PhotonNetwork.IsMasterClient){
            // 마스터 클라이언트만 씬 로딩을 시작합니다.
            PhotonNetwork.LoadLevel("MainScene");
        }
    }
}