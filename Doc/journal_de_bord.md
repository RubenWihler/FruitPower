# Journal de bord

## Introduction

Ce document est un journal de bord présentant les différentes étapes de la réalisation du projet FruitPower. Ce projet a été réalisé dans le cadre du Travail pratique individuel (TPI) durant la session de mai 2024. Il a pour but de valider mes compétences acquises pendant la formation Informaticien CFC dispensée à l’école d’informatique du CFPT au Petit-Lancy. FruitPower est un jeux vidéo utilisant la réalité virtuelle. Il a été développé en C# avec le moteur de jeu Unity.

## Suivi du projet

### Jour 1 - 24.04.2024

Cher journal, aujourd'hui est un grand jour. Je commence mon TPI. J'ai hâte de commencer à travailler sur mon projet. Je vais commencer par lire le cahier des charges pour bien comprendre ce que je dois faire.

#### Lecture du cahier des charges

J'ai fini de lire le cahier des charges. J'ai une idée plus claire de ce que je dois faire, mais il y a encore quelques points que je ne comprends pas très bien. principalement sur le HUD. Je vais demander des informations supplémentaires à mon maître d'apprentissage.

#### Structure du projet

J'ai également commencé à réfléchir à la structure de mon projet. J'ai décidé de créer un dossier `Src` pour y mettre tout mon code source et un dossier `Doc` pour y mettre toute la documentation.

J'ai créé un repository Git pour mon projet et j'ai commencé à versionner mon code.
Je l'ai également mis en ligne sur GitHub pour pouvoir y accéder de partout.

<div style="page-break-after:always"></div>

#### Planning prévisionnel

Je vais maintenant commencer à faire la planification de mon projet. Je vais commencer par créer un planning prévisionnel pour pouvoir m’organiser et savoir ce que je dois faire et quand.

Pour cela je vais d'abord découper le travail en plusieurs tâches sous forme de user stories. Ensuite je vais mettre en place la méthode MoSCoW pour attribuer des priorités sur les tâches. Je vais toutes les regrouper dans un backlog.

Une fois le backlog créé, j'ai créé un projet sur GitHub pour y mettre toutes les tâches à réaliser. J'ai commencé à créer des issues pour chaque tâche à réaliser.
Une fois toutes les tâches créées, je l'ai est converti en issues pour pouvoir les suivre plus facilement.

J'ai fini de créer toutes les tâches principales à réaliser. je vais maintenant commencer à les planifier dans un planning prévisionnel.

Mais avant ça, je vais ajouter des taches plus précises pour chaque tâche principale. Par exemple, pour la tâche `001 : Implémentation VR`, je vais ajouter des sous-tâches comme `001.1 : Ajout du pacjage XR` ou `001.2 : Ajout des contrôleurs`. Je vais aussi rajouter des tâches qui ne sont pas dans le backlog comme `Création du journal de bord` ou `Création de la documentation`.

Je vais les ajouter dans le fichier backlog pour pouvoir les suivre plus facilement meme si ce ne sont pas des véritables user stories.
J'ai également ajouté toutes les tâches dans le projet GitHub et dans le planning prévisionnel.

#### Visite expert

M.Poulin m'a rendu visite et m'a donné quelques conseils pour la suite du projet. Il m'a conseillé de bien m'organiser et de ne pas hésiter à demander de l'aide si j'en ai besoin.

#### Fin de la planification

J'ai fini de planifier toutes les tâches dans le planning prévisionnel. J'ai également fini de créer toutes les tâches dans le projet GitHub. Je vais maintenant commencer à travailler sur la première tâche.

<div style="page-break-after:always"></div>

#### Création du projet Unity

Je vais commencer par la creation du projet Unity. Je vais créer un dossier `FruitPower` dans lequel je vais créer un projet Unity.

Une fois le projet créé, je fais un premier commit pour sauvegarder l'état actuel du projet.
J'en profite pour faire une sauvegarde sur mon disque dur externe (publier sur le drive est un peu long je pense que je ne vais que le faire une fois par jour).

