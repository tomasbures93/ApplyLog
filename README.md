# Apply Log ( v2.0 )

**ApplyLog** is a web-based application designed to support your entire job-hunting journey — from managing applications to generating cover letters. You can save and track job applications, organize your workflow with a built-in TODO list, and gain visual insights using Google ChartsAPI. With Leaflet integration, you can view all application locations on an interactive map. The app also lets you search for open positions via the Agentur für Arbeit API and even generate personalized cover letters powered by Gemini 2.0 Flash API. Whether you're just starting your search or managing multiple applications, Apply Log helps you stay organized, informed, and one step ahead.

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
- Gemini 2.0 Flash API


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

## 📄 License
This project is licensed under the MIT License – see the LICENSE file for details.

## 🖼️ Screenshots
- Version 1.0
![screencapture-localhost-5225-2025-04-27-20_46_44](https://github.com/user-attachments/assets/de3928d6-f80c-4bcb-8b9b-3699968b712e)
![image](https://github.com/user-attachments/assets/1a326405-76db-4d13-8f26-ba54117dd809)



