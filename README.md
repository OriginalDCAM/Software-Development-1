# Software-Development-1
Wpf applicatie voor het vak software development 1.

## Author:
Student naam: Denzel Camelia \
Student nummer: s1175200


## TODO(Required):
- [ ] Search bar for Authors and Books

## TODO(Nice to Haves):
- [ ] Async/Await on getting data from database
- [ ] Model validation for duplicate entries

## Functional Requirements Done:
- [x] Add a ViewModel to the Main Window
- [x] Crud for Authors
- [x] Crud for Books
- [x] Implement Commands for navigating to certain pages
- [x] Create a Interactable data grid for all the Authors and Books 


## Technical Requirements Done:
- [x] Implemented Seeding
- [x] The use of Entity Framework
- [x] The use of Migrations
- [x] The use of MVVM Structure
- [x] Better validation to ensure that certain requirements are met
- [x] Validation using ValidateProperties


## Explanations:
- Heb ervoor gekozen om INotifyPropertyChanged implementatie in een aparte class te zetten, 
zodat ik die kan implementeren op andere klasse zonder de code weer opnieuw te typen.
- Heb ervoor gekozen om de Booktypes/Genres in een apart bestand te zetten zodat ik niet helemaal
hoef te navigeren in de class bij het inserten van genres.
- Heb ervoor gekozen om de INotifyDataErrors interface te implementeren bij CreateAuthorViewModel voor
betere manier van properties valideren.
- Heb ervoor gekozen om andere Classes te gebruiken zoals Auteurs en Boeken omdat ik een soort bibliotheek applicatie wil maken, daarom heb ik 
de database geseed met data van bekende auteurs en de boeken die zij hebben geschreven.
