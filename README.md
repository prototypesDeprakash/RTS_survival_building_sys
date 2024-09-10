# RTS_Survival + Town_Defence

## Setting Up Version Control for My Unity RTS Project

### Zombie AI (State Machine)

![image](https://github.com/user-attachments/assets/eeec2a04-dead-4873-8856-b71719b0c623)  
Here is the State machine (I'll try to explain each state later):

![image](https://github.com/user-attachments/assets/95f3dd02-4afd-4ee3-8144-37b0383081a9)  
I created all the logic using PlayMaker FSM for the zombie, combined with C#.

### The Player's Mechanics

![image](https://github.com/user-attachments/assets/3efae2fc-a86e-4585-af32-0b3290ec7800)  
So far, the player can shoot. I have a script attached to the player's main camera that deducts health from the zombie script.

The Animator for player

The third person controller is build on top of thirdperson locomotion + fly system
![image](https://github.com/user-attachments/assets/2ea964ea-318d-4c24-9e38-7b7215149a07)

the shooting animation is invoked with the shoot bool parameter (hasexit time is set to false while invoking) 

The town hall (health + logic)
One of the core objective of this game is to keep the townhall alive 
![image](https://github.com/user-attachments/assets/617ec2b7-b7ae-477b-9457-14a3ab55a90e)

everytime the zombie comes in contact with the townhall , it deduces the townhalls health , also updated in slider GUI on canvas 

The RTS Mode

![image](https://github.com/user-attachments/assets/214abcbb-6f39-4474-addd-c8341efeab6b)
The cool part of the game , for me is switching to top down camera and start placing stuffs to defend and grow your base , 
in rts mode you can place walls to defend the zombeis as more waves aproach , I have also planned to add shooting towers that shoots the zombie automatically when the zombie comes in contact with the trigger.

Spawning Zombies (wave system? may be)
![image](https://github.com/user-attachments/assets/e4e5d952-2b4e-429e-911b-0a1fa070321e)

So far here is the simple script that spawns zombies on random spawn points selected accross the map , 

If this game goes by story , i dont have the need to make a wave system  i can just duplicate things ..
but if we go procedural , then i need to optimize things in a better way , i need to make sure the game does not crashes, 

infinite spawnning - i have done a lots of mistakes on that parts and i guess i learnt something from my previous projects ,


Time the game 


![image](https://github.com/user-attachments/assets/2582c2a2-128b-41b4-8e32-8863aadad1a5)
The mistake i made in this infinite system was , i creates the instance (clone) of a enemy that is currently in the scene , so if the player kills the enemy the instantiated gameonjects(enemies) are dead already ... to solve this you may suggest using a prefab , i also got a error on that , in prefab the object reference is not set by default , 
FIX: this may not be an optimal fix but what i did is , i just move the enemy that im going to make a infinite copy to z - 1+23e somethig like that , so its impossible for that object to come in contact with the scene .



Future Ideas 


![image](https://github.com/user-attachments/assets/b44b2538-1325-4d61-8153-7718aef0a602)
Imagine summoning your fello pirates on the boat to shoot cannons on the zombie after reaching a certain stage (like collecting power up etc.)

Well i dont have a story ,. started this as a simple project ..





