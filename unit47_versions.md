# Plan de Versions – Unit 47

Ce fichier présente l'évolution du jeu *Unit 47* à travers différentes versions, de la v0.0.1 (prototype jouable minimal) à la v1.0.0 (release solo complète). Chaque version est associée à une branche Git dédiée pour garantir la traçabilité et permettre des tests de performance ou de bugs entre versions.

---

## ✅ v0.0.1 – Prototype Jouable Minimal
- Déplacement (marche/course) - OUI
- Saut - OUI
- Vue FPS avec Mouse Look - OUI
- Interaction (collecte d’orbes) - OUI
- Ajout d'une arme simple (tir par raycast, effet visuel, son) - tir par raycast OUI, mais pas de "rendu tir"
- Cibles fixes destructibles - OUI
- UI simple (nb d’orbes collectées, munitions) - OUI
- Petite map test - OUI Map PlayGroundTest + Map1

---

## 🔜 v0.0.2 – Premiers Effets et Polish
- Ajout d’effets sonores (tir, orbe, cible détruite)
- Ajout d’effets visuels (muzzle flash, hit effect, orbe collecte)
- Ajout de particules (orbe, cible détruite)
- HUD avec barre de vie ou effets visuels au tir
- Écran titre simple ("Press F to start")
- Légère amélioration de la map (visuels, lumières)

---

## 🔜 v0.0.3 – Premières Compétences
- Implémentation d’une capacité simple (Dash, Flash ou Smoke)
- Ajout d’un cooldown
- UI pour la compétence (icône, cooldown)
- Refonte de l’Input pour gérer plusieurs actions

---

## 🔜 v0.1.0 – Démo Jouable
- Scène plus grande
- Objectifs de mission (collecte d’orbes, destruction de cibles)
- Timer et score final
- Menu de fin de partie (Retry / Quit)
- Ajout potentiel d’une deuxième arme ou compétence

---

## 🔜 v0.2.0 – Ennemis Simples
- Ennemis fixes tirant à intervalle
- Barre de vie joueur
- Respawn ou fin de partie en cas de mort
- Map intégrant des zones de danger

---

## 🔜 v0.3.0 – AI Simple & Patrouille
- Bot en patrouille réagissant à la détection
- Tir lent ou poursuite
- Ajout de murs/couvertures à utiliser

---

## 🔜 v0.4.0 – Mode Entraînement
- Score, combo, précision
- Cibles apparaissant aléatoirement
- Limite de temps
- UI d’évaluation à la fin

---

## 🔜 v0.5.0 – Base Multijoueur (optionnel)
- Synchronisation des joueurs (Mirror ou Netcode)
- Synchronisation des tirs
- Lobby simple
- Map jouable en duo

---

## 🔜 v1.0.0 – Release Solo
- Menus complets
- Sauvegarde des scores
- 2-3 niveaux jouables
- 2-3 compétences
- Ennemis variés
- Musique et ambiance
