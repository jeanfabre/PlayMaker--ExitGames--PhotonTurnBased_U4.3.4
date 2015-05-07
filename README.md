# PlayMaker--ExitGames--PhotonTurnBased_U4.3.4

This is the repository for on going development of PlayMaker support for ExitGames Photon TurnBase Solution.

You need the following:

- Unity 4.3.4
- PlayMaker 1.8 Beta

This project is still an early alpha system, with much work left on the data management. 

Please get in touch with me for requests and commments, and use Github to raise issues.

## Demos

You can find mac and web builds for both the original demo and the PlayMaker demo version. This allows for live testing, benchmarking and also testify of the compatibility between the PlayMaker demo version and the original version ( run the pm version and the original version, they will connect seamlessly)

[Original Demo Web Player](http://htmlpreview.github.io/?https://raw.githubusercontent.com/jeanfabre/PlayMaker--ExitGames--PhotonTurnBased_U4.3.4/master/Builds/DemoScene/DemoScene.html)
[PlayMaker Demo Web Player](http://htmlpreview.github.io/?https://raw.githubusercontent.com/jeanfabre/PlayMaker--ExitGames--PhotonTurnBased_U4.3.4/master/Builds/DemoScene_PM/DemoScene_PM.html)

Warning: Some browsers don't support the Unity Web player anymore ( likey chrome), use Safari on mac ( not sure about explorer on Windows)

You can find the Mac Apps on the Builds folder:

[Original Demo Mac](https://github.com/jeanfabre/PlayMaker--ExitGames--PhotonTurnBased_U4.3.4/raw/master/Builds/DemoScene.app.zip)
[PlayMaker Demo Mac](https://github.com/jeanfabre/PlayMaker--ExitGames--PhotonTurnBased_U4.3.4/raw/master/Builds/DemoScene_pm.app.zip)


##Notes for documentations

The layout for the lobby UI is misleading, I'll move the joinRandom in the "Games in Lobby" section because the gamesList is not the list from which joinRoom will pool. but it sits at the top. I was confused for a while with this ( mostly due to the current partial implementation, so I lacked the global view of the various processed, but still, a more adequate interface will lift the assumption made visually of the behavior).

I have to mirror classes like ErrorCode because PlayMaker doesn't visually expose this kind of implementation, so I have now enums reflecting exactly this class ( more will come). so this will need to be tested on each release to make sure they are up to date with possible future additions in these classes acting as enum.