Je vais utiliser cette vidéo comme référence pour la mise en place de la configuration de XR : [How to Make a VR Game in Unity - PART 1](https://youtu.be/HhtTtvBF5bI?si=AeYBfnjUX8jWkSUc)

> Il faut noter que la vidéo utilise une ancienne version du plugin XR. Il a donc fallu que je m'adapte à la nouvelle version en regardant [la documentation officielle](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@3.0/manual/index.html).

#### Implémentation de la VR

Je vais commencer par l'implémentation de la VR. Je vais commencer par ajouter le package XR, puis le package Unity Input System et enfin le package XR Interaction Toolkit. En plus de cela je vais utiliser les assets fournis dans le pack `Starter Assets` pour avoir un environnement de base.

Je vais commencer par créer une branche pour chaque tâche que je vais réaliser. Je vais commencer par créer une branche `001-implementation-vr` pour la première tâche.

Pour la création de la branche, je vais utiliser la convention suivante : `ID-Nom-de-la-tache`.

J'ai importé toutes les assets de mon projet de preparation dans le projet Unity. Cela m'a permis de gagnger du temps pour la suite.

J'ai fini d'ajouter le system de déplacement dans le jeu et de tester le tout. J'ai pu tester le déplacement avec les contrôleurs et tout fonctionne correctement.

<div style="page-break-after:always"></div>

#### Environnement 3D

Je vais maintenant passer à la tâche suivante : `002 - Environnement 3D`. Je vais commencer par créer une branche `002-environnement-3d` pour cette tâche.

Pour construire le jardin, je vais commencer par créer un terrain de 2x2 mètres. Sachant que la taille d'une unité dans Unity correspond à 1 mètre, je vais donc créer un terrain de 2x2 unités.

Pour les buisson et les arbres, je vais utiliser plusieurs assets trouvés gratuitement sur le store d'Unity. Je vais les importer dans le projet et les placer dans le jardin.

- [Simple Nature Pack](https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153)

#### Conclusion J1

J'ai bien avancé sur le projet aujourd'hui. J'ai réussi à implémenter la VR et à créer un environnement 3D de base. Je suis content de mon avancement et j'ai hâte de continuer à travailler sur le projet demain.



---

### Jour 2 - 25.04.2024

Cher journal, aujourd'hui est un nouveau jour. Je suis prêt à continuer à travailler sur mon projet. Aujourd'hui, je vais commencer par la conception du système de génération de fruits. Pour cela, je vais commencer par créer une branche `005-generation-fruits`.

> Effectivement, je n'ai pas fais de branches pour les tâches précédentes, mais cela ne me dérange pas surtous car ce sont des tâches assez simples et rapides à réaliser en plus de cela je suis seul sur le projet.

Avant de commencer à travailler sur le projet, je vais commencer par faire une sauvegarde sur mon disque dur externe, sur une clé USB et sur le drive. Cela me permettra de ne pas perdre mon travail en cas de problème.

<div style="page-break-after:always"></div>

#### recherche sur les exeptions

pendant la realisation du script `FruitFactory`, je ne me souvenais plus comment créer une exeptions personalisé. J'ai donc cherché sur internet et j'ai trouvé [cette page](https://learn.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions) qui m'a bien aidé.

#### recherche sur les performances

J'ai aussi eu besoin de verifier pourquoi faire ça faisait gagner des performances :  
(Je le fais tout le temps mais je ne me souvenais plus précisément pourquoi)

```csharp
//avant
transform.position = position;
transform.rotation = rotation;

//après
var transf = transform;
transf.position = position;
transf.rotation = rotation;
```

j'ai trouvé [cette page](https://gamedev.stackexchange.com/questions/101522/what-are-the-differences-between-using-getcomponenttransform-and-this-transf) qui m'a bien aidé.

#### recherche sur le random de unity

Je ne savais plus si le max(deuxieme parametre) de la fonction `UnityEngine.Random.Range` était inclusif ou exclusif. J'ai donc cherché sur internet et j'ai trouvé [cette page](https://docs.unity3d.com/ScriptReference/Random.Range.html).

J'ai pu avancer sur la tâche `005 - Génération de fruits`. J'ai réussi à créer un système de génération de fruits aléatoires sur les arbres et les buissons. Les fruits apparaissent aléatoirement à une vitesse définie. J'ai également ajouté un système de disparition des fruits après quelques secondes s'ils ne sont pas ramassés.

#### Conclusion J2

J'ai bien avancé sur le projet aujourd'hui. J'ai réussi à implémenter le système de génération de fruits. Je suis content de mon avancement et j'ai hâte de continuer à travailler sur le projet demain.

<div style="page-break-after:always"></div>

### Jour 3 - 29.04.2024

Au cours de ces deux derniers jours, j'ai pu avancer sur plusieurs tâches et je suis très en avance sur mon planning. Aujourd'hui, je vais commencer par travailler sur la tâche `006 - Ramassage de fruits`. Je vais commencer par créer une branche `006-ramassage-fruits` pour cette tâche.

#### Recherche sur la nomenclature des tests

J'ai eu besoin de vérifier la nomenclature des tests unitaires en C#. J'ai trouvé [cette page](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices) qui m'a bien aidé.

J'ai trouver ceci :  

>The name of your test should consist of three parts:
>
>- The name of the method being tested.
>- The scenario under which it's being tested.
>- The expected behavior when the scenario is invoked.

Cela ne peut pas vraiment s'appliquer à mon cas car mes tests sont plus des tests de comportement que de fonctionnalité.
Cependant, je vais essayer de les nommer plus ou moins de cette manière.

#### Modification pour les test

J'ai du faire quelques modifications dans le code pour pouvoir tester le ramassage des fruits. J'ai du ajouter un setter pour la variable `_typeId` dans la classe `Fruit` pour pouvoir changer le type du fruit dans les tests.

#### Vidéo pour l'interface

J'ai regarder [cette video](https://youtu.be/yhB921bDLYA?si=mdiTW4-eF60TvFj1) pour m'aider à centrer l'interface.

#### Conclusion J3

J'ai bien avancé sur le projet aujourd'hui. J'ai réussi à faire les tests unitaires pour le ramassage des fruits. Je suis maintenant sûr que tout le système fonctionne correctement. Je suis en avance de 16h jours sur mon planning.

<div style="page-break-after:always"></div>

### Jour 4 - 30.04.2024

Aujourd'hui, je vais ajouter 2 types de fruits (les fraises et les myrtilles).

J'ai utilisé blender pour modifié les modèles 3D (libre de droit). Je me suis rendu compte que je devais cité les auteurs des modèles 3D que j'utilise. J'ai donc créé un fichier `CREDITS.txt` que j'ai ajouté à la racine du projet. J'ai ajouté les noms des auteurs des modèles 3D que j'ai utilisé.

#### Visite de M.Aliprandi

M.Aliprandi m'a rendue visite et j'ai pu lui montrer l'avancement de mon projet. Je lui ai demandé si je devais faire un plan de test même si il n'etait pas demandé dans le cahier des charges. Il m'a dit que c'était une bonne idée et que je devrais le faire.
C'est donc ce que je vais faire cette après-midi en plus d'avancer la documentation.

Je me trouve fasse a un petit problem: vu que je n'avait pas fait le plan de test avant le 4eme jour, je ne peux pas savoir quels tests passait pendant les jours précédents. Je vais donc retourné grâce à git pour retourner a l'état du projet avant chaque fin de journée pour pouvoir faire les tests.

#### Conclusion J4

J'ai bien avancé sur plein d'aspect du projet aujourd'hui. En plus d'avoir ajouté les fruits, j'ai pu avancer sur la documentation et j'ai commencé à rédiger le plan de test. Je suis content de mon avancement et j'ai hâte de continuer à travailler sur le projet demain. De plus j'ai encore beaucoup d'avance sur mon planning.



---

### Jour 5 - 02.05.2024

Aujourd'hui, je vais commencer par avancer la documentation.

J'ai commencé par rédiger la partie sur l'implémentation de la VR. J'ai expliqué comment j'ai ajouté le package XR, le package Unity Input System et le package XR Interaction Toolkit. J'ai également expliqué comment j'ai configuré le casque VR et les contrôleurs.

J'ai ensuite rédigé la partie sur l'environnement 3D. J'ai expliqué comment j'ai créé un terrain de 2x2 mètres et comment j'ai ajouté des arbres et des buissons.

<div style="page-break-after:always"></div>

#### Visite de M.Poulin

M.Poulin m'a rendu visite et j'ai pu lui montrer l'avancement de mon projet. Il m'a donné quelques conseils pour améliorer la documentation. Il m'a conseillé de détailler un peu plus les classes et les méthodes pour que ce soit plus clair pour les personnes qui liront la documentation.

#### Conclusion J5

Conclusion de la journée : J'ai bien avancé sur la documentation. J'ai pu rédiger la partie sur l'implémentation de la VR et sur l'environnement 3D. Je suis content de mon avancement et j'ai hâte de continuer à travailler sur la documentation demain.

---

### Jour 6 - 06.05.2024

Bonjours cher journal, aujourd'hui je vais commencer par chercher des musiques et des bruitages pour mon jeu. Je vais ensuite les intégrer dans le projet.

#### Initialisation switch case

Pendant implémentation des bruitage je voulais utiliser une initialisation switch case mais je ne me souvenais plus de la syntaxe. J'ai donc cherché sur internet et j'ai trouvé [cette page](https://stackoverflow.com/questions/8155772/setting-a-variable-to-a-switchs-result) qui m'a bien aidé.

> Finalement cette fonctionnalité de c# n'est pas disponible dans la version que j'utilise.

<div style="page-break-after:always"></div>

#### Ajout du package DoTween

J'ai ajouter le package DoTween pour s'occuper des animation de l'interface. DoTween permet dans mon cas de simplifier et d'optimiser les interpolation linéaire (fade des textes, déplacement etc).

Pour me documenter sur DoTween je me suis aidé de [la documentation](https://dotween.demigiant.com/documentation.php).

Pendant que j'essayais de faire une animation le text ne se mettait pas à jour. J'ai donc cherché sur internet et j'ai trouvé [cette page](https://discussions.unity.com/t/horizontal-layout-group-padding-update-via-script/150064/2)

La solution était de manuellement mettre à jour le layout du texte après l'animation.

```csharp
LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
```

#### Conclusion J6

J'ai bien avancé sur le projet aujourd'hui. J'ai pu trouver des  bruitages pour mon jeu. J'ai également ajouté le package DoTween pour gérer les animations de l'interface. Je suis content de mon avancement et j'ai hâte de continuer à travailler sur le projet demain.

---

### Jour 7 - 07.05.2024

Aujourd'hui, je vais commencer par chercher une musique pour le jeu et l'intégrer dans le projet.

#### Décision sur le détail des classes dans la documentation

J'ai finalement abandonné l'idée de détailler chaque classes dans la documentation (champs, méthodes, propriétés etc.) car cela prenait trop de temps. J'ai donc décidé de n'écrire que des explications sur le fonctionnement des classes, liens entre elles, responsabilités etc.

#### Conclusion J7

J'ai perdu beaucoup de temps avec le problème de la documentation.
Mais cela m'a permis de prendre une décision qui m'a fait gagner du temps pour la suite du projet. De plus j'étais tellement en avance que cela ne pose pas de problème.

<div style="page-break-after:always"></div>

### Jour 8 - 08.05.2024

Aujourd'hui, je vais avancer sur la documentation. Je vais commencer par rédiger la partie sur les arabes et les buissons.

#### Visite de M.Poulin

J'ai recu une visite de M.Poulin, je lui ai posé quelques questions sur la documentation. Il a su répondre à mes questions et m'a donné quelques conseils pour améliorer la documentation.

#### Manuel utilisateur

J'ai commencé à rédiger le manuel utilisateur. J'ai commencé par les prérequis pour lancer le jeu. J'ai expliqué comment lancer le jeu et comment jouer. J'ai également expliqué comment interagir avec le jeu en utilisant le casque VR et les contrôleurs.

#### Conclusion J8

J'ai bien avancé sur la documentation aujourd'hui. J'ai pu rédiger la partie sur les arbres et les buissons. J'ai également fini de rédiger le manuel utilisateur. Je suis content de mon avancement mais je n'ai pas hâte de continuer à travailler sur la documentation demain.



---

### Jour 9 - 13.05.2024

Au cours de ces derniers jours, j'ai pu avancer sur la documentation. Aujourd'hui, je vais continuer à travailler sur la documentation mais avant cela je vais faire le manuel utilisateur.

#### Peaufinage de la documentation

J'ai passé la matinée à paufiner la documentation. J'ai corrigé les fautes d'orthographe et de grammaire. J'ai également ajouté des captures d'écran pour illustrer les explications.

<div style="page-break-after:always"></div>

#### Rapport de fin de projet

Pour cette après-midi, je vais rédiger le rapport de fin de projet. 

#### Conclusion J9

J'ai bien avancé sur la documentation aujourd'hui. J'ai pu peaufiner la documentation et ajouter des captures d'écran. J'ai également commencé à rédiger le rapport de fin de projet. Je suis content de mon avancement et j'ai hâte de continuer à travailler sur le projet demain.

---

### Jour 10 - 14.05.2024

Aujourd'hui, je vais continuer à travailler sur le rapport de fin de projet. Je vais commencer par rédiger la partie sur les difficultés rencontrées et les solutions apportées.

J'ai également peaufiné tous les documents ce qui m'a pris toute la journée.

#### Conclusion J10

J'ai bien avancé sur le rapport de fin de projet aujourd'hui. J'ai pu rédiger la partie sur les difficultés rencontrées et les solutions apportées. J'ai également peaufiné tous les documents. Je suis content de mon avancement et je suis prêt à rendre le projet demain.

---

### Jour 11 - 15.05.2024

Aujourd'hui, je vais rendre le projet. Je vais faire une dernière vérification de tous les documents pour m'assurer qu'ils sont prêts à être rendus.
J'ai fait une dernière vérification de tous les documents et j'ai rendu le projet.

#### Conclusion J11

Je n'ai pas travaillé sur le projet aujourd'hui. J'avais suffisamment de temps pour tout finir avant la date de rendu. Je suis content de mon travail et j'ai hâte de voir les retours sur mon projet.

<div style="page-break-after:always"></div>

## Conclusion

Ce journal de bord m'a permis de suivre l'avancement de mon projet tout au long de sa réalisation. J'ai pu noter les différentes étapes de la réalisation du projet, les difficultés rencontrées et les solutions apportées. Comme le montre bien ce journal, j'ai surtout travaillé sur le projet les 4-5 premiers jours. Ensuite j'ai surtout travaillé sur la documentation. Ce qui explique pourquoi moins de détails sont donnés sur les derniers jours.

Je suis content de mon travail et j'ai hâte de voir les retours sur mon projet. Je suis fier de ce que j'ai accompli et j'espère que mon projet sera apprécié.
