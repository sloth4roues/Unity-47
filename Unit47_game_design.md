## Game Design Doc - Unit-47 (JoJo Inspired FPS)

---

### GLOBAL BALANCE SHEET
(VALORANT-LIKE Reference)

**Vitesse déplacement** :
- Marche : 4.4 m/s
- Sprint : 6.4 m/s
- Gravité : 9.81 m/s²
- Hauteur saut max : 2.2m
- Hauteur saut accroupi : 1.3m
- Temps de recharge compétence basique : 20-45s selon agent
- Points d’ultime requis : 7
- PV Agent : 100HP
- Bouclier si disponible : 50HP max

---

## AGENTS DESIGN DÉTAILLÉ

### DIO - The World

**Rôle :** Assassin / Contrôle léger

**Compétence 1 : Time Dash**
- Effet : Dash instantané de 5m dans la direction du déplacement.
- Charge : 2
- Recharge : 20s par charge
- Cast Time : 0.1s
- Endlag : 0.3s
- Visuel : légère distorsion du temps visible pour l’ennemi.

**Compétence 2 : Time Trace**
- Effet : Pendant 5s, Dio peut voir les traces rouges des ennemis dans un rayon de 20m. Traces récentes = rouge vif, anciennes = rouge sombre.
- Recharge : 35s
- Cast Time : 0.3s

**Ultimate : The World Stop**
- Effet : Pendant 10s, Dio devient invincible (mais peut être touché). S’il reçoit une balle durant cette période, l’attaquant est figé 5s (stun total, incapable d’agir).
- Points requis : 7
- Durée de figé ennemi : 5s max
- Cast Time : 1.0s

---

### KIRA - Killer Queen

**Rôle : Contrôle / Damage Dealer**

**Compétence 1 : First Bomb (Contact Bomb)**
- Effet : Pose une bombe sur une surface dans un rayon de 2m. Détonation manuelle (comme C4).
- Dégâts : 90 (rayon max) à 30 (bord zone)
- CD : 25s
- Charges : 1
- PV de la bombe : 100HP

**Compétence 2 : Second Bomb (Sheer Heart Attack)**
- Effet : Déploie une bombe roulante autonome. Traque la chaleur et accélère si un ennemi est proche.
- PV : 120HP
- Vitesse : 2m/s, 4m/s en poursuite
- Dégâts explosion : 70
- Recharge : 40s

**Ultimate : Third Bomb (Bite The Dust)**
- Effet : Si Kira est à <15HP et déclenche l’ultime, il revient 30 secondes en arrière (position et PV).
- Points requis : 7
- Cast Time : 0.8s
- Limite : 1 fois par manche

---

### DIAVOLO - King Crimson

**Rôle : Contrôle / Information**

**Compétence 1 : Epitaph Scan**
- Effet : Marque la position des ennemis dans un rayon de 20m deux fois : 1s après activation, puis après 5s. Marquage discret rouge visible par les ennemis.
- Recharge : 35s
- Cast Time : 0.3s

**Compétence 2 : Time Skip Dash**
- Effet : Dash temporel de 8m, invincible durant l’animation (0.5s) mais pas de tir pendant 0.5s après.
- Recharge : 30s
- Cast Time : Instantané
- Endlag : 0.5s vulnérable

**Ultimate : King Crimson**
- Effet : Ignore toute source de dégâts/détection (caméras, bombes, balises) pendant 3 secondes. Peut tirer normalement durant l'effet.
- Points requis : 6
- Cast Time : 0.3s
- Immunité durée : 3s

---

### JOTARO - Star Platinum

**Rôle : Dueliste / Contrôle léger**

**Compétence 1 : Precision Reflex**
- Effet : Pendant 6 secondes, toutes les armes voient leur précision améliorée (dispersion réduite de 20%).
- Recharge : 25s
- Cast Time : Instantané

**Compétence 2 : Bullet Catch**
- Effet : Pendant 3s, réduit les dégâts frontaux de 50% (pas de blindage total).
- Recharge : 35s
- Cast Time : Instantané

**Ultimate : Star Platinum: The World**
- Effet : Arrête le temps pour lui pendant 4s. Peut recharger, se repositionner, changer d’arme — mais pas tirer.
- Points requis : 7
- Cast Time : 0.5s

---

### JOSUKE - Crazy Diamond

**Rôle : Support / Utility**

**Compétence 1 : Restore**
- Effet : Soigne un allié de 30HP OU répare un objet interactif à portée 5m.
- Recharge : 30s

**Compétence 2 : Fix Bullet**
- Effet : Recharge instantanément le chargeur d’un allié à portée 5m (sans toucher à la réserve).
- Recharge : 45s

**Ultimate : Full Restore**
- Effet : Soigne tous les alliés dans 20m de 30HP et donne +33% vitesse pour 3s.
- Points requis : 7
- Cast Time : 1s

---

### GIORNO - Gold Experience Requiem

**Rôle : Contrôle / Support / Dueliste**

**Compétence 1 : Life Creation (Rework)**
- Effet : Crée un mur de vigne destructible (400HP) qui bloque la vision, les balles et ralentit les ennemis de 20% pendant 2s.
- Durée : 12s
- Recharge : 30s
- Cast Time : 0.5s

**Compétence 2 : Life Transfer**
- Effet : Soigne un allié ciblé de 60HP.
- Recharge : 35s
- Cast Time : 1s

**Ultimate : Gold Experience Requiem**
- Effet : Pendant 8s :
  - Annule tous debuffs entrants.
  - Vitesse +15%
  - Recul réduit de 10%
  - Cadence de tir +10%
  - Recharge immédiate de ses deux compétences.
- Points requis : 7
- Cast Time : 0.5s

---

(Prochaine section : Cartes, armes, économie si souhaité.)

