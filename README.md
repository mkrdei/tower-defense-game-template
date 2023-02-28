# tower-defense-game-template
 This is a template for a tower defense game.
 
 The template provides variety of tower types. By selecting tower areas a menu appears and these tower types could be build by clicking the menu items. All tower types have different menus of functions and these functions can be changed via editor. However, if you need a new function you have to write it in TowerArea script. OnSelectMenu assets and prefabs are stored in ScriptableObjects.

 The wave system consist of two parts: EnemySpawners and WaveManager. EnemySpawners store enemy groups data which will be spawned in each wave and start spawning when waveStartedEvent is triggered from WaveManager. WaveManager tells EnemySpawners if the wave is started and when all the waves are cleared GameManager will be informed.
 
 ![image](https://user-images.githubusercontent.com/24762808/221868462-85ce584c-1222-47fd-a26c-b6c9c96b2ede.png)
 ![image](https://user-images.githubusercontent.com/24762808/221869483-2e44bc0e-549f-4971-bf4c-294d9010d789.png)
 ![image](https://user-images.githubusercontent.com/24762808/221869685-5e98b72a-c295-40e0-aa0f-0e2174fd3b44.png)
![image](https://user-images.githubusercontent.com/24762808/221870052-b0bdb530-e133-4726-88ec-1ea1366cd0ba.png)

![image](https://user-images.githubusercontent.com/24762808/221869158-75e3bf48-aa1b-4533-8178-4abd37aff165.png)
![image](https://user-images.githubusercontent.com/24762808/221869241-8ef95163-93ec-47a5-9caa-0dca84426814.png)
![image](https://user-images.githubusercontent.com/24762808/221868940-1fe45e63-4104-47a1-a19d-b68e450aa59a.png)

