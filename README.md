# Apply Log

**ApplyLog** is a web-based application designed to support your entire job-hunting journey — from managing applications to generating cover letters. You can save and track job applications, organize your workflow with a built-in TODO list, and gain visual insights using Google ChartsAPI. With Leaflet integration, you can view all application locations on an interactive map. The app also lets you search for open positions via the Agentur für Arbeit API and even generate personalized cover letters powered by Gemini 2.0 Flash API. Whether you're just starting your search or managing multiple applications, Apply Log helps you stay organized, informed, and one step ahead.

- Last Update : 12.06.2025

![Repository](https://img.shields.io/badge/ASP.NET_Core-MVC-blue)
![EntityFramework](https://img.shields.io/badge/EntityFramework-Core-green)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.x-purple?logo=bootstrap)
![License](https://img.shields.io/github/license/tomasbures93/ApplyLog)

## 🚀 Tech Stack

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL / SQLite
- Bootstrap 5
- Leaflet Library
- DocX Library
- Google ChartsAPI
- Arbeitsagentur Jobsuche API
- Gemini 2.0 Flash API ( You need your **OWN API KEY** )


## ✨ Features

- ✅ Create, edit, and delete job applications
- 📌 Track the status of each application
- 📝 Manage your personal TODOs to keep track of tasks
- 🔍 Search TODOs by name or applications by company name
- 🌍 Leaflet for geographical data
- 📊 Visualize data with Google ChartsAPI:
  - 🥧 PieChart for visualizing task distribution
- 🔍 Integration with Arbeitsagentur Jobsuche API – Search for jobs and view basic information directly in the app
- 💻 Integrated Gemini 2.0 Flash API (Generate your Cover Letter and Download it)
- 👤 User authentication and authorization with ASP.NET Core Identity


## 📅 Planned Features / Roadmap

- Nothing for now

## Changelog
- 12.06.2025
  - Fixed a bug where users were not able to Download generated CV/Cover Letter
- 10.06.2025
  - User can save info about his Work Experience
    - Work Experience
    - Schools he attended
    - Languages he can speak
    - And basic info about him
  - With that info user can Generate curriculum vitae with help of Gemini 2.0 Flash API
  - Small Redesign here and there
- 08.06.2025
  - Integration of DocX librabry to download Cover Letter as .docx document
  - Index Page looks different if user is not logged in
- 06.06.2025
  - Deleted Google GeoCharts
  - Used Leaflet for show location on the map
  - Used https://github.com/pensnarik/german-cities for German city Longtitude and Latitude
  - Gemini API connected to the application - You can generate simple Cover Letters now
- 05.06.2025
  - User can save his favorite Jobs from AgenturFürArbeit API
  - Small design rework ( Bootstrap icons )
  - Todos can be fast marked as Complete
- 29.05.2025
  - Todo Class rework
    - Added Status of Todo ( Open / Complete )
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

## 💻 Getting Started

1. Clone the repository:

   git clone https://github.com/tomasbures93/ApplyLog.git
2. Open the solution in Visual Studio or your preferred IDE.

3. Go to Program.cs and setup your prefered way of Database ( SQL or SQLite )

3. Run the application

## 🖼️ Screenshots
- Version 2.0
![screencapture-localhost-5225-2025-06-10-20_26_40](https://github.com/user-attachments/assets/17b80391-bce6-40ba-a961-ceacbbdca050)
![screencapture-localhost-5225-AI-2025-06-10-20_26_54](https://github.com/user-attachments/assets/b11daa15-970d-4559-b4e7-586741157064)
![screencapture-localhost-5225-JobSearch-2025-06-10-20_27_06](https://github.com/user-attachments/assets/bd51ab90-84e9-4d6c-9b51-10525b316c60)




