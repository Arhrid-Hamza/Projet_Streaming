# TODO: Add Views for Models with CSS and JavaScript

## Overview
- Create MVC controllers (inheriting from Controller) for each model with CRUD actions (Index, Details, Create, Edit, Delete).
- Create corresponding Razor views in Views/{Model} folders.
- Style views using Bootstrap and custom CSS in wwwroot/css.
- Add JavaScript for interactivity (e.g., form validation, AJAX) in wwwroot/js.
- Update _Layout.cshtml for navigation to model views.
- Update routing if necessary.

## Models to Handle
- Utilisateur
- Abonne
- Admin
- SuperAdmin
- Guest
- Profil
- Historique
- Rating
- Watchlist
- Film
- Serie
- Episode
- Categorie
- Genre
- ContentGenre
- Abonnement
- Paiement

## Steps
- [x] Update _Layout.cshtml to add navigation links for each model.
- [x] Enhance wwwroot/css/site.css with custom styles for views (e.g., tables, forms).
- [x] Enhance wwwroot/js/site.js with common JS functions (e.g., confirmation dialogs, AJAX for delete).
- [x] Create MVC controller for Utilisateur with CRUD actions.
- [x] Create Views/Utilisateur folder and Razor files (Index, Details, Create, Edit, Delete).
- [x] Repeat for Abonne.
- [ ] Repeat for Admin.
- [ ] Repeat for SuperAdmin.
- [ ] Repeat for Guest.
- [ ] Repeat for Profil.
- [ ] Repeat for Historique.
- [ ] Repeat for Rating.
- [ ] Repeat for Watchlist.
- [ ] Repeat for Film.
- [ ] Repeat for Serie.
- [ ] Repeat for Episode.
- [ ] Repeat for Categorie.
- [ ] Repeat for Genre.
- [ ] Repeat for ContentGenre.
- [ ] Repeat for Abonnement.
- [ ] Repeat for Paiement.

## Followup Steps
- [ ] Build the project to check for errors.
- [ ] Run the app and test each view for functionality.
- [ ] Ensure responsive design with CSS.
- [ ] Test JavaScript features (e.g., AJAX deletes).
