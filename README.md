# Projet BTS SIO SLAM - Bloc 2

## Rubik's Cube Console

Ce projet est une application console en C# realisee dans le cadre du BTS SIO option SLAM, Bloc 2.

L'objectif est de modeliser un Rubik's Cube en programmation orientee objet, d'afficher ses faces dans la console et de permettre des rotations de base sur les differentes faces du cube.

## Objectifs pedagogiques

- Manipuler la programmation orientee objet en C#
- Concevoir plusieurs classes qui collaborent entre elles
- Representer un objet complexe avec une structure de donnees adaptee
- Mettre en place des methodes de transformation sur un modele
- Afficher graphiquement un resultat dans une application console

## Fonctions disponibles

- Affichage du cube dans la console
- Rotation des faces :
  - `F` : Front
  - `B` : Back
  - `R` : Right
  - `L` : Left
  - `U` : Up
  - `D` : Down
- Saisie clavier en boucle
- Touche `Q` pour quitter l'application
- Mode de verification interne avec `--self-test`

## Structure du projet

- `Program.cs` : point d'entree, boucle console, saisie utilisateur, auto-test
- `Cube.cs` : representation du cube et gestion des rotations
- `Face.cs` : representation d'une face 3x3 du cube
- `Tuile.cs` : representation d'une tuile coloree dans la console

## Competences BTS SIO SLAM - Bloc 2

Ce projet mobilise notamment :

- le developpement d'une solution applicative
- l'organisation du code en classes et methodes
- la qualite du code et les tests de verification
- la prise en compte de l'affichage et de l'interaction utilisateur

## Lancer le projet

Depuis le dossier du projet :

```bash
dotnet build
dotnet run
```

## Lancer le test interne

```bash
dotnet run -- --self-test
```

Si tout est correct, le programme affiche :

```text
OK
```

## Utilisation

Au lancement, la console affiche :

- le titre du projet
- les coups disponibles
- le cube dessine en couleur

Ensuite, il suffit de taper une lettre parmi `F`, `B`, `R`, `L`, `U`, `D` pour effectuer une rotation.

## Pistes d'amelioration

- Ajouter les rotations inverses (`F'`, `R'`, etc.)
- Ajouter un melange aleatoire du cube
- Ajouter une remise a zero
- Ajouter un historique des mouvements
- Ajouter une verification "cube resolu"

## Contexte

Projet realise a partir du sujet :

- `TP Jeux SIO Rubiks Cube Console`

Ce travail s'inscrit dans une logique d'apprentissage autour de la modelisation, de l'algorithmique et du developpement d'applications console en C#.
