
# 🎯 Unit 47

**Unit 47** est un jeu de tir à la première personne développé sous Unity, inspiré de l’univers de Valorant mais en version solo simplifiée. Le projet est pensé pour une évolution incrémentale, avec une structuration par versions successives (v0.0.1 → v1.0.0).

## 🔧 Objectif

Créer un jeu complet jouable en solo, où le joueur pourra se déplacer, tirer, utiliser des compétences simples et évoluer dans des environnements variés. Le multijoueur est envisagé comme une option future.

## 📦 Technologies
- Unity (URP)
- C# (MonoBehaviour + Input System)
- Git pour la gestion de version
- (Optionnel) Netcode for GameObjects ou Mirror (multijoueur plus tard)

## ▶️ Version actuelle : v0.0.2

Ajout spécifique à la v0.0.2 : 
- Ajout d’effets sonores (tir, orbe, cible détruite)
- Ajout d’effets visuels (muzzle flash, hit effect, orbe collecte)
- Ajout de particules (orbe, cible détruite)
- HUD avec barre de vie, viseur, bullet trail
- Écran titre simpl, avec sous menu GameMode

## 🧪 Comment lancer le projet
1. Cloner ce dépôt
2. Ouvrir le projet dans Unity (version recommandée : 6.0 ou plus)
3. Build le projet dans un dossier 'Build' par exemple, à la racine du projet ( EN DEHORS DU DOSSIER ASSET ) 
4. Lancer le .exe
5. Amusez-vous 😎

## 🌱 Branches
Chaque version stable est associée à une branche nommée selon le schéma suivant :
- `v0.0.1` → version 0.0.1
- `v0.0.2` → version 0.0.2
- `v0.0.3` → version 0.0.3
- ...
Cela permet de suivre l’évolution du jeu, tester les performances ou détecter des bugs introduits.

## 🚀 Objectifs à moyen terme
- Capacités type Valorant (dash, smoke, etc.)
- IA de base (patrouille, tir)
- Environnement plus complexe
- Démo solo complète (v1.0.0)
- (Optionnel) Multijoueur basique

## 📁 Structure du projet
```
Assets/
│
├── Scripts/
│   ├── Player/
│   ├── Combat/
│   └── Interactions/
│
├── Prefabs/
│   ├── Player/
│   ├── Orbs/
│   └── Enemies/
│
├── Scenes/
│   └── Prototype.unity
│
└── UI/
    └── HUD/
```

## 🙌 Crédits / Inspirations
- Valorant (Riot Games)
- Tutoriels Unity FPS Controller
- Brackeys / Sebastian Lague / Code Monkey

---

🧠 *Projet solo pour apprendre, structurer et expérimenter autour d’un gameplay FPS évolutif.*
