# Animal Registry

## Context

* **Origin** Developed as part of the second C# course at Malmö University.
* **Objective** This desktop application lets the user build an animal registry.
* **Status** 🟢 Complete/Functional

---

## Systems Architechture

* **Logic** MVC-inspired OOP architechture with event driven UI updates through observables.
* **Tech Stack** C# WPF + XAML
* **Data Persistance** JSON + XML Serialization

---

## Functionality

* Add animals
  - Name
  - Age
  - Gender
  - Eater type
  - Domesticated y/n
  - Image
* Add food items
  - Name
  - Details
* Click a category to view the species within
* Click a species to view the specific animals added as that species
* View specific information for an animal
* Connect animals to food items

---

## Setup & Usage

1. Clone the repository
2. Open in IDE of your choice
3. Add animals and food items
4. Track all your wild and domesticated animals!

---

## Learning Outcomes

* Native Windows C# WPF desktop application development
* Event driven UI updates
* Working with observable collections
* Inheritence and polymorphism (animal -> categories -> species)
  - Object to object-mapping
  - Encapsulation
