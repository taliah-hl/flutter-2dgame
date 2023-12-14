# Project

## 共用Spec

- [Project](#project)
  - [共用Spec](#共用spec)
    - [Player](#player)
    - [Scene](#scene)
  - [Function 架構](#function-架構)
    - [每個Script做什麼](#每個script做什麼)
    - [變數在哪裡](#變數在哪裡)
    - [Game Flow Control](#game-flow-control)
  - [參考資料](#參考資料)
    - [How to change Gravity Direction in 1 minute | Quick Unity Tutorial](#how-to-change-gravity-direction-in-1-minute--quick-unity-tutorial)
    - [Unity Scriptable Object](#unity-scriptable-object)
    - [Pausing game in Unity](#pausing-game-in-unity)

## Branch

- all-lv-playable -> 各關已完整可玩,不再加大改動,美術不在這關改動

### Bug fix required!!
- ch3.3 GUI retry及quit鍵沒有反應

### 欠!!!
- ch2.1, 2.3 可更豐富
- 死亡動畫,換場等

### GUI we need
GUI we need
1. main scene-> 已有
   - 有play, 說明, menu

2. menu scene (有各個level 的按鍵) -> 已有
   - 12 個按鍵 (4章->每要3關)

3. 大說明scene -> 已有,但要換成中文
   - 基本操作, 如何切重力, player踩到尖刺會死亡(因為每個章節都有因此擺在大說明，尖刺請放圖片)

4. 小故事scene (目前先把已經有的圖對應關卡放上去，先不管文本) 

5. 章節說明*4

   - 有這章的機制
   - 有「開始遊戲」鍵
   - **章節說明的部分請截遊戲內場景object圖做說明**
   - chap1說明:
   - 	gravity object:關卡內存在受gravity所影響的物體，會隨gravity方向往上掉或往下掉
   - 	尖刺:碰觸會導致player死亡
     
   - chap2說明:
   - 	cloud:受到gravity影響的物體
- 平台上/下的紅色岩漿不能踫到
   - 	lava:由畫面上方流下，受gravity影響，player碰觸會死亡
     
   - chap3說明:
   - 	傳送門:player碰觸後會傳送到門的另一端，在經過使用後會進入2秒冷卻期，冷卻結束才能再次傳送
   - 	會虛實切換的東東:每次player跳躍會使其狀態虛實切換
- 狀態為「實」時，如player在內部,會死亡
     
   - chap4說明:
   - 	紅色地板:player踩中會導致中毒死亡
   - 	藍色小球:player碰觸到後可得一個持續10秒的保護罩，期間可以中毒的傷害
   - 	空中平台:player碰觸後經過2秒會變成gravity object受重力影響，紅色平台同樣會導致player中毒死亡

6. in-level GUI (每關左邊的bar)
   - static:
      - current level
      - 開說明的按鍵
   - 點說明是開的overlay GUI

7. 轉場動畫(算時間淡入淡出)

8. 死亡動畫-> 自動reload 該關

9. 闖完整章的scene

### Player

- player size: x:0.89, y: 1.15
- player jump force: 12 
	- control at: player -> player movement script -> jumping force
- player velocity: 6 
	- control at: player -> player movement script -> movement speed
- player ->rigidbody ->gravity scale-> 3 
- 大概可跳起2.2 個grid
- 因player 本身有大小,這配搭剛好能跳上高度2個grid的東西
- 橫向大概可跳6格
- player die if position out of range: y<=-12 or y>=14

### Scene

- main camera -> Size: 10
- grid size: :(x,y)=(1,1)
- 場景直向有20格
- game view ->aspect: 1440*512 fixed resolution


以下為每個scene都需要相同的:
- GameManager
- Player 
- in-level UI

每個關卡都需要不同的(每個scene 獨立):

- SceneManager
- LevelSpec

## Toggle count
- control in Scripts->LevelSpec->LevelXX_Spec
- e.g. Level11_Spec->即ch1-1的spec, Level32_Spec->即ch3-2的spec

```
1-1: 3
1-2: 3
1-3: 3
2-1: 5
2-2: 3
2-3: 4
3-1: 1
3-2: 3(1)
3-3: 2
```

## Function 架構

```
├─Player
   ├─GravityController.cs
   ├─PlayerMovement_NoAnimator.cs
   └─PlayerLifeControl.cs
   
├─SceneManager
   ├─SceneSpec.cs
   
├─GameManager
   ├─GameManager.cs
   
   
├─in-level UI
    ├─GravityCntText
	     ├─GravityDisplayer
		      ├─GravityDisplay.cs
```
### 每個Script做什麼

PlayerMovement_NoAnimator.cs
- player 的左右跳
- 將來會用有animator的版本取代

GravityController.cs
- 控制gravity轉換
- 提供GravityController.GravToggleLeft (public)

PlayerLifeControl.cs
- 檢查player飛出界外,檢查player接觸trap / 關卡完成點

GameManager.cs
- 裡面有跳至gameover / victory / main menu等function
- 裡面有遊戲暫停function (GameManager.pauseGame)

SceneSpec.cs
- load 該關卡的spec (目前只有max gravity toggle count)
- 提供 SceneSpec.MaxGravToggle (public)

### 變數在哪裡

gravity toggle 剩餘次數 //public static, 即所有script 都可access
```
GravityController.GravToggleLeft  
```
gravity toggle max次數//public static
```
SceneSpec.MaxGravToggle
```

遊戲是否於暫定狀態 //public static
```
GameManager.IsGamePaused
```


### Game Flow Control
- player object 每關重新create, 只有必要參數用DontDestroyOnLoad 傳

## 參考資料

### How to change Gravity Direction in 1 minute | Quick Unity Tutorial
https://www.youtube.com/watch?v=KV8wNSo91bM

### Unity Scriptable Object
- 生一個物件template
- 用以快速生成擁有相同param 的物件
- !! Runtime 時改變的值會被存下來(可寫function 讓它不要存)

https://www.youtube.com/watch?v=aPXvoWVabPY&ab_channel=Brackeys

### Pausing game in Unity
https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
Time.timeScale = 0;

Time.deltaTime 會停止
update -> 會繼續被call
FixedUpdate -> 不會call

需在pause時播放的animation -> timescale set to unscaled time

hit pause
https://www.youtube.com/watch?v=C949ILsyywg
