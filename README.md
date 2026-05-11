# Room Booking System - WorldSkills 2023 Project

## Introduction

Room Booking System is a project developed during **WorldSkills Kazakhstan 2023**.

The task was to create a system for booking rooms or apartments, similar to platforms such as Airbnb. The project included three separate applications:

- Desktop application
- Mobile application
- Web application

The project was completed within **2 days**, so the main focus was on building the basic structure, user interface, database connection, and core room management features.

Although not all planned functionality was fully implemented, the project demonstrates the ability to quickly develop multiple applications using different technologies under strict time limits.

---

## Project Purpose

The purpose of this project was to create a basic room/apartment booking system for different platforms.

The system allows room information to be added, viewed, edited, or removed depending on the application and user role.

This project was mainly focused on:

- fast application development
- database integration
- basic CRUD operations
- desktop, mobile, and web development
- working under competition time pressure

CRUD means:

```text
Create - add new data
Read   - view existing data
Update - edit existing data
Delete - remove data
```

---

## Applications Developed
## 1. Desktop Application

The desktop application was developed using Windows Forms in Visual Studio with C# .NET.

It was designed mainly for admin use.

## Main Features
- Add room details
- Edit room details
- Remove room details
- View room information
- Manage room data as an admin
- View room details as a user

## Technologies Used
- C#
- .NET
- Windows Forms
- Visual Studio
- Microsoft SQL Server

---

## 2. Mobile Application

The mobile application was developed using PyQt5 with MySQL.

It was created to allow users to view available rooms and apartment details.

Main Features
- View room details
- View room pictures
- Display basic room information for users
- Technologies Used
- Python
- PyQt5
- MySQL

---

## 3. Web Application

The web application was developed using PHP and MySQL.

It allowed users to view available rooms and related images through a browser.

## Main Features
- View room details
- View room pictures
- Display available rooms on a web page

## Technologies Used
- PHP
- MySQL
- HTML
- CSS

## Important Note

The three applications were developed as separate systems.

They do not fully work together as one connected platform because different databases were used during development.

The desktop application uses Microsoft SQL Server, while the mobile and web applications use MySQL.

The mobile and web applications are partly connected because both use MySQL, but they are still not fully integrated as one complete system.

This was mainly due to the limited development time during the competition.

---

## Project Structure

The project includes three main parts:
```text
Room Booking System
│
├── Desktop Application
│   ├── C# .NET
│   ├── Windows Forms
│   └── Microsoft SQL Server
│
├── Mobile Application
│   ├── Python
│   ├── PyQt5
│   └── MySQL
│
└── Web Application
    ├── PHP
    ├── HTML/CSS
    └── MySQL
```
---

## Main Functionalities

The overall project includes the following functionality:
```text
- Add room details
- Edit room details
- Remove room details
- View room information
- View room pictures
- Admin room management
- User room viewing
```

---

## Example Use Case

An admin can use the desktop application to add or update room information, such as room name, description, price, and availability.

Users can then view room details and pictures through the web or mobile application.

Because the applications are not fully integrated, the system works more as a prototype than a complete production-ready booking platform.

---

## Development Time

This project was developed in approximately 2 days during the WorldSkills Kazakhstan 2023 competition.

Due to the limited time, the goal was not to build a fully finished commercial product, but to create a working prototype that demonstrates core functionality across desktop, mobile, and web platforms.

---

## Development Time

This project was developed in approximately 2 days during the WorldSkills Kazakhstan 2023 competition.

Due to the limited time, the goal was not to build a fully finished commercial product, but to create a working prototype that demonstrates core functionality across desktop, mobile, and web platforms.

```text
Desktop app: Basic admin and user room management implemented
Mobile app: Basic room viewing implemented
Web app: Basic room viewing implemented
Full system integration: Not fully implemented
```

---

## Challenges

The main challenge of this project was the time limit.

Building three separate applications within two days required quick planning, fast development, and prioritizing the most important features first.

Another challenge was database integration, because different applications used different database systems.

---

## What I Learned

Through this project, I practiced:
- building applications under time pressure
- developing desktop applications with C# and Windows Forms
- using Microsoft SQL Server
- creating a mobile-style interface with PyQt5
- building a web application with PHP and MySQL
- working with databases
- implementing basic CRUD functionality
- planning a multi-platform system

## Future Improvements

Possible future improvements include:

connect all applications to one shared database
- add real user authentication
- add booking functionality
- add payment functionality
- add search and filtering
- improve the user interface
- add admin dashboard
- improve image upload and storage
- add room availability calendar
- create a proper API for communication between platforms

## Project Background

This project was created during WorldSkills Kazakhstan 2023 as part of a competition task.

The task was to build a room or apartment booking system across different platforms. Even though the final system was not fully completed, creating desktop, mobile, and web applications within two days was a valuable development experience.
