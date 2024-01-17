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
    
    ![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/f6cb388f-3934-47d6-9928-26d2e10eb0fc/91d83160-929c-4d19-9e13-ed4fad3eedd3/Untitled.png)
    
    - 싱글 플레이 및 멀티 플레이 선택 가능
- **싱글 플레이**
    
    
    - 좌,우,점프를 통해 하늘에서 떨어지는 똥을 피한다.
    - 게임 Stage
        - 스테이지1
            - <이미지>
            - 일정한 시간 간격으로 랜덤한 위치에서 떨어지는 똥을 피한다.
        - 스테이지2
            - <이미지>
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

- 브레인스토밍
    - 브레인스토밍
        - 진짜 이거 볼거에요?
            - 진짜로요?
                
                흥
                
                - 후 그렇다면 어쩔 수 없죠..
                    - 브레인스토밍
                        
                        ### 브레인스토밍
                        
                        ---
                        
                        - 만약 게임을 하게 된다면??
                            - FPS
                            - 2D 화면에서 게임을 보여주는,,
                            - 난이도가 어떠한가??
                                - 화면이 지속적으로 바뀌어야하는 애들일수록 더 어려워짐
                                    - subway runner 얘도 화면 계속 바뀜(계속 뛰니까)
                                        - 얘는 알아서 움직이니까 쉬운데
                                    - 내 의지로 화면이 바뀌면 더 어려워짐
                                        - FPS 게임 같은거
                                        
                                        와…
                                        
                                
                            - 일단 맵이 있음
                                - 캐릭터가 돌아다닐 수 있는 게임이면 좋겠다~~
                                - 게임이 어떻게 되면 끝나고? 목표가 뭔지? (기획적으로)
                                    - 그냥 생존 ⇒ 점수 모으기
                                        - 점수가지고 랭킹
                                    - 종료선까지 빨리 들어오기
                                    - 최종적으로 상대팀 뿌시기
                                    
                            - 아니면 똥 피하기 게임처럼 한 화면에서 위에 객체가 생기고 이걸 피하는 간단한 게임
                                - 이렇게 하면 구현 난이도가 너무 낮나?
                                - 난이도를 구분하고 아이템같은거를 추가하기!
                                - 너무 재밌겠는데!!!
                                - 사용자가 로그인하면 해당 사용자가 추가한 친구들 목록 보여주고 랭킹 띄우기
                                - 아이템 주고 받기
                                - **똥으로 해서 원초적인 재미를 준다!!**
                                - 그리고 2명이서 같이 게임을 할 수 있게 한다면 재밌을 것 같다!
                                    - ~~(아이템 구매해서 상대팀한테 설사약 먹이기 → 상대 화면에서 똥이 겁나 나옴)~~
                                    - 위처럼 다른 사람한테 막 아이템을 사용해서 방해 공작을 할 수 있다면 좋을 것 같음
                                    - 막 유산균 먹이면 똥 크기가 커짐
                                    - 변비 유발하는 약 먹이면 똥 크기가 분할되어서 작은 크기로 더 빠르게 나옴
                                    - 우산 있으면 똥을 맞지 않을 수 있음
                                
                                https://www.youtube.com/watch?v=PyN3JkPTpAI&list=PLO-mt5Iu5TeYI4dbYwWP8JqZMC9iuUIW2&index=6
                                
                                https://www.youtube.com/watch?v=bEXmJAo8OCo
                                
                                [[유니티 강좌] 2D RPG 게임 만들기 - 1 / 캐릭터 생성](https://hoil2.tistory.com/5)
                                
                            
                            ### 로드맵
                            
                            ---
                            
                            1일차: 유니티 사용 방법 숙지, 기본적인 화면 만들어보기
                            
                            2일차: 똥이 내려오고 사용자를 움직이게 하는 화면 만들기, 분업 어떻게 할 지 정하기
                            
                            3일차: 이것저것 아이템 
                            
    
- 스크럼
    
    ### 스크럼
    
    - **01/12**
        
        ********************어제 한 일********************
        
        - 게임 컨셉 브레인스토밍
        - 깃 레포지토리 만들기
        - 유니티 공부해보고 전체적으로 감 잡기
            - 아이디어 정함! ⇒ 가장 기본적인 형태를 만들어보기
        
        **********************오늘 할 일**********************
        
        - 가장 기본적인 형태의 게임 만들어보기 ⇒ 협업할 방식 결정
            - 남씨 진행 상황
                - [x]  똥 오브젝트 생성
                - [x]  똥 랜덤으로 떨어지게 하기 (prefab 이용)
                - [x]  사람 움직이게 하기
                - [x]  똥과 사람의 충돌 감지하기 ⇒ 카운트를 출력해볼까?
                - [ ]  사람 움직이는 애니메이션 추가하기
                - [ ]  죽었을 때 애니메이션 추가하기
                - [x]  어떻게 협업 할 지 고민하기 ⇒ 깃
                - [ ]  누나랑 아이디어 구체화 회의 ( Day2 마지막)
            - 지금 해야 할 일 순서
                1. 애니메이션 수정
                2. 점프 가능하도록 만들기 ⇒ 애니메이션 수정해야함
                3. 거위 나왔을 때 코인 조금 더 빨라지게 하기
                4. 변기 구현하기
                5. 스테이지 나누기
    - **********01/13**********
        
        ********************어제 한 일********************
        
        - 게임의 기본적인 구조 완성하기
            - 스프라이트 (애니메이션) - 좌우로 이동
            - 적 - 아래로 떨어짐
            - 점수판 - 적이 바닥에 닿을 때마다 1점
            - 게임 종료 화면
            - 다시 시작 화면
        - 아이디어 구체화 회의
        - Unity - Github 연동하기
        
        **********************오늘 할 일**********************
        
        - 좌우 애니메이션 수정
        - 인트로 스토리
        - 코인
            - 꾸준하게 코인이 내려오고, 코인 먹는 개수에 따라서 코인 점수 화면에 띄워주기
        - 알아낸 점
            - **쿠크다스: 커피랑 잘 어울림**
        - 좌우이동시 애니메이션  https://my-develop-note.tistory.com/13
        - Scene Change (버튼) https://art-coding3.tistory.com/32
        - 아이템 인벤토리 https://www.youtube.com/watch?v=74vxsqQsFHE
    - **01/14**
        - 오늘 할 일
            - 변비약 구현
            - 변기 구현
            - 스테이지 나누는 화면 구현
                - 스텝 2 구현
                - 스텝 3 구현
            - 위에 까지 저녁 내로 끝내보기
            - 레밸업의 순간
                - 로그인 및 최고점수 띄우기, 친구들 점수 볼 수 있도록 하기??
                - 소켓을 활용한?? 실시간으로 플레이어간 소통을 어떻게 할 수 있는지 공부하기
    - **01/15**
        - 메인 화면 만들기
        - Photon Unity Networking을 이용해서 사용자 사이의 소통 하도록 구현
            - 서버 연결하기(성공)
            - 방 만들고, 참여하기
            - 서로 상호작용 주고 받기
    - ********************************************************************************************************************************************01/16********************************************************************************************************************************************
        - ~~키 잘못인식 문제 고치기 → 승훈~~
        - ~~공격 아이템 (5번) 추가하기~~
        - ~~시작 화면 - 1인모드와 2인 모드로 구분해서 시작하기 → 서윤~~
        
        ~~⇒ 점심 먹기 전까지~~
        
        - ~~공격 아이템 (6번) 추가하기 → 승훈~~
            - ~~방귀 안개 추가~~
        - ~~적 애니메이션 추가하기 → 서윤~~
        - UI 개선하기
            - 코인 차감 개수 표시 → 서윤
                - ~~공격할 때 코인 차감~~
            - 적 속도, 빈도 , 위치 등등 조절
                - 플레이하면서 난이도 조절
            - 아이템 사용시 딜레이, 효과 추가 (아이템 사용중 효과)
                - 아이템 사용하는 화면 개선하기
        - 스토리 화면 만들기 → 서윤
        - 효과음, 배경음악 넣기 → 나중 순서
        - **~~안드로이드로 바꾸기~~**
        
        <지금부터 해야 하는 일>
        
        - 승훈
            - ~~황금거위 먹었을 때 좀 더 특별하게 만들기~~
                - ~~거위 나타나는 빈도수 줄이기~~
                - ~~거위 먹었을 때 화면을 더 특별하게 만들기~~
            - ~~점수 카운트 방식 변경~~
                - 시간에 비례하게
            - 난이도 조절
                - 더 어렵게 만들기?-?
                - ~~STAGE4 만들기 ⇒ 여러 개가 같이 떨어지게 하기~~
            - ~~사용자가 다 방에 들어왔을 때 게임으로 넘어가게 하기~~
            - 효과음 시작
            - 프로젝트 내보내기 조금 찾아보기4
        - 서윤
            - **아이템 게이지**
            - ~~화면 발전시키기?? ⇒ 방 입장하는 화면~~
            - 효과음 시작
    - **01/17(Last Day)**
        - 해야 할 일
            - 효과음 내기
            - 아이템 사용 중이라는 것 알 수 있게 조절 잘하기
            - 노션 작성하기
            - 리드미 작성하기
            - 프로젝트 내보내기 후 컴퓨터에 깔아보기
            - 플레이해보며 난이도 조절하기
            - 멋있게 UI 발전하기
    
    - 기본 구성: 코인의 개수가 충분해지면, 아이템을 살 수 있도록 한다
    - 아이템 버튼을 누르면 아이템을 사용하고, 코인의 개수가 깎이는 시스템으로 사용
    - 아이템의 종류??
        - 황금알을 낳는 거위 ⇒ ?초 동안 내려오는 모든 게 코인으로 바뀜
        - 기저귀(우산) ⇒ ?초 동안 똥을 맞아도 무적
        - 변비약 ⇒ ?초 동안 내려오는 똥의 개수가 줄어들음
        
        | 똥 | 원래 내려옴 |  |
        | --- | --- | --- |
        | 코인 | 몇 초 지나면 내려옴 |  |
        | 거위 | 가끔 내려옴 | 먹으면 5초간 코인만 내려옴 |
        | 우산 | 5코인을 내고 살 수 있음 | 사면 5초간 우산 아이템 착용 |
        | 변비 | ?코인 내고 살 수 있음 | 사면 5초간 똥이 멈춤 |
        | 변기 | ?코인 내고 살 수 있음 | 누르면 변기가 나타나고,
         하늘에 있는 똥이 다 변기로 빨려 들어감 |
    - 스테이지 나누기
        - 스텝1: 기본적으로 똥이 내려옴
        - 스텝2: 가끔씩 큰 똥이 내려옴
        - 점프 추가하기
- 공부 및 자료 조사
