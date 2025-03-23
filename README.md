# Dungeon Crawler - Unity Project

## Description

Ce projet est un jeu de type Dungeon Crawler développé avec Unity. Le joueur explore des donjons remplis de monstres, trouve de l'or et améliore son personnage en gagnant des niveaux.

Objectif : Survivre aux dangers du donjon, combattre des ennemis, collecter des ressources et améliorer son personnage pour aller toujours plus loin.

## Installation et exécution

Cloner le dépôt :

```
git clone https://github.com/ton-repo/dungeon-crawler.git
```


Ouvrir le projet dans Unity (Unity 6 (6000.0.36f1)).

Lancer la scène principale et tester le jeu.

## Fonctionnalités principales

* Exploration d'un donjon.

* Combat contre des monstres avec un système de points de vie et d'attaque.

* Système de loot : récupération d'or et d'équipements.

* Progression du personnage : montée en niveau, amélioration des statistiques.

* Menu principal permettant de lancer une partie.

## Scripts et leur rôle

#### 1. PlayerController.cs

Gère les déplacements du joueur, les attaques et la gestion des dégâts. Les différentes animations du joueur fonctionnent.

Déplacements : le joueur peut se déplacer avec les touches ZQSD ou les flèches directionnelles.

#### 2. Enemy.cs

Contrôle le comportement des ennemis : détection, poursuite et attaque du joueur.

#### 3. MenusBtn.cs

Gestion des différents boutons servant à se déplacer dans les scènes.

#### 4. PauseGame.cs

Permet de faire une pause en Game quand l'on fait ```Esch``` .

### Problèmes rencontrés

#### 1. Problème avec l'ennemi

L’ennemi était éjecté de la carte sans raison apparente.

Résolution imprévue en fin de projet sans modification directe du code.

#### 2. Problème avec le joueur

Après la correction du bug de l’ennemi, le joueur a commencé à subir le même problème.

Non résolu dans les délais du projet.

#### 3. Sort magique du joueur non finalisé

Ajout tardif dans le projet, non fonctionnel à la fin du développement cause le joueur pas opérationnel.

## Améliorations futures

* Correction du bug d'éjection du joueur.

* Finalisation du système de sorts.

* Plus de variétés d’ennemis ainsi que de boss.

* Fonctionnement du level up du joueur.

* Ajout de loot/or pour les monstres.

* Création de nouvelles salles pour le donjon.

## Auteur

**Lucas Studer**
