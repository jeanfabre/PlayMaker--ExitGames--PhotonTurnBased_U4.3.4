# PlayMaker--ExitGames--PhotonTurnBased_U4.3.4

This is the repository for on going development of PlayMaker support for ExitGames Photon TurnBase Solution.

You need the following:

- Unity 4.3.4
- PlayMaker 1.8 Beta

This project is still an early alpha system, with much work left on the data management. 

Please get in touch with me for requests and commments, and use Github to raise issues.



##Notes for documentations

The layout for the lobby UI is misleading, I'll move the joinRandom in the "Games in Lobby" section because the gamesList is not the list from which joinRoom will pool. but it sits at the top. I was confused for a while with this ( mostly due to the current partial implementation, so I lacked the global view of the various processed, but still, a more adequate interface will lift the assumption made visually of the behavior).

I have to mirror classes like ErrorCode because PlayMaker doesn't visually expose this kind of implementation, so I have now enums reflecting exactly this class ( more will come). so this will need to be tested on each release to make sure they are up to date with possible future additions in these classes acting as enum.

