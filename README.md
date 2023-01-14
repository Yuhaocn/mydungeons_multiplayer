CS512 final project
Yuhao zhang
Network connection build up based on netcode sample from unity documentation. Host or client can login anonymous and create or join a lobby. When all player are ready host can start the game by pressing play.
 
 




![_{7_{XD1XP1DJDCEPLL@6N](https://user-images.githubusercontent.com/102940480/212444072-d0272e82-d95f-4717-9ef9-bcf1b0593434.png)






The game itself is wave based, enemy will spawn by wave separated by countdown timer. There are melee type and range type enemy. 
Player has 3 status, hp mana and exp. If hp=0, player lose the game. Mana is required to use skills. Exp will increase when player gathering exp balls and level up when it’s full.
Player will win the game 
 
 
![ZDW6G(3EN$Q@6(M5{%ESGRF](https://user-images.githubusercontent.com/102940480/212444079-e955a38b-648d-48b6-bc67-a7ae0b03f994.png)

 

Player can use skill point to level up their skill. Player gain 1 skill point when they level up. Level up will also fully recover player’s health and mana and increase base damage by 1.
Player has 1 status: base damage which will control how much damage player made.

 
![~X})0UVZUW6LRLV% DSDPD6](https://user-images.githubusercontent.com/102940480/212444086-43cb5fca-260e-433a-bce1-cd57a8a5b037.png)


Win lose state: player lose when health goes down to 0. And win by surviving all waves.
 
 
