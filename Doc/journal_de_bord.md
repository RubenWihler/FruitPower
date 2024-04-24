# Journal de bord - FruitPower

## Introduction

Ce document est un journal de bord présentant les différentes étapes de la réalisation du projet FruitPower. Ce projet a été réalisé dans le cadre du Travail pratique individuel (TPI) durant la session de mai 2024. Il a pour but de valider mes compétences acquises pendant la formation Informaticien CFC dispensée à l’école d’informatique du CFPT au Petit-Lancy. FruitPower est un jeux vidéo utilisant la réalité virtuelle. Il a été développé en C# avec le moteur de jeu Unity.


## Suivi du projet

### Jour 1 - 24.04.2024

#### 7h50

Cher journal, aujourd'hui est un grand jour. Je commence mon TPI. J'ai hâte de commencer à travailler sur mon projet. Je vais commencer par lire le cahier des charges pour bien comprendre ce que je dois faire.

#### 8h10

J'ai fini de lire le cahier des charges. J'ai une idée plus claire de ce que je dois faire, mais il y a encore quelques points que je ne comprends pas très bien. principalement sur le HUD. Je vais demander des informations supplémentaires à mon maître d'apprentissage.

J'ai également commencé à réfléchir à la structure de mon projet. J'ai décidé de créer un dossier `Src` pour y mettre tout mon code source et un dossier `Doc` pour y mettre toute la documentation.

J'ai créé un repository Git pour mon projet et j'ai commencé à versionner mon code.
Je l'ai également mis en ligne sur GitHub pour pouvoir y accéder de partout.

Je vais maintenant commencer à faire la planification de mon projet. Je vais commencer par créer un planning prévisionnel pour pouvoir m’organiser et savoir ce que je dois faire et quand.

Pour cela je vais d'abord découper le travail en plusieurs tâches sous forme de user stories. Ensuite je vais mettre en place la méthode MoSCoW pour attribuer des priorités sur les tâches. Je vais toutes les regrouper dans un backlog.

Voici le backlog que j'ai créé :

> Pour rappel, les niveaux de priorités sont :  
> - P1 Must  
> - P2 Should  
> - P3 Could  

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 001 | Implémentation VR | En tant qu'utilisateur, je veux pouvoir interagir avec le jeu en utilisant un casque VR et ses contrôleurs. | P1 |
| 002 | Environnement 3D | En tant qu'utilisateur, je veux pouvoir évoluer dans un jardin en 3D de 2x2 mètres. et ne pas pouvoir sortir de la zone de jeu. | P1 |
| 003 | Main du joueur | En tant qu'utilisateur, je veux voir les contrôleurs dans le jeu sous forme de mains. | P1 |
| 004 | Arbres et buissons | En tant qu'utilisateur, je veux que le jardin contienne des arbres et des buissons. (Une dizaine) | P1 |
| 005 | Génération de fruits | En tant qu'utilisateur, je veux que des fruits apparaissent aléatoirement sur des arbres ou des buissons. Les fruits doivent apparaître à une vitesse définie. | P1 |
| 006 | Ramassage de fruits | En tant qu'utilisateur, je veux pouvoir ramasser des fruits en les ramassant avec les contrôleurs. | P1 |
| 007 | Disparition des fruits | En tant qu'utilisateur, je veux que les fruits disparaissent après quelques secondes s'ils ne sont pas ramassés | P1 |
| 008 | Compteur de points | En tant qu'utilisateur, je veux pouvoir ramasser des fruits pour gagner des points. Chaque fruit ramassé donne 1 point. | P1 |
| 009 | Visualisation des points | En tant qu'utilisateur, je veux voir le nombre de fruits que j'ai ramassé. | P1 |
| 010 | Compteur de temps | En tant qu'utilisateur, je veux voir le temps restant pour la partie. | P1 |
| 011 | Fin de partie | En tant qu'utilisateur, je veux que la partie se termine après 30 secondes. | P1 |
| 012 | Score final | En tant qu'utilisateur, je veux voir mon score final à la fin de la partie. | P1 |
| 013 | Rejouer | En tant qu'utilisateur, je veux pouvoir rejouer après avoir vu mon score final. | P1 |
| 014 | Musique et bruitages | En tant qu'utilisateur, je veux entendre de la musique et des bruitages. | P2 |
| 015 | Graphismes | En tant qu'utilisateur, je veux que le jeu soit agréable visuellement. | P2 |
| 016 | Modèles 3D | En tant qu'utilisateur, je veux que les modèles 3D soient de qualité. | P2 |
| 017 | Post-traitement | En tant qu'utilisateur, je veux que le jeu soit agréable visuellement grâce à un post-traitement. | P3 |
| 018 | Interface | En tant qu'utilisateur, je veux que l'interface soit intuitive. | P3 |

