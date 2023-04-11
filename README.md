# Software-Development-1
Wpf applicatie voor het vak software development 1.

## Author:
| Denzel Camelia | s1175200


## TODO(Required):
- [ ] Search bar for Authors and Books
- [ ] Create a Datagrid for all the Authors and Books 
- [ ] Better validation to ensure that certain requirements are met

## TODO(Nice to Haves):
- [ ] Validation using ValidateProperties
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


## Explanation:
- Heb ervoor gekozen om INotifyPropertyChanged implementatie in een aparte class te zetten, 
zodat ik die kan implementeren op andere klasse zonder de code weer opnieuw te typen.
- Ook heb ik ervoor gekozen om de Booktypes/Genres in een apart bestand te zetten zodat ik niet helemaal
hoef te selecteren in die class (Type dit nog even uit)