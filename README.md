## Introduction
Ce jeu de type Shoot'Em Up n'a pas de nom. C'est un jeu destiné à montrer ma capacité à utiliser des structures de données cohérentes dans un temps limité (1 semaine).


## Mes intentions
Pour ce jeu, je veux créer un système tel quel:
- Bonus : Des portails apparaîtront pour donner des bonus au joueur. Voici les différents type de portails :
	- Portail de vie : heal le joueur
	- Portail d'attaque : Upgrade l'attaque du joueur
	- Portail de vitesse d'attaque : Upgrade la vitesse d'attaque du joueur
- Ennemies :
	- Luge : Enemie par défaut. Il ne bouge pas et tire 2 laser toute les secondes
	- Rendroach : Le Rendroach est un kamikaze qui à la capacité de passer outre les défenses du joueur.
	- The boss: ???


## Les points que je veux mettre en avant
Somaire:
- [Le système de vie](#le-système-de-vie)
- [Les bonus](#les-bonus)

### Le système de vie
La vie de toute les entitée est visible et détaché de tout le reste, rendant le system utilisable pour de futurs projets.<br>
Avoir une animation de mort null ne pose aucun problème puisque mon code le prend en compte. Mais la barre de vie est nécessaire.


![](ReadmeImages/HealthInspector.png)<br>
![](ReadmeImages/HealthCode.png)


Faire des dégats, c'est simplement soigner le joueur avec une valeur négative:

![](ReadmeImages/HealthCode_DealDamage.png)

### Les bonus
Les bonus fonctionnent très simplement.<br>
Il vous suffit de :
- créer une classe enfant à Gate
- déclarer vos variables pour le bonus
- override la fonction Action (qui est obligatoire grâce à sa propriété `abstract`)

![](ReadmeImages/GateCode.png)
