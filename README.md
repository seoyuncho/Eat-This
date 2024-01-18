# Eat-This
### 팀원

---

조서윤 고려대학교 컴퓨터학과 22학번

남승훈 카이스트 전산학부 22학번

### 개발 스펙

---

유니티 C#

Photon Unity Networking

### 게임 내용

---

- **시작 화면(이거나 먹어라 = Eat This)**
    ![Untitled](https://github.com/seoyuncho/Eat-This/assets/103191590/eedd842b-6b33-4057-b901-08520c372eb1)
  
    - 싱글 플레이 및 멀티 플레이 선택 가능
 
      
- **싱글 플레이**
    
    
    - 좌,우,점프를 통해 하늘에서 떨어지는 똥을 피한다.
    - 게임 Stage
        - 스테이지1
          ![Untitled](https://github.com/seoyuncho/Eat-This/assets/103191590/8c1f0fd7-d137-453f-9d6e-48739b0798a3)

            - 일정한 시간 간격으로 랜덤한 위치에서 떨어지는 똥을 피한다.
        - 스테이지2
          ![Untitled](https://github.com/seoyuncho/Eat-This/assets/103191590/ff769940-18ab-44fc-a395-e8180b65fcd2)
            
            - 크기가 커진 똥이 하늘에서 떨어진다.
        - 스테이지3
            - <이미지>
                - 빨간색 경고 선이 로딩된 후 빠르게 떨어지는 똥을 피한다.
        - 스테이지4
            - <이미지>
            - 위의 모든 똥 객체들이 하늘에서 떨어지고, 이를 피해야 하낟.
    - 아이템
        - 아이템1(키보드1, 변비는 괴로워)
            - <이미지>
            - 하늘에서 똥을 내리는 신에게 변비유발약을 먹인다!
            - 화면에 있던 모든 똥 객체들이 사라지며 5초간 똥이 내리지 않는다.
        - 아이템2(키보드2, 쿠릉쿠릉물아내려가라)
            - <이미지>
            - 하늘에 있던 모든 똥 객체가 변비로 빨려 들어간디.
        - 아이템3(키보드3, 나타나라우산아!)
            - <이미지>
            - 캐릭터가 우산을 쓰게 되고, 똥을 맞아도 플레이어가 죽지 않는다.
        - 황금거위
          ![Untitled](https://github.com/seoyuncho/Eat-This/assets/103191590/7dc55f03-f478-41a6-84aa-891cced2fde1)
            
            - 황금거위를 먹으면 한 코인당 5점인 무지개 코인이 떨어진다.
- 게임오버 및 점수저장
    ![Untitled](https://github.com/seoyuncho/Eat-This/assets/103191590/c202634d-ec1c-4645-bb59-4146ab29be03)
    ![Untitled](https://github.com/seoyuncho/Eat-This/assets/103191590/9a1a0d8d-2593-4620-95de-8359c4c3e954)


- **멀티 플레이**
    - 방 생성 및 참여
        - <이미지>
        - 마스터 클라이언트가 방을 생성하면, 다른 클라이언트는 해당 이름의 방에 참여한다.
        - 다른 사용자가 방에 입장해야 게임이 시작된다.
    - 규칙
        - 스테이지 및 아이템1,2,3은 기존과 같으며 아이템 4,5,6이 추가된다.
        - 아이템4(중력을 90도 돌려버려)
            - <이미지>
            - 다른 사용자가 아이템을 누르면 똥 객체가 왼쪽에서 오른쪽으로 날라온다.
            - 플레이어는 이를 점프하여 피해야 한다.
        - 아이템5(왼쪽도 똥 오른쪽도 뚕)
            - <이미지>
            - 가로로 길게 붙은 똥이 떨어진다.
            - 캐릭터는 그 중 비어있는 부분으로 들어가서 피해야 한다.
        - 아이템6(방귀가스는 위독해)
            - <이미지>
            - 5초간 방귀가스가 나타나 사용자의 시야를 가린다.
