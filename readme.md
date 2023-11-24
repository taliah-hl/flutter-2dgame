# Project

## 共用Spec

### Player

- player size: TBC
- player jump force: 16
	- control at: player -> player movement script -> jumping force
- player velocity: 10
	- control at: player -> player movement script -> movement speed
- player ->rigidbody ->gravity scale-> 5
- 大概可跳起2.2 個grid
- player die if position out of range: y<=-12 or y>=14

### Scene

- main camera -> Size: 10
- grid size: :(x,y)=(1,1)
- 場景直向有20格

### Game Flow Control
- player object 每關重新create, 只有必要參數用DontDestroyOnLoad 傳

## 參考資料

### How to change Gravity Direction in 1 minute | Quick Unity Tutorial
https://www.youtube.com/watch?v=KV8wNSo91bM

### Unity Scriptable Object
- 生一個物件template
- 用以快速生成擁有相同param 的物件

https://www.youtube.com/watch?v=aPXvoWVabPY&ab_channel=Brackeys
