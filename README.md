CS512 final project
Yuhao zhang
Network connection build up based on netcode sample from unity documentation. Host or client can login anonymous and create or join a lobby. When all player are ready host can start the game by pressing play.
 
 










The game itself is wave based, enemy will spawn by wave separated by countdown timer. There are melee type and range type enemy. 
Player has 3 status, hp mana and exp. If hp=0, player lose the game. Mana is required to use skills. Exp will increase when player gathering exp balls and level up when it’s full.
Player will win the game 
 
 

 

Player can use skill point to level up their skill. Player gain 1 skill point when they level up. Level up will also fully recover player’s health and mana and increase base damage by 1.
Player has 1 status: base damage which will control how much damage player made.

 


Win lose state: player lose when health goes down to 0. And win by surviving all waves.
 
 