Une fois le backlog créé, j'ai créé un projet sur GitHub pour y mettre toutes les tâches à réaliser. J'ai commencé à créer des issues pour chaque tâche à réaliser.
Une fois toutes les tâches créées, je l'ai est converti en issues pour pouvoir les suivre plus facilement.

#### 9h

J'ai fini de créer toutes les tâches principales à réaliser. je vais maintenant commencer à les planifier dans un planning prévisionnel.

Mais avant ça, je vais ajouter des taches plus précises pour chaque tâche principale. Par exemple, pour la tâche `001 : Implémentation VR`, je vais ajouter des sous-tâches comme `001.1 : Ajout du pacjage XR` ou `001.2 : Ajout des contrôleurs`. Je vais aussi rajouter des tâches qui ne sont pas dans le backlog comme `Création du journal de bord` ou `Création de la documentation`.

Voici les tâches que j'ai ajoutées :

##### 000 : Préparation du projet

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 000.1 | Création du repository Git | Création du repository Git pour versionner le code | P1 |
| 000.2 | Création du journal de bord | Création du journal de bord pour suivre l'avancement du projet | P1 |
| 000.3 | Création de la documentation | Création de la documentation pour expliquer le projet | P1 |
| 000.4 | Planification | Planification du projet | P1 |
| 000.5 | Création du projet Unity | Création du projet Unity | P1 |

##### 001 : Implémentation VR

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 001.1 | Ajout du package XR | Ajout du package XR (Plugin provider : OpenXR) | P1 |
| 001.2 | Ajout Unity Input System | Ajout du package Unity Input System requis pour le package XR Interaction Toolkit | P1 |
| 001.3 | Ajout du package XR Interaction Toolkit | Ajout du package XR Interaction Toolkit | P1 |
| 001.4 | Ajout du système de déplacement | Ajout du système de déplacement pour pouvoir se déplacer dans le jeu | P1 |

##### 002 : Environnement 3D

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 002.1 | Création du jardin | Création du jardin en 3D de 2x2 mètres | P1 |
| 002.2 | Ajout des limites | Ajout des limites pour ne pas pouvoir sortir de la zone de jeu | P1 |
| 002.3 | Ajout des arbres et buissons | Ajout des arbres et des buissons dans le jardin (ce qui vont servir à générer les fruits plus tard) | P1 |

##### 003 : Main du joueur

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 001.1 | Ajout des contrôleurs | Ajout des contrôleurs pour pouvoir interagir avec le jeu | P1 |
| 001.2 | Importation des modèles de mains | Importation des modèles de mains pour les contrôleurs | P1 |
| 001.3 | Ajout du système d'intéraction | Ajout du système d'intéraction pour pouvoir intéragir avec les objets du jeu | P1 |

##### 004 : Arbres et buissons

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 004.1 | Recherche de modèles 3D | Recherche de modèles 3D d'arbres et de buissons | P1 |
| 004.2 | Importation des modèles 3D | Importation des modèles 3D d'arbres et de buissons dans le projet | P1 |
| 004.3 | Placement des arbres et buissons | Placement des arbres et des buissons dans le jardin | P1 |

##### 005 : Génération de fruits

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 005.1 | Conception du système de fruits | Conception du système de génération de fruits + UML | P1 |
| 005.2 | Implémentation du système de fruits | Implémentation du système de génération de fruits | P1 |
| 005.3 | Test du système de fruits | Test du système de génération de fruits | P1 |

##### 006 : Ramassage de fruits

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 006.1 | Utilisation du système d'intéraction et celui des fruits | Utilisation le système d'intéraction pour ramasser les fruits | P1 |
| 006.2 | Test du système de ramassage | Test du système de ramassage des fruits | P1 |

##### 007 : Disparition des fruits

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 007.1 | Rajout d'un timer sur les fruits | Rajout d'un timer sur les fruits pour les faire disparaître après quelques secondes | P1 |
| 007.2 | Test du système de disparition | Test du système de disparition des fruits | P1 |
| 007.3 | Optimisation du système | Optimisation du système de disparition des fruits en utilisant du pooling | P2 |

