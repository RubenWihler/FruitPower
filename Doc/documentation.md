# Documentation Technique - FruitPower

## Table des versions

| Version | Date | Auteur | Changements |
| ------- | ---- | ------ | ----------- |
| 1.0 | 2023-11-09 | Ruben Wihler | version finale |

## Table des matières

[TOC]

## Introduction

Ce document est un rapport présentant différents aspects de la conception du projet FruitPower. Ce projet a été réalisé dans le cadre du Travail pratique individuel (TPI) durant la session de mai 2024. Il a pour but de valider mes compétences acquises pendant la formation Informaticien CFC dispensée à l’école d’informatique du CFPT au Petit-Lancy. FruitPower est un jeux vidéo utilisant la réalité virtuelle. Il a été développé en C# avec le moteur de jeu Unity.

## Rappel de l’énoncé

>Les informations sont extraites du cahier des charges du TPI.

### Organisation

| Elève | Maître d’apprentissage | Experts |
| ----- | --------------------- | ------- |
| Ruben Wihler | M. J. Aliprendi | Mickaël Strazzeri, Yvan Poulin |

### Livrables

Pour les experts et le maître d’apprentissage :

- Rapport de projet
- Manuel utilisateur
- Résumé du rapport du TPI
- Journal de travail
- Version compilée et sources du projet Unity C#


### Matériel et logiciels à disposition

- Un PC standard école, 2 écrans
- Windows 10
- Visual studio code
- Visual studio 2022
- Unity 2022.3.12f1
- Suite Office

### Méthodologie

#### Méthode en 6 étapes

##### 1. S’informer

Lors de cette étape, j’ai dû m’informer sur le cahier des charges, l’analyser en profondeur pour bien comprendre toutes les fonctionnalités demandées. C’est également durant cette étape que j’ai demandé des questions/informations à M.Aliprandi pour tout ce qui concerne mes différentes incompréhensions. A chaque fois que je commençais une storie je m’informais en regardant le cahier des charges.

##### 2. Planifier

Dans cette étape, j’ai créé un planning prévisionnel pour pouvoir m’organiser et savoir ce que je dois faire et quand. Pour faire ce planning, j’ai dû découper le travail en plusieurs tâches. Pour ces tâches, j’ai décidé de les mettre sous la forme de user stories. C’est une description simple de ce que l’utilisateur a besoin pour savoir les différentes fonctionnalités à développer. J’ai décidé de mettre aussi en place la méthode MoSCoW qui attribue des priorités sur les tâches afin de pouvoir s’attarder sur ce qui est prioritaire. Les niveaux de priorités sont :

- P1 Must
- P2 Should
- P3 Could

Toutes ces stories sont mises dans un product backlog. J’ai fait un planning effectif pour pouvoir comparer mon avancée avec le planning prévisionnel.

##### 3. Décider

Lors de mon projet, j’ai eu plusieurs décisions importantes à prendre. Toutes les décisions que je trouvais importantes et pertinentes, je les mettais dans le journal de bord et j’expliquais pourquoi j’ai choisi de faire comme ça.

##### 4. Réaliser

Une fois les décisions prises, je pouvais commencer à réaliser, soit l’implémentation dans le code, soit la rédaction dans la documentation.

##### 5. Contrôler

tout de suite plusieurs fois. Quand je rajoutais une fonction, je testais également l’autre pour voir s'il y avait pas de régression. Une fois que je finissais d’implémenter un système, je la testais avec des test unitaires et foncitonnels pour voir si tout fonctionnait correctement. (Unity Test Framework)

##### 6. Evaluer

Cette étape je la fais dans mon bilan dans mon journal de bord. Ici on liste les réussites, les difficultés, les améliorations ainsi que les décisions. J'ai aussi mis le resultats de mes tests.

#### Méthode Agile

Durant l’élaboration de mon projet, je n’ai pas seulement appliqué la méthode en 6 étapes mais également celle de la méthode Agile. Je me suis fixé tous les jours des objectifs dans le journal de bord que je devais atteindre en fin de journée.

Le backlog fait également partie de la méthodologie agile puisque j’ai fait des stories qui correspondent à de petits objectifs à atteindre pour arriver à l’objectif final. Les objectifs sont atteints quand les cas de tests sont fonctionnels et ainsi pouvoir passer au suivant.

### Sauvegardes et versionning

Pour versionner mon projet, j’ai utilisé Git. J’ai créé un dépôt sur GitHub pour pouvoir sauvegarder mon code source et le partager avec mon maître d’apprentissage et les experts.

Concernant mon organisation des sauvegardes, j’ai décidé d'adopter la méthode 3-2-1. Cela signifie que je garde 3 copies de mes données, sur 2 supports différents, dont 1 hors site. J’ai donc sauvegardé mon code source sur GitHub, sur un disque dur externe et sur un google drive.

## Planification

J'ai fais un planning prévisionnel pour pouvoir m’organiser et savoir ce que je dois faire en découpant les user stories en plusieurs tâches. Pour ces tâches, j’ai décidé de les mettre sous la forme de user stories. C’est une description simple de ce que l’utilisateur a besoin pour savoir les différentes fonctionnalités à développer.

### Planning prévisionnel et effectif

Le planning si dessous contient la planification prévisionnelle et effectif du projet.

![Planning prévisionnel](./images/planning-previsionnel.png)


### Product backlog

Les user stories sont des descriptions simples de ce que l'utilisateur a besoin pour savoir les différentes fonctionnalités à développer. Ces dernières sont mises dans un product backlog.

>Pour rappelle, les niveaux de priorités sont :  
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

### Tâches techniques

Les tâches techniques sont des tâches plus précises qui permettent de réaliser les user stories. Elles sont plus techniques et détaillées et ne sont pas destinées au client. Nous avons décidé de les formuler sous la forme de petites tâches issues des user stories.

#### 000 : Préparation du projet

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 000.1 | Création du repository Git | Création du repository Git pour versionner le code | P1 |
| 000.2 | Création du journal de bord | Création du journal de bord pour suivre l'avancement du projet | P1 |
| 000.3 | Création de la documentation | Création de la documentation pour expliquer le projet | P1 |
| 000.4 | Planification | Planification du projet | P1 |
| 000.5 | Création du projet Unity | Création du projet Unity | P1 |

#### 001 : Implémentation VR

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 001.1 | Ajout du package XR | Ajout du package XR (Plugin provider : OpenXR) | P1 |
| 001.2 | Ajout Unity Input System | Ajout du package Unity Input System requis pour le package XR Interaction Toolkit | P1 |
| 001.3 | Ajout du package XR Interaction Toolkit | Ajout du package XR Interaction Toolkit | P1 |
| 001.4 | Ajout du système de déplacement | Ajout du système de déplacement pour pouvoir se déplacer dans le jeu | P1 |

#### 002 : Environnement 3D

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 002.1 | Création du jardin | Création du jardin en 3D de 2x2 mètres | P1 |
| 002.2 | Ajout des limites | Ajout des limites pour ne pas pouvoir sortir de la zone de jeu | P1 |
| 002.3 | Ajout des arbres et buissons | Ajout des arbres et des buissons dans le jardin (ce qui vont servir à générer les fruits plus tard) | P1 |

#### 003 : Main du joueur

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 001.1 | Ajout des contrôleurs | Ajout des contrôleurs pour pouvoir interagir avec le jeu | P1 |
| 001.2 | Importation des modèles de mains | Importation des modèles de mains pour les contrôleurs | P1 |
| 001.3 | Ajout du système d'intéraction | Ajout du système d'intéraction pour pouvoir intéragir avec les objets du jeu | P1 |

#### 004 : Arbres et buissons

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 004.1 | Recherche de modèles 3D | Recherche de modèles 3D d'arbres et de buissons | P1 |
| 004.2 | Importation des modèles 3D | Importation des modèles 3D d'arbres et de buissons dans le projet | P1 |
| 004.3 | Placement des arbres et buissons | Placement des arbres et des buissons dans le jardin | P1 |

#### 005 : Génération de fruits

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 005.1 | Conception du système de fruits | Conception du système de génération de fruits + UML | P1 |
| 005.2 | Implémentation du système de fruits | Implémentation du système de génération de fruits | P1 |
| 005.3 | Test du système de fruits | Test du système de génération de fruits | P1 |

