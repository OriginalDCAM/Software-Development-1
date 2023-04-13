# Software-Development-1
Wpf applicatie voor het vak software development 1.

## Author:
Student naam: Denzel Camelia \
Student nummer: s1175200


## TODO(Required):
- [ ] Search bar for Authors and Books
- [ ] Create a Interactable data grid for all the Authors and Books 

## TODO(Nice to Haves):
- [ ] Async/Await on getting data from database

## Functional Requirements Done:
- [x] Add a ViewModel to the Main Window
- [x] Crud for Authors
- [x] Crud for Books
- [x] Implement Commands for navigating to certain pages


## Technical Requirements Done:
- [x] Implemented Seeding
- [x] The use of Entity Framework
- [x] The use of Migrations
- [x] The use of MVVM Structure
- [x] Better validation to ensure that certain requirements are met
- [x] Validation using ValidateProperties


## Explanations:
- Ik heb ervoor gekozen om INotifyPropertyChanged implementatie in een aparte class te zetten, 
zodat ik die kan implementeren op andere klasse zonder de code weer opnieuw te typen.
- Ik heb ervoor gekozen om de Booktypes/Genres in een apart bestand te zetten zodat ik niet helemaal
hoef te navigeren in de class bij het inserten van genres.
-Ik heb ervoor gekozen om de INotifyDataErrors interface te implementeren bij CreateAuthorViewModel voor
betere manier van properties valideren.