##### 008 : Compteur de points

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 008.1 | Création du système de points | Création du système de points pour compter les points | P1 |
| 008.2 | Test du système de points | Test du système de points | P1 |

##### 009 : Visualisation des points

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 009.1 | Création de l'interface | Création de l'interface pour afficher les points | P1 |
| 009.2 | Test de l'interface | Test de l'interface pour afficher les points | P1 |

##### 010 : Compteur de temps

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 010.1 | Création du timer | Création du timer de 30 secondes pour la partie | P1 |
| 010.2 | Test du timer | Test du timer de 30 secondes | P1 |
| 010.3 | Affichage du timer | Rajout de l'affichage du timer à l'interface | P1 |

##### 011 : Fin de partie

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 011.1 | Fin de partie | Fin de partie après 30 secondes | P1 |
| 011.2 | Test de la fin de partie | Test de la fin de partie après 30 secondes | P1 |

##### 012 : Score final

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 012.1 | Affichage du score final | Affichage du score final à la fin de la partie | P1 |
| 012.2 | Test de l'affichage du score final | Test de l'affichage du score final à la fin de la partie | P1 |

##### 013 : Rejouer

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 013.1 | Création du système de chargement de scene | Création du système de chargement de scene pour pouvoir rejouer | P1 |
| 013.2 | Test du système de chargement de scene | Test du système de chargement de scene pour pouvoir rejouer | P1 |
| 013.3 | Implémentation du système dans l'interface | Implémentation du système de chargement de scene dans l'interface (bouton) | P2 |
| 013.3 | Optimisation du système | Optimisation du système de chargement de scene pour qu'il soit asynchrone | P2 |
| 013.4 | Ajout d'un écran de chargement | Ajout d'un écran de chargement pour le chargement de la scene | P3 |
| 013.5 | Test de l'écran de chargement | Test de l'écran de chargement pour le chargement de la scene | P3 |

##### 014 : Musique et bruitages

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 014.1 | Recherche de musiques et bruitages | Recherche de musiques et bruitages pour le jeu | P2 |
| 014.2 | Importation des musiques et bruitages | Importation des musiques et bruitages dans le projet | P2 |
| 014.3 | Ajout des musiques et bruitages | Ajout des musiques et bruitages dans le jeu | P2 |

##### 015 : Graphismes

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 015.1 | Recherche d'une identité visuelle | Recherche d'une identité visuelle pour le jeu | P2 |
| 015.2 | Elaboration de la palette de couleurs | Elaboration de la palette de couleurs pour le jeu | P2 |

##### 016 : Modèles 3D

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 016.1 | Recherche de modèles 3D | Recherche de modèles 3D pour le jeu | P2 |
| 016.2 | Importation des modèles 3D | Importation des modèles 3D dans le projet | P2 |
| 016.3 | Ajout des modèles 3D | Ajout des modèles 3D dans le jeu | P2 |

##### 017 : Post-traitement

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 017.1 | Ajout d'un post-traitement | Ajout d'un post-traitement pour améliorer les graphismes | P3 |

##### 018 : Interface

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 018.1 | Conception de l'interface | Conception de l'interface pour qu'elle soit intuitive et en harmonie avec l'idée visuelle | P3 |
| 018.2 | Implémentation de l'interface | Implémentation de l'interface dans le jeu | P3 |

Je vais les ajouter dans le fichier backlog pour pouvoir les suivre plus facilement meme si ce ne sont pas des véritables user stories.
J'ai également ajouté toutes les tâches dans le projet GitHub et dans le planning prévisionnel.

#### 13h

J'ai fini de planifier toutes les tâches dans le planning prévisionnel. J'ai également fini de créer toutes les tâches dans le projet GitHub. Je vais maintenant commencer à travailler sur la première tâche.

Je vais commencer par la creation du projet Unity. Je vais créer un dossier `FruitPower` dans lequel je vais créer un projet Unity.

Une fois le projet créé, je fais un premier commit pour sauvegarder l'état actuel du projet.
J'en profite pour faire une sauvegarde sur mon disque dur externe (publier sur le drive est un peu long je pense que je ne vais que le faire une fois par jour).

Je vais commencer par l'implémentation de la VR. Je vais commencer par ajouter le package XR, puis le package Unity Input System et enfin le package XR Interaction Toolkit.

Je vais commencer par créer une branche pour chaque tâche que je vais réaliser. Je vais commencer par créer une branche `001-implementation-vr` pour la première tâche.