#### 006 : Ramassage de fruits

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 006.1 | Utilisation du système d'intéraction et celui des fruits | Utilisation le système d'intéraction pour ramasser les fruits | P1 |
| 006.2 | Test du système de ramassage | Test du système de ramassage des fruits | P1 |

#### 007 : Disparition des fruits

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 007.1 | Rajout d'un timer sur les fruits | Rajout d'un timer sur les fruits pour les faire disparaître après quelques secondes | P1 |
| 007.2 | Test du système de disparition | Test du système de disparition des fruits | P1 |
| 007.3 | Optimisation du système | Optimisation du système de disparition des fruits en utilisant du pooling | P2 |

#### 008 : Compteur de points

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 008.1 | Création du système de points | Création du système de points pour compter les points | P1 |
| 008.2 | Test du système de points | Test du système de points | P1 |

#### 009 : Visualisation des points

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 009.1 | Création de l'interface | Création de l'interface pour afficher les points | P1 |
| 009.2 | Test de l'interface | Test de l'interface pour afficher les points | P1 |

#### 010 : Compteur de temps

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 010.1 | Création du timer | Création du timer de 30 secondes pour la partie | P1 |
| 010.2 | Test du timer | Test du timer de 30 secondes | P1 |
| 010.3 | Affichage du timer | Rajout de l'affichage du timer à l'interface | P1 |

#### 011 : Fin de partie

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 011.1 | Fin de partie | Fin de partie après 30 secondes | P1 |
| 011.2 | Test de la fin de partie | Test de la fin de partie après 30 secondes | P1 |

#### 012 : Score final

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 012.1 | Affichage du score final | Affichage du score final à la fin de la partie | P1 |
| 012.2 | Test de l'affichage du score final | Test de l'affichage du score final à la fin de la partie | P1 |

#### 013 : Rejouer

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 013.1 | Création du système de chargement de scene | Création du système de chargement de scene pour pouvoir rejouer | P1 |
| 013.2 | Test du système de chargement de scene | Test du système de chargement de scene pour pouvoir rejouer | P1 |
| 013.3 | Implémentation du système dans l'interface | Implémentation du système de chargement de scene dans l'interface (bouton) | P2 |
| 013.3 | Optimisation du système | Optimisation du système de chargement de scene pour qu'il soit asynchrone | P2 |
| 013.4 | Ajout d'un écran de chargement | Ajout d'un écran de chargement pour le chargement de la scene | P3 |
| 013.5 | Test de l'écran de chargement | Test de l'écran de chargement pour le chargement de la scene | P3 |

#### 014 : Musique et bruitages

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 014.1 | Recherche de musiques et bruitages | Recherche de musiques et bruitages pour le jeu | P2 |
| 014.2 | Importation des musiques et bruitages | Importation des musiques et bruitages dans le projet | P2 |
| 014.3 | Ajout des musiques et bruitages | Ajout des musiques et bruitages dans le jeu | P2 |

#### 015 : Graphismes

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 015.1 | Recherche d'une identité visuelle | Recherche d'une identité visuelle pour le jeu | P2 |
| 015.2 | Elaboration de la palette de couleurs | Elaboration de la palette de couleurs pour le jeu | P2 |

#### 016 : Modèles 3D

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 016.1 | Recherche de modèles 3D | Recherche de modèles 3D pour le jeu | P2 |
| 016.2 | Importation des modèles 3D | Importation des modèles 3D dans le projet | P2 |
| 016.3 | Ajout des modèles 3D | Ajout des modèles 3D dans le jeu | P2 |

#### 017 : Post-traitement

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 017.1 | Ajout d'un post-traitement | Ajout d'un post-traitement pour améliorer les graphismes | P3 |

#### 018 : Interface

| ID | Nom | Description | Priorité |
|----|-----|-------------|----------|
| 018.1 | Conception de l'interface | Conception de l'interface pour qu'elle soit intuitive et en harmonie avec l'idée visuelle | P3 |
| 018.2 | Implémentation de l'interface | Implémentation de l'interface dans le jeu | P3 |

---

## Analyse des fonctionnalités majeures

Les fonctionnalités majeures du projet sont tirées du cahier des charges.

