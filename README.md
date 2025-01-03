# TP 7 Clean Architecture - Projet .NET Web API
---
### Groupe : GL3 Groupe 1
- Nour Ayari 
- Eya Mhamdi
- Ahmed Amin Chabbah 
- Moetez Souilem

## Description du Projet
Ce projet met en œuvre l'architecture Clean dans une application Web API .NET. Il s'agit de migrer une application existante de type MVC vers une architecture Clean, avec une séparation claire des responsabilités entre les différentes couches : Domaine, Application, Infrastructure, et Présentation.

## Fonctionnalités Principales
- **Gestion des clients** : Ajouter, supprimer, mettre à jour et consulter les clients.
- **Films favoris** : Permettre à un client de consulter et de gérer ses films favoris.
- **Classification par genre** : Filtrer les films selon leur genre.
- **Avis et évaluations** : Ajouter des avis et des évaluations aux films.
- **Calcul des moyennes** : Calculer la moyenne des notes d’un film.
- **Gestion des films** : Ajouter, supprimer, mettre à jour et consulter les films.

## Endpoints de l'API
### Gestion des Clients
- **Liste des clients**  
  `GET /api/customers`  
  Renvoie la liste de tous les clients.

- **Consulter les films favoris d’un client**  
  `GET /api/customers/{id}/favorite-movies`  
  Renvoie les films favoris d’un client spécifique.

- **Ajouter un film aux favoris**  
  `POST /api/customers/{id}/favorite-movies`  
  Ajoute un film à la liste des favoris d’un client.

- **Mettre à jour un client**  
  `PUT /api/customers/{id}`  
  Modifie les informations d’un client.

- **Supprimer un client**  
  `DELETE /api/customers/{id}`  
  Supprime un client de la base de données.

### Gestion des Films
- **Liste des films**  
  `GET /api/movies`  
  Renvoie tous les films disponibles.

- **Classer les films par genre**  
  `GET /api/movies/genre/{genre}`  
  Renvoie les films d’un genre spécifique.

- **Ajouter un film**  
  `POST /api/movies`  
  Ajoute un nouveau film.

- **Mettre à jour un film**  
  `PUT /api/movies/{id}`  
  Modifie les informations d’un film.

- **Supprimer un film**  
  `DELETE /api/movies/{id}`  
  Supprime un film de la base de données.

- **Consulter un film spécifique**  
  `GET /api/movies/{id}`  
  Renvoie les détails d’un film (avis, moyenne des notes).

- **Ajouter un avis sur un film**  
  `POST /api/movies/{id}/review`  
  Ajoute un avis et une évaluation à un film.

- **Calculer la moyenne des notes d’un film**  
  `GET /api/movies/{id}/average-rating`  
  Calcule et renvoie la moyenne des notes d’un film.

## Architecture Clean
Le projet suit une architecture en couches, chaque couche ayant des responsabilités distinctes :


## Description des Couches de l'Architecture

### 1. Domaine (Domain Layer)
Cette couche contient les règles métiers principales, les entités, et les interfaces des repositories. Elle représente la logique centrale de l'application, sans dépendre des technologies externes.

#### Contenu
- **Entités** : Objets métiers avec les propriétés et comportements principaux.  
  - **Customer** : Contient les propriétés d'un client (ID, nom, etc.) et ses films favoris.
  - **Movie** : Représente un film, avec des propriétés telles que le titre, le genre, etc.
  - **Review** : Représente un avis ou une évaluation sur un film.
- **Interfaces** : Définitions des méthodes pour accéder aux données ou exécuter des actions métiers.  
  - **ICustomerRepository** : Interface pour les opérations liées aux clients.
  - **IMovieRepository** : Interface pour les opérations liées aux films.
  - **IRepository<T>** : Interface générique pour les repositories.

---

### 2. Application (Application Layer)
Cette couche détermine la logique métier et interagit avec les entités du domaine sans dépendance directe à la couche Infrastructure. Elle définit des services qui exécutent des actions spécifiques pour l'utilisateur ou le système.

#### Contenu
- **Services d'Application** : Classes qui encapsulent la logique des services métiers.
- **Interfaces des Services d'Application** : Définissent les services exposés.  
  - **ICustomerService** : Interface pour les services liés aux clients.
  - **IMovieService** : Interface pour les services liés aux films.

---

### 3. Infrastructure (Infrastructure Layer)
Cette couche gère l'accès aux données, la configuration des bases de données, la gestion des connexions, et l'implémentation des interfaces définies dans les couches Domaine et Application. Elle permet les interactions avec les systèmes externes.

#### Contenu
- **AppDbContext (EF Core)** : Classe représentant la session de travail avec la base de données.
- **Repositories** : Classes concrètes qui implémentent les interfaces des repositories.  
  - **CustomerRepository** : Implémentation de l'interface ICustomerRepository pour interagir avec les données des clients.
  - **MovieRepository** : Implémentation de l'interface IMovieRepository pour interagir avec les données des films.

---

### 4. Présentation (Web API Layer)
Cette couche contient les contrôleurs API, qui servent de point d'entrée pour les requêtes HTTP. Elle est responsable de la gestion des demandes des utilisateurs et de la présentation des données via des API RESTful.


## Installation et Configuration

### Étapes d’installation

1. Clonez le dépôt :
   ```bash
   git clone [URL-DU-REPOSITORY]
   ```

2. Naviguez dans le dossier du projet :
   ```bash
   cd project-name
   ```

3. Restaurez les dépendances :
   ```bash
   dotnet restore
   ```

4. Configurez la base de données dans `appsettings.json`.

5. Appliquez les migrations :
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

6. Lancez l’application :
   ```bash
   dotnet run
   ```

L’API sera accessible à l’adresse : `http://localhost:5000`.

## Packages Utilisés
- **Entity Framework Core** : Gestion de la base de données.
  ```bash
  Install-Package Microsoft.EntityFrameworkCore
  Install-Package Microsoft.EntityFrameworkCore.Tools
  Install-Package Microsoft.EntityFrameworkCore.SqlServer
  ```
- **Swagger** : Documentation interactive des API.
  ```bash
  dotnet add package Swashbuckle.AspNetCore
  ```

