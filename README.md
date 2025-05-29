# Apply Log ( v1.4 )

**Apply Log** is a simple web application that helps you stay organized during your job hunt. You can save your job applications, track their status, and manage a personal TODO list to ensure you never miss a step. It also integrates Google ChartsAPI for visual data representation.

![Repository](https://img.shields.io/badge/ASP.NET_Core-MVC-blue)
![EntityFramework](https://img.shields.io/badge/EntityFramework-Core-green)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.x-purple?logo=bootstrap)
![License](https://img.shields.io/github/license/tomasbures93/ApplyLog)

## Changelog
- 29.05.2025
  - Todo Class rework
    - Added Status of Todo (Open / Complete)
    - DatePicker fixed ( we dont need exact Time, Date should do)
    - Now you can switch between Open and Completed Todos on Todo/Index
  - Application Class rework
    - Reworked Result of Application
    - Added JobType (Full Time / Part Time / Internship / Contract )
    - Added Date of Interview
    - Added LastUpdate (for future use)
  - Added Logout button
- 22.05.2025
  - Identity Added ( User can Register and Login )
  - Added an option between SQLite and SQLserver

## ✨ Features

- ✅ Create, edit, and delete job applications
- 📌 Track the status of each application
- 📝 Manage your personal TODOs to keep track of tasks
- 🔍 Search TODOs by name or applications by company name
- 📊 Visualize data with Google ChartsAPI:
  - 🌍 GeoChart for geographical data
  - 🥧 PieChart for visualizing task distribution and application stats
- 🔍 Integration with Arbeitsagentur Jobsuche API – Search for jobs and view basic information directly in the app

## 📅 Planned Features / Roadmap

Here's what’s coming in future versions of Apply Log
- 1.5	👤 User Accounts – Register and log in to your own account
  - 💼 Save Favorites – Mark jobs as favorites to view later
  - 📎 Document Storage – Upload and manage your CV and other documents ( maybe )
- 1.9 💻 Responsive Design
- 2.0	📄 Job Detail View – See detailed job descriptions for results from the Jobsuche API , second API for more job listings

## 🚀 Tech Stack

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL / SQLite
- Bootstrap 5
- Google ChartsAPI 
- Arbeitsagentur Jobsuche API

## 💻 Getting Started

1. Clone the repository:

   git clone https://github.com/tomasbures93/ApplyLog.git
2. Open the solution in Visual Studio or your preferred IDE.

3. Go to Program.cs and setup your prefered way of Database ( SQL or SQLite )

3. Run the application

## 📄 License
This project is licensed under the MIT License – see the LICENSE file for details.

## 🖼️ Screenshots
- Version 1.0
![screencapture-localhost-5225-2025-04-27-20_46_44](https://github.com/user-attachments/assets/de3928d6-f80c-4bcb-8b9b-3699968b712e)
![image](https://github.com/user-attachments/assets/1a326405-76db-4d13-8f26-ba54117dd809)