- **Une partie dure 30 secondes**
- **Le score est affiché à la fin de la partie**
- **Un bouton est présent pour recommencer après la fin de la partie**
- **Un fruit ramassé avec la télécommande donne 1 point** : etendu à plusieurs types de fruits (en accord avec le maitre d'apprentissage)
- **Le jardin contient des arbres et buissons (par exemple une dizaine)** : 13 buissons et 4 arbres
- **La génération des fruits est aléatoire dans un temps défini** : fruits générés aléatoirement sur les buissons et les arbres, temps équivalent pour chaque partie par soucis d'équité entre les joueurs (différent pour chaque type de fruit)
- **Les fruits disparaissent après quelques secondes s'ils ne sont pas ramassés (par exemple 3 secondes)** : Différent pour chaque type de fruit (entre 2 et 3 secondes).
- **Le jardin est clôturé ou a des limites visuelles** : murs autour du jardin.
- **Fruits ramassés avec la télécommande et mis dans un panier** : fruits ramassés avec les contrôleurs et mis dans un panier statique pour gagner des points.
- **Musique et bruitages** : musique et bruitages présents dans le projet. (details dans la partie son) Les musique et leurs auteurs sont crédités dans [la partie crédits du jeu](#credits).
- **Eléments 2D/3D gratuits** : tous les assets utilisés sont gratuits et leurs auteurs sont crédités dans [la partie crédits du jeu](#credits).

---

## Analyse organique

Pour faciliter la partie conception ainsi que la partie implémentation, le projet a été divisé en plusieurs systèmes. Chaque système a une responsabilité bien définie et est plus ou moins indépendant des autres systèmes. Cela permet de faciliter la maintenance et l'évolution du projet.

### Informations générales

#### Assemblies et namespaces

Pour faciliter l'organisation du code, chaque système possède une définition d'assebly.

| Nom | Description | Chemin (racine du projet unity) |
|-----|-------------|--------|
| Scripts | Scripts généraux | Assets/Scripts/Scripts.asmdef |
| FruitSystem | Système de gestion des fruits | Assets/Scripts/FruitSystem/FruitSystem.asmdef |
| Inputs | Système de gestion des inputs | Assets/Scripts/Inputs/Inputs.asmdef |
| UISystem | Système de gestion de l'interface utilisateur | Assets/Scripts/UI/UISystem.asmdef |
| Audio | Système de gestion de l'audio | Assets/Scripts/Audio/Audio.asmdef |
| GameManagement | Système de gestion de la partie | Assets/Scripts/GameManagement/GameManagement.asmdef |

Dans la même optique, l'utilisation de namespaces a été privilégiée pour une meilleure organisation du code.

#### Conventions de nommage

Pour faciliter la lecture du code, des conventions de nommage ont été mises en place. Voici les conventions de nommage utilisées dans le projet (dans l'ordre)

- Namespace : PascalCase
- Enum : PascalCase
- Classes : PascalCase
- Interfaces : IPascalCase
- champs public : camelCase
- champs privé : _camelCase
- Propriétés : PascalCase
- Events : camelCase
- Méthodes : PascalCase

#### Héritage et composition

Pour faciliter la maintenance du projet la composition a été privilégiée à l'héritage. Cela permet de réduire les dépendances entre les classes et de faciliter la maintenance du code. L'héritage est utilisé uniquement pour les classes qui ont une relation de parenté (ex : MonoBehaviour).

Dans cette optique de minimiser les dépendances, l'abstraction de comportement a été réalisée à l'aide de delegates passés en constructeur. Nous aurions pu utiliser des interfaces mais cela aurait augmenté la complexité du code pour un gain de flexibilité minime (surtout vu la nature simpliste du projet).

#### Design patterns

Une combinaison de plusieurs design patterns a été utilisée pour réaliser un code propre et maintenable. Nous avons par exemple utilisé le pattern Observer pour la gestion de la partie et le pattern Pool pour la gestion des fruits.

Le pattern Singleton a aussi beaucoup été utilisé pour les classes qui ne doivent être instanciés qu'une seule fois dans le jeu et qui doivent être accessibles de partout (GameManager, FruitManager, etc). Nous ne pouvons pas utiliser de classes statiques car ces dernières ne peuvent pas être un component Unity(doit hériter de MonoBehaviour).

#### Commentaires de code

Pour faciliter la lecture du code, des commentaires ont été ajoutés dans le code. Ces commentaires permettent de comprendre le code plus facilement et de savoir ce que fait chaque partie du code. Les commentaires sont écrits en français et utilisent les summary de C#.

#### Inspecteur Unity

Pour faciliter l'utilisation des scripts dans Unity, des attributs ont été ajoutés aux champs des classes pour les rendre visibles dans l'inspecteur Unity. Cela permet de modifier les valeurs des champs directement dans l'inspecteur sans avoir à modifier le code.

Nous n'avons pas eu besoin de créer des éditeurs personnalisés pour les scripts car ils sont simples et ne nécessitent pas de modifications particulières dans l'inspecteur. Nous avons simplement utilisé les attributs `Header` et `Tooltip` pour rendre l'inspecteur plus lisible.

> Il est important de noter que les attributs `Tooltip` sont affichés dans Visual Studio comme pour les summary de C#.

Etant donné que les variables sont en anglais, nous avons mis les `Header` en anglais pour que l'inspecteur soit plus lisible. En revanche, comme pour les commentaires de code, les `Header` sont en français.

Pour garder une ogranisation harmonieuse dans l'inspecteur, nous avons utilisé les mêmes `Header` pour séparer les différentes sections dans toutes les classes :

- `Settings` : Pour les paramètres du script.
- `References` : Pour les références aux autres composants.

> D'autres `Header` plus spécifiques ont été utilisés en fonction des besoins du script.

### Gestions de la réalité virtuelle

La gestion de la réalité virtuelle est un des points clés du projet. Elle permet au joueur d'interagir avec le jeu en utilisant un casque de réalité virtuelle et ses contrôleurs. Pour cela, nous avons utilisé le package XR d'Unity qui permet de gérer la réalité virtuelle de manière simple et efficace. Nous avons également utilisé le package XR Interaction Toolkit qui permet de gérer l'interaction avec les objets du jeu.
Pour gagner du temps, nous avons utiliser le sample de l'XR Interaction Toolkit pour la gestion des contrôleurs. Ce dernier nous a permis d'avoir tout de suite les InputsActions et les interactions de base (grab, select, etc).

#### Mains du joueur

Pour les main du joueur, nous avons utilisé les modèles de mains donnés dans une séries de tutoriels de Unity. Ces modèles sont des modèles de mains de base qui sont deja animés. Nous avons simplement suivi le tutoriel pour les importer dans le projet et les utiliser.

> Référence de la vidéo : [How to Make a VR Game in Unity 2022 - PART 2 - INPUT and HAND PRESENCE](https://www.youtube.com/watch?v=8PCNNro7Rt0)

La seule classe que nous avons dû implémenter est lui aussi donné dans le tutoriel. Il s'agit de la classe `HandController` qui permet de faire le lien entre les contrôleurs et l'animator des mains.

#### Déplacement du joueur

Les déplacements du joueur sont très simples étant donné que le joueur ne peut pas se déplacer dans l'environnement avec les contrôleurs. Il ne peut que se déplacer dans un rayon de 2 mètres autour de lui en marchant dans la réalité. Pour cela, nous avons utilisé les composants `LocomotionSystem`, `ContinuousMoveProvider` et `CharacterControllerDriver` du package XR Interaction Toolkit.

#### Utilisation dans Unity

##### XR Plugin Management

Pour utiliser la réalité virtuelle dans Unity, il faut ajouter le package XR dans le projet. Pour cela, il faut aller dans le menu `Window` -> `Package Manager` et chercher le package `XR Plugin Management`. Il faut ensuite l'installer. Une fois le package installé, il faut aller dans `Edit` -> `Project Settings` -> `XR Plugin Management` et activer le plugin `OpenXR`.  

##### XR Interaction Toolkit

Pour utiliser le package XR Interaction Toolkit, il faut ajouter le package dans le projet. Pour cela, il faut aller dans le menu `Window` -> `Package Manager` et cliquer sur le `+` en haut à gauche > `Add package from name` et entrer `com.unity.xr.interaction.toolkit`. Il faut ensuite l'installer. Pour installer le sample `Started Assets`, il faut aller dans Package Manager > XR Interaction Toolkit > Samples > Started Assets > Import.

##### Utilisation dans la scène

L'utilisation de la réalité virtuelle dans la scène est très simple. Voici la hiérarchie du joueur dans la scène :

![VR Player](./img/vr_player_structure.jpg)

###### XR Player

C'est le GameObject qui représente le joueur dans la scène.

Voici la vue de l'inspector du XR Player :

![XR Player](./img/xr_player_inspector.jpg)

Voici la liste des composants du XR Player :

- `XROrigin` : Composant qui permet de définir l'origine du joueur dans la scène.
- `InputActionManager` : Composant qui permet de gérer les actions des contrôleurs.
- `LocomotionSystem` : Composant qui permet de gérer le déplacement du joueur.
- `ContinuousMoveProvider` : Composant qui permet de gérer le déplacement du joueur (aucun référence au Move Action car le joueur ne peut pas se déplacer avec les contrôleurs).
- `CharacterControllerDriver` : Composant qui permet de gérer le déplacement du joueur.
- `CharacterController` : Composant qui permet de gérer le déplacement du joueur (n'est pas propre à la VR).

###### LeftHand et RightHand

Les mains du joueur sont des GameObjects enfants du XR Player. Voici la vue de l'inspector d'une main :

![Main du joueur](./img/hands_inspector.jpg)

Voici la liste des composants d'une main :

- `XRController` : Composant qui permet de gérer le contrôleur.
- `XRDirectInteractor` : Composant qui permet de gérer l'intéraction avec les objets (les atrapper, les lancer, etc).
- `SphereCollider` : Composant qui permet de gérer la zone de détection des objets. (mis en mode trigger pour ne pas bloquer les objets).

En plus de ces composants, il y a un GameObject enfant de la main qui contient le modèle de la main. Ce GameObject est animé par l'animator de la main.
Il possède également un `HandController` ([HandController](#handcontroller)) qui permet de faire le lien entre les contrôleurs et l'animator de la main.

### Environnement 3D

L'environnement 3D est un jardin clos de 2m x 2m. Il contient des arbres et des buissons qui servent à générer les fruits, des murs pour délimiter la zone de jeu et un sol pour marcher. La scène est composée de plusieurs GameObjects qui sont organisés de manière à ce que le joueur puisse se déplacer librement dans la zone de jeu.

![Environnement 3D 1](./img/env_03.jpg)

Un panier est également présent dans la scène pour que le joueur puisse y mettre les fruits qu'il a ramassé pour gagner des points. Ce dernier est en hauteur pour que le joueur puisse y mettre les fruits facilement qu'il mesure 60cm ou 1m90. Il est lègèrement éclairé pour le mettre en valeur et soit perçu comme un élément important.

Une radio est également présente dans la scène pour que le joueur puisse entendre de la musique. Elle est placée a coté du panier et est également éclairée (moins que le panier pour ne pas trop attirer l'attention).

Etant donné que ce projet va être utilisé dans le cadre des portes ouvertes du CFPT, les joueurs devront comprendre rapidement comment jouer. Pour cela, un texte est affiché sur un mur pour expliquer qu'il faut ramasser les fruits et les mettre dans le panier pour gagner des points.

Des élements de décorations sont également présents dans la scène pour rendre le jardin plus vivant. Il y a des fleurs, des cailloux, des champignons, des fougères, etc.

![Environnement 3D 2](./img/env_02.jpg)

L'ambiance de la scène est très importante pour que le joueur se sente bien dans le jeu. Une ambiance de coucher de soleil faisant contraster ses couleurs chaudes avec les couleurs vives des éléments du jardin permet de donner une ambiance chaleureuse ainsi que de mettre en valeur les fruits et autres éléments clés du jeu.

![Environnement 3D 3](./img/env_04.jpg)

---

### Gestion des parties

Le système de gestion de partie est relativement simple. C'est un singleton qui utilise un pattern d'observer pour notifier les autres systèmes des différents évènements de la partie. Ce système est composé de plusieurs classes qui gèrent les différents aspects de la partie (score, timer, statistiques, etc).

Le déroulement d'une partie est le suivant :

1. Le joueur appuie sur le bouton de démarrage de la partie.
2. Un compte à rebours de 3 secondes est lancé pour laisser le temps au joueur de se préparer.
3. La partie commence et les fruits commencent à apparaître.
4. Le joueur doit ramasser les fruits et les mettre dans le panier pour gagner des points.
5. Après 30 secondes, la partie se termine et le score final est affiché.
6. Le joueur peut rejouer en appuyant sur un bouton.

#### Classes du système de gestion de partie

![uml](./Uml/game_management_system.png)

##### GameManager

Le `GameManager` est la classe principale du système de gestion de partie. C'est un singleton qui centralise toutes les opérations sur la partie. Utilisant un pattern d'observer, il notifie les autres systèmes de l'état de la partie.

##### GameOption

La structure `GameOption` est une structure qui contient les options de la partie. Elle est utilisée par le `GameManager` pour modifier les options de la partie dans l'éditeur Unity et en cours d'exécution (bien que cela ne soit pas nécessaire car aucun menu d'options n'est implémenté).

Elle contient les champs suivants :

- `public float gameDuration` : La durée de la partie en secondes.
- `public ushort spawnerRate` : Le nombre d'apparition de chaque type de fruits par seconde.
- `public uint countdownDuration` : La durée du compte à rebours du début de partie en secondes.

##### GameScore

La classe `GameScore` est une classe qui contient le score du joueur. Elle est utilisée par le `GameManager` pour gérer le score du joueur.

##### GameTimer

La classe `GameTimer` contient le timer de la partie. Elle utilise une coroutine pour le timer. Elle contient 3 Action (données en paramètre du constructeur) qui sont appelées à différents moments du timer. (début, 80% du timer, fin). Ces actions permettent d'abstraire le comportement sans avoir de dépendances entre les classes.

##### GameStats

La classe `GameStats` est une classe qui s'occupe de stocker les statistiques de la partie (pour le moment, uniquement les fruits ramassés). Elle est utilisée par le `GameManager`.

---

### Gestion des fruits

Le système de gestion des fruits est un des systèmes les plus importants du projet. Il est responsable de la génération des fruits, de leur apparition, de leur disparition, de leur ramassage et de leur comptage.

Avant d'aborder les détails du système, il est important de comprendre comment les fruits sont générés. Premièrement, il existe plusieur type de fruits (pommes, fraises, myrtilles). Chaque type de fruit a des caractéristiques différentes (points donnés, vitesse d'apparition, etc). Deuxièmement, les fruits apparaissent sur des arbres ou des buissons. Les pommes apparaissent sur les arbres, les fraises et les myrtilles apparaissent sur les buissons.

Chaque fruits ont un temps de vie configurable. Si le joueur ne les ramasse pas avant la fin de leur temps de vie, ils disparaissent. Quand le joueur ramasse un fruit, sa durée de vie est stoppé et ne disparaît pas. C'est seulement quand le joueur lache le fruit qu'il reprend sa durée de vie (qui est remise à zéro). Une fois que le fruit est mis dans le panier des points sont ajoutés au score du joueur.

![uml sequence fruit generation](./Uml/fruit_generation_sequence.svg)

Globalement, le système est composé d'une classe [FruitManager](#fruitmanager) qui centralise toutes les opérations sur les fruits. Ce dernier utilise un [FruitPooler](#fruitpooler) pour gérer les fruits en pool. Il permet de réutiliser les fruits déjà instanciés pour éviter de les créer et de les détruire à chaque fois, cela permet un gain de performance non négligeable.

![fruit manager inspector](./img/fruit_manager_inspector.jpg)

La classe [Fruit](#fruit) représente un fruit dans le jeu. Il contient les informations sur le fruit (type, points, etc) et les méthodes pour le ramasser et le détruire.

Dans l'éditeur Unity, un fruit est représenté par un prefab qui contient un rigidbody, un composant XR Grab Interactable, une source audio et la classe Fruit.

![apple inspector](./img/apple_inspector.jpg)

Pour regrouper et donner un accès facile aux données de chaque fruit, une strucure [FruitTypeData](#fruittypedata) est utilisée. Elle contient les informations sur le fruit (type, points, etc). Cette dernière est utilisée dans [FruitTypesDatas](#fruittypesdatas) une classe héritant de ScriptableObject qui permet de stocker les données des fruits dans l'éditeur Unity.

![Fruit Types Datas Inspector](./img/fruittypesdatas_inspector.jpg)

Un [FruitSpawnerManager](#fruitspawnermanager) est utilisé pour gérer les [FruitSpawner](#fruitspawner). C'est sur ces derniers que la position des fruits est définie. Ils sont placés sur les arbres et les buissons pour que les fruits apparaissent à ces endroits.

![fruit spawners](./img/fruit_spawners.jpg)

> les points rouge représentent les spawners de pommes, les verts les fraises et les bleus les myrtilles.

#### Classes du système de fruit

![fruit system uml](./Uml/fruit_system.png)

> Ce diagramme UML ne contient pas toutes le association entre les classes car l'outil de Visual Studio ne permet pas de visualiser les association de type générique. (par exemple, la classe FruitPooler contient un dictionnaire de FruitPoolData qui n'est pas sous forme de flèche dans le diagramme).

##### FruitManager

Le `FruitManager` est la classe principale du système de gestion des fruits. Elle est responsable a haut niveau de toutes les opérations sur les fruits. Elle implémente un pattern singleton pour donner un accès facile aux autres classes du système ainsi qu'aux autres systèmes.

Cette classe utilise un [FruitPooler](#fruitpooler) pour gérer les fruits en pool. Un [FruitSpawnerManager](#fruitspawnermanager) est également utilisé pour gérer les [FruitSpawner](#fruitspawner).

Elle contient une référence au [FruitTypesDatas](#fruittypesdatas) qui contient les données des fruits.
Grâce à la methode `public static GetFruitTypeData(string fruitId)` il est possible de récupérer les données d'un fruit en donnant son id. Cela permet de facilement accéder a ces données depuis d'autres systèmes (par exemple, pour afficher le nom des fruits ramassés dans l'interface de fin de partie).

##### FruitPooler

Le `FruitPooler` est une classe qui gère les fruits en pool. Elle permet de réutiliser les fruits déjà instanciés pour éviter de les créer et de les détruire à chaque fois, cela permet un gain de performance non négligeable.

Son fonctionnement est simple. Au démarrage de la partie, elle instancie un nombre de fruits défini dans l'éditeur Unity. Ces fruits sont ensuite désactivés et organisés dans un dictionaire qui contient l'id du type de fruit et une queue de fruits. Quand un fruit est ramassé, il est désactivé et remis dans la queue. Quand un fruit doit apparaître, il est récupéré de la queue et activé. Si la queue est vide, un nouveau fruit est instancié.

Afin de minimiser un maximum les dépendances entre les classes, l'opération d'instanciation des fruits est passée en paramètre du constructeur de la classe sous la forme d'une `Func<Func<ulong, Fruit>, Fruit>`.

La liste des données nécessaires pour le pooling des fruits est passée en paramètre du constructeur de la classe sous la forme d'un `FruitPoolData[]`.

##### FruitPoolData

La structure `FruitPoolData` est une structure qui contient les données nécessaires pour le pooling des fruits. Elle est utilisée par le [FruitPooler](#fruitpooler) pour instancier les fruits.

Elle contient les champs suivants :

- `string typeId` : l'identifiant du type de fruit.
- `GameObject prefab` : le prefab du fruit.
- `ushort poolSize` : la taille du pool.

##### Fruit

Un `Fruit` représente un fruit dans le jeu. Cette classe hérite de `MonoBehaviour`. Ce composant permet de gérer les interactions du joueur avec le fruit (ramassage), gérer sa durée de vie, jouer les différents sons du fruit (apparition, ramassage, collision).

Un fruit peut se trouver dans 3 états différents, représentés par l'énumération [FruitState](#fruitstate).

Quand un fruit apparaît, il est attaché à un [FruitSpawner](#fruitspawner) - sa position est définie par le spawner et la gravité du fruit est désactivée(état `Grabbed`). Si le joueur ne le ramasse pas avant la fin de sa durée de vie, il disparaît et est mis dans l'état `Innactive`.
Quand le joueur le ramasse, la gravité est activée et le fruit suit le contrôleur du joueur. Si le joueur le lâche, le fruit est remis dans l'état `Neutral`.

##### FruitState

L'énumération `FruitState` représente l'état d'un fruit. Un fruit peut se trouver dans 3 états différents :

- `Innactive` : Le fruit est désactivé.
- `Attached` : Le fruit est attaché à un [FruitSpawner](#fruitspawner).
- `Neutral` : Le fruit est actif et peut être ramassé par le joueur. (la gravité est activée).
- `Grabbed` : Le fruit est ramassé par le joueur et suit le contrôleur.

##### FruitTypeData

La structure `FruitTypeData` est une structure qui contient les données d'un type de fruit. Elle est dans un [FruitTypesDatas](#fruittypesdatas) qui contient les données de tous les types de fruits.

Elle contient les champs suivants :

- `fruitId` : l'identifiant du fruit.
- `fruitName` : le nom du fruit.
- `points` : le nombre de points donné par le fruit.
- `lifeTime` : la durée de vie du fruit.

##### FruitTypesDatas

La classe `FruitTypesDatas` est une classe héritant de ScriptableObject qui permet de stocker les données des fruits dans l'éditeur Unity (dans un fichier .asset). Elle contient une liste de [FruitTypeData](#fruittypedata) qui contient les données de chaque type de fruit.

##### FruitSpawner

Un `FruitSpawner` est une classe qui hérite de `MonoBehaviour` et est attachée à un GameObject.
Les `FruitSpawner` permettent de définir la position et la rotation sur laquelle les fruits apparaissent. Ils sont placés sur les arbres et les buissons pour que les fruits apparaissent à ces endroits.

![fruit spawner inspector](./img/fruit_spawner_inspector.jpg)

##### FruitSpawnerManager

Le `FruitSpawnerManager` est une classe qui gère les [FruitSpawner](#fruitspawner).Elle gère le spawn des fruits en utilisant des coroutine récursive.

Une liste de [FruitSpawner](#fruitspawner) est passée en paramètre du constructeur de la classe. Cette liste est utilisée pour gérer les spawners.

Encore une fois dans le but de minimiser les dépendances entre les classes, l'opération d'instantiation des fruits est passée en paramètre du constructeur de la classe sous la forme d'une `Func<string, Fruit>`. Pour récupérer tous les fruits une fonction de type `Func<List<Fruit>>` est passée aussi en paramètre du constructeur.

##### Basket

La classe `Basket` est une classe qui gère le panier. Elle hérite de `MonoBehaviour` et est attachée à un GameObject dans la scène. Ce composant est responsable de gérer les fruits qui sont mis dans le panier et de notifier le [GameManager](#gamemanager) des points gagnés.

Cela est réalisé en utilisant un box collider qui est un trigger. Quand un fruit entre en collision avec ce collider, la méthode `OnTriggerEnter` est appelée. Cette méthode vérifie si le fruit est un fruit et si oui, elle joue le son de ramassage, ajoute les points au score et désactive le fruit.

---

### Interface utilisateur

L'interface utilisateur est un élément important du projet. Elle permet au joueur de voir les informations de la partie (score, timer, etc) et d'interagir avec le jeu (bouton rejouer, bouton de credits, etc).

L'interface est divisée en plusieurs parties :

- Le menu de fin de partie : affiche le score final du joueur, les fruits ramassés, le bouton rejouer, le bouton de crédits et le bouton quitter. (afficher uniquement à la fin de la partie).
- Un HUD : affiche le score du joueur et le temps restant (afficher uniquement pendant la partie).
- Texts d'informations : affiche le compte a rebours du début de partie, et un text quand la partie est finie.
  
#### Menu de fin de partie

Le menu de fin de partie est affiché à la fin de la partie. Il affiche les informations suivantes :

- Le score final du joueur.
- Le nombre de fruits ramassés.
- Un bouton pour rejouer.
- Un bouton pour afficher les crédits.
- Un bouton pour quitter le jeu.

![end game menu](./img/ui_game_end.jpg)

Le canvas est un canvas de type `World Space` qui suit le regard du joueur ainsi que sa position. Contrairement au HUD, il ne suit pas la rotation en Y du joueur pour rester toujours face à lui. (si le joueur regarde en haut ou en bas, le menu reste à la même hauteur).

Les fruits ramassés sont affichés dans une liste avec le nom du fruit et la quantité ramassée. Une animation grossit les fruits quand ils apparaissent pour attirer l'attention du joueur.

En cliquant sur le bouton de crédits, une nouvelle fenêtre s'ouvre avec les crédits du jeu. Pour fermer cette fenêtre, il suffit de cliquer sur le bouton `Retour`.

![credits](./img/credits.jpg)

#### HUD

Le HUD est affiché pendant la partie. Il affiche les informations suivantes :

- Le score du joueur.
- Le temps restant.
  
![hud](./img/ui_hud.jpg)

Le canvas est un canvas de type `World Space` qui suit totalement le regard du joueur. Il est placé en haut de l'écran pour ne pas gêner la vue.

#### Texts d'informations

Cette partie de l'interface regroupe différents textes qui s'affichent à différents moments de la partie :

- Un texte qui affiche le compte à rebours du début de partie.
- Un texte qui affiche la fin de la partie.

![countdown text](./img/ui_countdown.jpg)

Une animation de fade in/out est utilisée pour afficher le compte à rebours. Chaques chiffres apparaissent un par un pour donner un effet de compte à rebours.

![end game text](./img/ui_game_ended_text.jpg)

Le texte de fin de partie apparaît par la gauche et disparaît par la droite. Cela donne un effet jolie et fluide.

#### Classes du système d'interface utilisateur

![ui system uml](./Uml/ui_system.png)

> Ce diagramme UML ne contient pas toutes le association entre les classes car l'outil de Visual Studio ne permet pas de visualiser les association de type générique. (par exemple, la classe StatsVisualizer contient une liste de CaughtFruitElement qui n'est pas sous forme de flèche dans le diagramme).

##### UIManager

Le `UIManager` est la classe principale du système d'interface utilisateur. Elle possède une référence à toutes les canvas de l'interface (HUD, menu de fin de partie, etc) et gère leur affichage.

Il utilise les évènements du [GameManager](#gamemanager) pour afficher les canvas au bon moment.

Ce composant s'occupe également de centrer correctement les canvas par rapport à la caméra du joueur.

![ui manager inspector](./img/uimanager_inspector.jpg)

##### StatsVisualizer

`StatsVisualizer` hérite de `MonoBehaviour` et est attaché à un GameObject dans la scène. Il est responsable de visualiser les statistiques de la partie (fruits ramassés) dans le menu de fin de partie.

Il est appelé par le [UIManager](#uimanager) pour afficher les fruits ramassés lors de la fin de la partie.

Il utilise un prefab contenant un [CaughtFruitElement](#caughtfruitelement) pour afficher les fruits ramassés. Ces éléments sont instanciés dynamiquement à partir des données de la partie et sont affichés un par un avec une animation.

![stats visualizer inspector](./img/statsvisualizer_inspector.jpg)

##### CaughtFruitElement

La classe `CaughtFruitElement` est une classe qui hérite de `MonoBehaviour`. Elle est responsable d'afficher le nom du fruit et la quantité ramassée par le joueur.

Ce composant est attaché à un GameObject mis en prefab dans l'éditeur Unity. Il est instancié dynamiquement par le [StatsVisualizer](#statsvisualizer) pour afficher les fruits ramassés.

Une animation de grossissement est utilisée pour afficher les fruits ramassés. Cela permet de donner un effet visuel et d'attirer l'attention du joueur.

![caught fruit element inspector](./img/caughtfruitelement_inspector.jpg)

##### PlayButton

La classe `PlayButton` est une classe qui hérite de `UnityEngine.UI.Button`. Elle est responsable de lancer une partie quand le joueur appuie sur ce dernier.

Lors de la prèmière frame (methode `Start`), elle ajoute un listener sur l'évènement `Button.onClick` pour lancer une partie via le [GameManager](#gamemanager).

> aucun champs exposé dans l'inspector. (seulement les paramètres de base de Button)

##### QuitButton

La classe `QuitButton` hérite de `UnityEngine.UI.Button`. Elle est responsable de quitter le jeu quand le joueur appuie sur ce dernier.

Elle ajoute un listener sur l'évènement `Button.onClick` pour quitter le jeu via la méthode `UnityEngine.Application.Quit()`.

> aucun champs exposé dans l'inspector. (seulement les paramètres de base de Button)

##### Credits

La classe `Credits` hérite de `MonoBehaviour`. Elle est responsable d'afficher ou de cacher le GameObject contenant les crédits via ses deux méthodes exposées `Show` et `Hide`.

![credits inspector](./img/credits_inspector.jpg)

##### TimerVisualizer

`TimerVisualizer` hérite de `TMPro.TextMeshProUGUI` et est attaché à un GameObject dans la scène. Il est responsable de visualiser le temps restant de la partie dans le HUD.

Pour éviter d'appeler un event à chaque mise à jour du timer, il utilise sont propre timer pour mettre à jour le texte. Il s'abonne aux évènements `OnGameStart` et `OnGameStop` du [GameManager](#gamemanager) pour commencer et arrêter le timer.

> aucun champs exposé dans l'inspector. (seulement les paramètres de base de TextMeshProUGUI)

##### ScoreVisualizer

`ScoreVisualizer` hérite de `MonoBehaviour`. Il est responsable de visualiser le score du joueur dans le HUD et dans le menu de fin de partie.

Il s'abonne aux évènements `OnScoreChanged` du [GameManager](#gamemanager) pour mettre à jour le score du joueur.

Etant donné que ce composant est utilisé dans plusieurs contextes dans le lesquels le texte du score n'est pas le même, il utilise un champ exposé dans l'éditeur Unity pour définir le texte du score (en remplaçant le `$` par le score du joueur).

![score visualizer inspector](./img/scorevisualizer_inspector.jpg)

> Remarque : l'image montre le composant utilisé dans le HUD. Il est également utilisé dans le menu de fin de partie ou le champ `scoreTextFormat` est "Score : $".

##### Countdown

`Countdown` est une classe qui hérite de `MonoBehaviour`. Elle est appelée par le [UIManager](#uimanager) pour afficher le compte à rebours au début de la partie.

Elle utilise une coroutine pour afficher les chiffres un par un avec une animation de fade in/out (en utilisant DoTween).

Un son est joué au début du compte à rebours.

![countdown inspector](./img/countdown_inspector.jpg)

##### GameEndText

La classe `GameEndText` hérite de `MonoBehaviour`. Elle est appelée par le [UIManager](#uimanager) pour afficher un texte à la fin de la partie : **Partie terminée**.

Elle apparaît par la gauche et disparaît par la droite (animation avec DoTween).

![game end text inspector](./img/gameendtext_inspector.jpg)

---

### Gestion du son

Le son est important dans un jeu vidéo. Il permet d'immerger le joueur dans l'univers du jeu et de lui donner des informations sur ce qui se passe. Dans ce projet, le son est utilisé pour plusieurs choses :

- Jouer de la musique pour donner une ambiance au jeu.
- Son d'ambiance.
- Sons pour les interactions du joueur avec le jeu (ramassage de fruits, collision, etc).

Nous avons fait le choix de jouer la musique depuis une radio dans le jardin. Cela permet d'augmenter l'immersion du joueur. De plus, mélangé avec les sons d'ambiance, cela donne une ambiance chaleureuse et agréable.

#### Musique

La musique est jouée depuis une radio dans le jardin. 4 musiques différentes sont jouées en boucle.
Le joueur peut changer de musique en appuyant sur le bouton bleu de la radio ou la couper en appuyant sur le bouton rouge.

Les 4 musiques sont dans des styles différents pour varier les ambiances :

- Une musique calme et relaxante.
- Une musique jazz bien bougeante.
- Une track plus rock
- Une musique hip-hop.

Toutes les musique sont des musiques libres de droits et sont créditées dans la partie crédits du jeu.

#### Sons d'ambiance

Il y a un seul son d'ambiance dans le jeu. Il s'agit d'un son de fond de forêt. Il est joué en boucle pour donner une ambiance naturelle au jardin.

#### Sons d'interactions

Il y a plusieurs sons d'interactions dans le jeu :

- Un son de ramassage de fruit.
- Son de collision de fruit. (2 type de matières différentes pour les fruits : bois et pierre).
- Son quand le joueur met un fruit dans le panier.
- Un son est joué quand la partie se termine dans 10 secondes.
- Pedant le compte à rebours du début de partie.
- Quand la partie se termine.

Comme pour les musiques, tous les sons sont des sons libres de droits et sont crédités dans la partie crédits du jeu.

#### Classes du système de son

![audio system](./Uml/audio_system.png)

#### MusicManager

Le `MusicManager` est une classe qui gère la musique du jeu, elle hérite de `MonoBehaviour`. Elle est responsable de jouer les musiques depuis la radio et de gérer les différents évènements de la musique (changement de musique, arrêt, volume, etc).

![music manager inspector](./img/musicmanager_inspector.jpg)

#### Radio

La classe `Radio` est une classe qui hérite de `MonoBehaviour`. Elle est responsable de gérer la radio dans le jardin et ses interactions avec le joueur. Elle s'occupe également de changer les matériaux des boutons de la radio pour donner un feedback visuel au joueur.

Pour jouer les musiques, elle fait appel au [MusicManager](#musicmanager).

![radio inspector](./img/radio_inspector.jpg)

---

## Sécurité

Etant donné que le projet est un jeu vidéo solo, nous avons décidé de ne pas mettre la priorité sur la sécurité. Si le joueur veut tricher, il peut le faire. Cependant, nous avons quand même mis en place un obfuscateur pour éviter le reverse engineering (surtout car c# est un langage facile à décompiler).

### Obfuscation

Nous avons utilisé l'obfuscateur [Obfuscator Free](https://assetstore.unity.com/packages/tools/utilities/obfuscator-free-89420) de GuardingPearSoftware pour protéger notre code source.

---

## Généralités concernant l'implémentation

- [Unity 2022.3.12f1](https://unity.com/releases/editor/archive)
- [.NET Standard 2.1](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-1)
- [C# 9.0](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history#c-version-9)
- compilateur C# : [Roslyn](https://github.com/dotnet/roslyn)

## Librairies et outils externes

- [DoTween](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676)
- [Unity Test Framework](https://docs.unity3d.com/2020.3/Documentation/Manual/testing-editortestsrunner.html)
- [XR Plugin Management](https://docs.unity3d.com/2022.3/Documentation/Manual/XR.html)
- [XR Interaction Toolkit](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@3.0/manual/index.html)
- [Obfuscator Free](https://assetstore.unity.com/packages/tools/utilities/obfuscator-free-89420)

## Logiciels utilisés

- [Visual Studio 2022](https://visualstudio.microsoft.com/fr/vs/)
- [Visual Studio Code](https://code.visualstudio.com/)
- [Unity 2022.3.12f1](https://unity.com/releases/editor/archive)
- [Blender 4.1](https://www.blender.org/download/)
- [MetaQuestLink](https://www.oculus.com/setup/)

---

## Plan de test

Le plan de test a pour but de valider les fonctionnalités principales du projet. Certains test sont effectués manuellement, d'autres sont automatisés. Les tests manuels sont effectués par le développeur pour vérifier le bon fonctionnement des fonctionnalités. Les tests automatisés sont effectués par le framework de test de Unity pour vérifier le bon fonctionnement des fonctionnalités de manière automatique.

UnityTestFramework est un framework de test intégré à Unity qui permet de tester les fonctionnalités de l'application. Il est divisé en deux parties : les tests live et les tests en mode édition. Les tests live sont des tests qui sont exécutés en même temps que l'application. Les tests en mode édition sont des tests qui sont exécutés sans que l'application ne soit en cours d'exécution. Nous avons choisi d'utiliser les tests live pour tester les fonctionnalités du projet.

### Périmètre

J’ai choisi d'effectuer des protocoles de test en fonction des actions qu’un utilisateur lambda pourrait effectuer sur cette application. Certains tests sont ciblés sur des fonctionnalités spécifiques, d'autres sont plus généraux.

### Environnement de test

Les tests sont effectués sur cette configuration :

- Windows 10 Education
- carte graphique Nvidia RTX 3060
- processeur Intel(R) Core(TM) i7-2600K CPU @ 3.40GHz
- Casque de réalité virtuelle Oculus Quest 2
- Contrôleurs Oculus Touch
- Unity 2022.3.12f1

### Cas de test

Les cas de test sont divisés en deux catégories : les tests manuels et les tests automatisés.

#### Tests manuels

> L'identifiant (ID) est formé de la lettre M (pour manuel) suivi d'un numéro.

| ID | Description | Préconditions | Actions | Résultat attendu |
| -- | ----------- | ------------- | ------- | ---------------- |
| M1 | Le projet se lance et il fonctionne bien avec le casque de réalité virtuel | Casque connecté et pc fonctionel | Lancer le projet | Le projet se lance et fonctionne bien |
| M2 | Le joueur se trouve dans un jardin virtuel clos de 2x2m | Le projet est lancé | Regarder autour de soi | Le joueur se trouve dans un jardin virtuel clos de 2x2m |
| M3 | Le joueur peut se déplacer dans le monde virtuel | Le projet est lancé | se déplacer dans la vrai vie | Le joueur se déplace dans le monde virtuel |
| M4 | Le joueur ne peut pas sortir du jardin virtuel | Le joueur est dans le jardin virtuel | Essayer de sortir du jardin | Le joueur ne peut pas sortir du jardin virtuel |
| M5 | Un menu s'affiche et suis le joueur | Aucune partie n'est en cours | regarder devant soi | Un menu s'affiche et suis le joueur |
| M6 | Le joueur peut lancer une partie depuis l'interface en utilisant le bouton "Jouer" | Le menu est affiché | Appuyer sur le bouton "Jouer" | Une partie se lance |
| M7 | Un HUD s'affiche en haut de l'écran (dans le casque) | Une partie est en cours | Regarder en haut de l'écran | Un HUD s'affiche en haut de l'écran |
| M8 | Un compteur de 30 secondes s'affiche dans le HUD | Une partie est en cours | Regarder le compteur | Un compteur de 30 secondes s'affiche dans le HUD |
| M9 | Un compteur de score s'affiche dans le HUD | Une partie est en cours | Regarder le compteur | Un compteur de score s'affiche dans le HUD |
| M10 | Des fruits apparaissent aléatoirement dans le jardin virtuel | Une partie est en cours | Regarder autour de soi | Des fruits apparaissent aléatoirement dans le jardin virtuel |
| M11 | Les fruits disparaissent après 5 secondes | Une partie est en cours | Attendre 5 secondes | Les fruits disparaissent après 5 secondes |
| M12 | Le joueur peut interagir avec les fruits en les attrapant | Une partie est en cours | Attraper un fruit | Le joueur attrape un fruit |
| M13 | Le joueur peut mettre un fruit dans un panier pour gagner des points | Une partie est en cours | Mettre un fruit dans un panier | Le joueur gagne des points |
| M14 | Un fruit mis dans un panier disparaît | Une partie est en cours | Mettre un fruit dans un panier | Le fruit disparaît |
| M15 | Une fois le compteur à 0, la partie se termine | Une partie est en cours | Attendre que le compteur soit à 0 | La partie se termine |
| M16 | Une fois une partie terminée, un écran de fin de partie s'affiche | Une partie est terminée | Regarder l'écran de fin de partie | Un écran de fin de partie s'affiche |
| M17 | Le score du joueur s'affiche à la fin de la partie | Une partie est terminée | Regarder le score | Le score du joueur s'affiche à la fin de la partie |
| M18 | Un bouton "Rejouer" s'affiche à la fin de la partie et permet de lancer une nouvelle partie | Une partie est terminée | Appuyer sur le bouton "Rejouer" | Une nouvelle partie se lance |
| M19 | Une musique de fond est jouée pendant la partie | Une partie est en cours | Ecouter la musique | Une musique de fond est jouée pendant la partie |
| M20 | Un son est joué quand le joueur attrape un fruit | Une partie est en cours | Attraper un fruit | Un son est joué quand le joueur attrape un fruit |
| M21 | Un son est joué quand le joueur met un fruit dans un panier | Une partie est en cours | Mettre un fruit dans un panier | Un son est joué quand le joueur met un fruit dans un panier |
| M22 | Un son est joué quand la partie se termine bientôt (80%) | Une partie est en cours | Attendre que la partie se termine bientôt | Un son est joué quand la partie se termine bientôt |
| M23 | Un son est joué quand un fruit entre en collision avec le sol | Une partie est en cours | Laisser un fruit tomber | Un son est joué quand un fruit entre en collision avec le sol |
| M24 | La couleur du fruit s'éclaircit quand le joueur peut l'attraper | Une partie est en cours | Approcher la main du fruit | La couleur du fruit s'éclaircit quand le joueur peut l'attraper |

#### Tests automatisés

Les tests automatisés visent uniquement le système de gestion des fruits. En effet, c'est le système le plus complexe et le plus critique du projet. Les tests automatisés sont effectués par le framework de test de Unity. Voici les cas de test automatisés :

> L'identifiant (ID) est formé de la lettre A (pour automatisé) suivi d'un numéro.

| ID | Description | Résultat attendu | détails | fichier |
| -- | ----------- | ---------------- | ------- | ------- |
| A1 | Un fruit avec un type existant doit être instancié correctement par un FruitPooler | Le fruit est instancié correctement | le fruit est instancié, le type est correct, l'id du fruit est correct, l'attributeur d'id est incrémenté, le fruit est ajouté à la liste des fruits, le fruit est ajouté a la hierrachie en tant qu'enfant du parent definis | FruitTest.cs |
| A2 | Une exception doit être levée si on essaie d'instancier un fruit avec un type inexistant | Une exception est levée | le fruit n'est pas instancié, une exception `FruitTypeIdDoesNotExistException` est levée | FruitTest.cs |
| A3 | Le bon nombre de fruits (poolSize) doit être instanciés, désactivés et disponibles dans le pool lors de l'initialisation du FruitPooler | Le bon nombre de fruits est instancié, désactivé et disponible | La pool des fruits de type validTypeId contient le bon nombre de fruits, Les fruits ne sont pas nuls, Les fruits sont du bon type, Les fruits sont désactivés | FruitTest.cs |
| A4 | Un nouveau fruit doit être instancié si le pool est vide | Un nouveau fruit est instancié | Un nouveau fruit est créé et instancié correctement (meme condition que ID:1) | FruitTest.cs |
| A5 | Un fruit doit être remis dans le pool lorsqu'il est désactivé | Le fruit est remis dans le pool | Le fruit est désactivé, le fruit est remis dans le pool, le fruit est disponible | FruitTest.cs |
| A6 | Les fruits doivent être réutilisés s'ils sont désactivés | Les fruits sont réutilisés | Les fruits désactivés sont réutilisés lors de l'instanciation suivante | FruitTest.cs |

### Journal de test

| ID | J1 | J2 | J3 | J4 | J5 | J6 | J7 | J8 | J9 | J10 | J11 |
| -- | -- | -- | -- | -- | -- | -- | -- | -- | -- | --- | --- |
| M1 | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M2 | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M3 | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M4 |  | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M5 |  |  | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M6 |  |  | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M7 |  |  | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M8 |  |  | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M9 |  | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M10 |  | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M11 |  | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M12 |  | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M13 |  |  | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M14 |  |  | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M15 |  |  | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M16 |  |  | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M17 |  |  | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M18 |  |  | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| M19 |  |  |  |  |  |  | OK | OK | OK | OK | OK |
| M20 |  |  |  |  |  | OK | OK | OK | OK | OK | OK |
| M21 |  |  |  |  |  | OK | OK | OK | OK | OK | OK |
| M22 |  |  |  |  |  | OK | OK | OK | OK | OK | OK |
| M23 |  |  |  |  |  | OK | OK | OK | OK | OK | OK |
| M24 |  | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| A1 |  | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| A2 |  | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| A3 |  | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| A4 |  | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| A5 |  | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |
| A6 |  | OK | OK | OK | OK | OK | OK | OK | OK | OK | OK |

> Remarque : Aucune regression n'a été détectée lors des tests.

---

## Conclusion

### Difficultés rencontrées

Pendant la réalisation de ce projet, plusieurs difficultés ont été rencontrées. Voici quelques exemples de difficultés rencontrées :

- Difficulté à pendant la conception du système de fruits.
- Difficulté à gérer les interactions entre les différents composants du jeu.
- Trouver un équilibre pour le taux d'apparition des fruits.
- Problème de performance lors de l'instanciation des fruits.

### Variantes de solutions et choix

Pour résoudre ces difficultés, plusieurs solutions ont été envisagées. Voici quelques exemples de variantes de solutions et de choix effectués :

#### Conception du système de fruits

Pendant la conceptions du système de fruits, plusieurs choix s'offraient à nous concernant l'architecture du système. Au départ nous avions envisagé d'utiliser une Factory et un Builder pour gérer les fruits.  

Cette solution était intéressante car elle permettait de simplement regrouper toutes les données des fruits dans un seul endroit (dans un scriptable object). Cela aurait permis de ne pas avoir de prefabs de fruits, mais de les générer dynamiquement à partir des données.  

Cependant, après réflexion, cette solution était trop complexe pour les besoins du projet. Donc nous avons opté pour une solution plus simple en faisant un système hybride avec des prefabs et un scriptable object. Une variante beacoup plus adaptée à notre projet.

#### Gestion des interactions entre les composants

Pour gérer les interactions entre les différents composants du jeu, beacoup de choix s'offraient à nous. La plus simple étant de faire des références directes entre les composants. Cependable, cette solution n'était pas la plus adaptée car elle créait énormément de dépendances entre les composants. 

Pour éviter cela, nous avons majoritairement opté pour des Singleton. Cela simplifie le code ainsi que l'utilisation dans l'éditeur Unity.

Dans certains cas, un pattern d'observateur s'est avéré être la meilleure option. C'est le cas pour `GameManager` qui notifie plusieurs composants de l'application.

#### Equilibre du taux d'apparition des fruits

Pour trouver un équilibre pour le taux d'apparition des fruits, nous avons testé plusieurs valeurs pour le taux d'apparition. Nous avons également testé différentes méthodes pour calculer le taux d'apparition des fruits.

Après plusieurs tests, les valeurs actuelles ont été choisies pour donner une expérience de jeu équilibrée et agréable.

#### Problème de performance lors de l'instanciation des fruits

Ayant deja un petit peu d'experience avec Unity, nous savions que l'instanciation de GameObjects en masse allait poser des problèmes de performance. Pour éviter cela, nous avions deja en tête d'utiliser un pool. Le problème était qu'aucun problème de performance n'était visible lors des premiers tests.

Nous avons pris la décision de quand même implémenter un pool pour éviter tout problème de performance futur. Surtout que nous savions que le pc de développement offrait des performances bien supérieures à un pc moyen.

### Améliorations possibles

Pour améliorer le projet, voici quelques pistes d'améliorations possibles :

- Faire clignoter les fruits quand ils sont sur le point de disparaître.
- Améliorer les texts d'informations pour les rendre plus jolis.
- Ajouter des options pour personnaliser le jeu (couleurs, musique, etc).
- Sauvegarder les scores des joueurs pour les comparer (leaderboard).
- Ajouter des effets visuels pour les interactions avec les fruits (particules, etc).
- Ajouter des niveaux de difficulté pour augmenter la durée de vie du jeu.
- Ajouter des power-ups pour rendre le jeu plus intéressant.
- Ajout d'autres types de fruits et de paniers pour varier les parties.
- Ajout des outils débloquables qui facilitent la récolte des fruits (filet, gants, etc).
- Plusieurs jardins avec des thèmes différents (jardin japonais, jardin anglais, etc).

### Bilan personnel

Ce projet m'a permis de mettre en pratique les compétences acquises pendant ma formation. J'ai pu approfondir mes connaissances en C# et en Unity. J'ai également appris à travailler de manière autonome et à gérer mon temps efficacement. Ce projet m'a permis de développer mes compétences en matière de conception et d'implémentation de jeux vidéo en réalité virtuelle.

J'ai bien aimé travailler sur ce projet car il était très ouvert et m'a permis d'exprimer ma créativité. J'ai pu explorer de nouvelles idées et tester de nouvelles fonctionnalités. Toutes la partie visuelle et sonore du projet était libre ce qui m'a beacoup plu.

La partie documentation était également très intéressante. Non je rigole, c'était bien ennuyant. Mais bon, c'est une partie importante du projet donc il fallait la faire.

J'ai aussi eu beaucoup de mal avec le journal de bord. J'ai eu du mal à le tenir à jour et à le remplir correctement. C'est la première fois que je faisais un journal de bord et je n'ai pas l'habitude de noter tout ce que je fais. C'est quelque chose que je dois améliorer pour les prochains projets.

### Remerciements

Je tiens à remercier M. J. Aliprendi pour son soutien et ses conseils tout au long de ce projet. Je tiens également à remercier Yvan Poulin pour son expertise et son retours constructifs.

## Bibliographie

- [Unity Documentation](https://docs.unity3d.com/2022.3/Documentation/Manual/index.html) - Documentation officielle de Unity.
- [How to Make a VR Game in Unity - PART 1](https://youtu.be/HhtTtvBF5bI?si=AeYBfnjUX8jWkSUc) - Tutoriel sur la création d'un jeu VR en Unity.
- [How to Make a VR Game in Unity - PART 7](https://youtu.be/yhB921bDLYA?si=mdiTW4-eF60TvFj1) - Suite du tutoriel, faire en sorte que l'UI suive le joueur.
- [Documentation XR Interaction Toolkit](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@3.0/manual/index.html) - Documentation officielle de l'XR Interaction Toolkit.
- [Documentation DoTween](http://dotween.demigiant.com/documentation.php) - Documentation officielle de DoTween.
- [Exeption c#](https://learn.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions) - Documentation sur les exceptions en C#.
- [Optimisation transform](https://gamedev.stackexchange.com/questions/101522/what-are-the-differences-between-using-getcomponenttransform-and-this-transf) - Optimisation de l'utilisation de `transform` dans Unity.
- [Documentation Unity.Random](https://docs.unity3d.com/ScriptReference/Random.Range.html) - Documentation sur l'utilisation de `Random.Range` dans Unity.
- [Bonne pratique tests unitaires](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices) - Bonnes pratiques pour les tests unitaires.
- [Design pattern](https://refactoring.guru/design-patterns/behavioral-patterns) - Documentation sur les design patterns.
- [Pool design pattern](https://sourcemaking.com/design_patterns/object_pool) - Documentation sur le design pattern de pool.

## Annexe

### Utilisation de chatGPT

#### Convention doublons documentation

##### prompt

``` text
Dans le cadre d'un projet informatique je dois rédiger une documentation technique.
J'aimerais décrire chaque champ des classes de mon projet en détail.
Pour cela j'utilise un sous-titre #### Champs pour chaque classe.
Le problème c'est que mon extension vs code m'indique un warning :
"no-duplicate-heading: Multiple headings with the same content"

Quelles sont les conventions/les normes sur ces points ? Comment renommer ces sous-titres pour éviter les doublons ? Comment la plupart des documentation technique font ?
```

##### réponse

``` text
L'avertissement que vous recevez indique qu'il y a plusieurs sous-titres avec le même contenu, ce qui peut rendre la structure de votre documentation confuse pour les lecteurs et les outils de traitement de texte. Pour éviter cela, vous pouvez suivre quelques conventions ou normes de dénomination des sous-titres dans votre documentation technique :

Nom unique pour chaque champ : Plutôt que d'utiliser simplement "Champs" pour chaque classe, essayez d'utiliser des noms spécifiques qui décrivent les champs de cette classe en particulier.
Par exemple, si vous avez une classe "Utilisateur", vous pourriez avoir des sous-titres comme "Champs de la classe Utilisateur".
Utilisation des noms de champs : Une autre approche consiste à utiliser les noms réels des champs comme sous-titres. Cela rend la documentation plus spécifique et directement liée à la classe. 
Par exemple, pour la classe "Utilisateur", vous pourriez avoir des sous-titres comme "Nom", "Âge", "Email", etc.
Préciser la classe dans le sous-titre : Si vous avez plusieurs classes avec des champs similaires, vous pouvez spécifier la classe dans le sous-titre pour éviter les doublons. 
Par exemple, pour les sous-titres de la classe "Client" et de la classe "Fournisseur", vous pourriez avoir "Champs de la classe Client" et "Champs de la classe Fournisseur".
Utilisation de la syntaxe du langage : Si votre documentation est destinée à des développeurs ou à des personnes familières avec le langage de programmation que vous utilisez, vous pouvez utiliser la syntaxe du langage pour spécifier les champs. 
Par exemple, si vous utilisez Java, vous pourriez avoir des sous-titres comme "Attributs de la classe Utilisateur".
Groupement des champs par catégorie : Si vous avez de nombreux champs dans une classe, vous pouvez les regrouper par catégorie et utiliser ces catégories comme sous-titres. 
Par exemple, pour une classe "Produit", vous pourriez avoir des sous-titres comme "Informations de base", "Prix et quantité", "Catégorie", etc.
En suivant l'une de ces approches, vous pouvez rendre votre documentation plus claire et éviter les avertissements concernant les sous-titres en double. 
En général, la plupart des documentations techniques suivent ces conventions pour organiser et structurer les informations de manière logique et compréhensible.
```


### Code source

...
