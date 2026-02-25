🎨 Art Gallery App

A desktop-based Art Gallery Management Application developed using C# WinForms and SQL Server, designed to simulate a modern digital art museum experience with both curated artworks and user-generated content.

This project focuses on UI/UX details, user interaction, and relational database design, and represents my first complete end-to-end desktop application.

🚀 Features
🔐 First Login Experience

Users are greeted with a custom-designed first login form

Required inputs:

Full Name (character-limited, validated)

Gender (ComboBox)

Age (ComboBox)

All fields are mandatory; users cannot proceed without completing them

UI details include:

Custom icons

Minimalist input lines (custom textbox styling)

Handcrafted layout (not default WinForms look)

🏠 Home Page

A visually rich homepage with a custom background video

Video was created in Adobe After Effects (combined clips + effects) and integrated into the application

Navigation bar includes:

Home

About

Categories

Artworks

Famous Artists

User Artworks

Central “Add Artwork” button for quick access

ℹ️ About Page

Short introduction about the application

Includes art-related quotes from well-known artists

Right-side navigation button to switch between content sections

Designed to feel like a digital museum info panel

🗂 Categories

Users can explore artworks under three curated categories:

🖼 Old Masters

Redirects to the Artworks page

Displays ~20 of the most iconic artworks in history

Hover effects show:

Artwork title

Artist

Creation year

Short descriptive fact

Vertical scrolling supported

🎨 Modern Art

Opens a dedicated page (not in navbar)

White background, modern layout

Displays:

Artwork images

Titles

Years

Exhibition locations

🇹🇷 Turkish Art

Displays traditional Turkish artworks

Shows:

Artwork name

Artist name

Birth and death years

Focus on cultural heritage

🖌 Artworks

Central gallery of world-famous artworks

Clean dark-themed UI

Hover-based “Read more” interactions

Smooth scrolling experience

👨‍🎨 Famous Artists

Displays artist names in a horizontal layout

Hovering over a name:

Reveals artwork visuals

Shows animated underline effect (left-to-right)

Carefully designed animations and spacing

👤 User Artworks (SQL-powered)

This is the core backend-driven feature of the application.

🔹 What users can do:

View artworks added by all users

Add new artworks via Add Artwork page

Upload images from local system

Save artwork details to database

🔹 Permissions:

Users can only update or delete their own artworks

Other users’ artworks are read-only

➕ Add Artwork Page

Not accessible from navbar (intentional UX decision)

Accessible via Home → Add Artwork

Required fields:

Username

Artwork Name

Artwork Owner

Image upload

Validation prevents empty submissions

Success feedback shown after save

🗄 Database Design

SQL Server 2022 (Express) is used.

Tables
Users
Column	Type
UserID	INT (PK)
FullName	NVARCHAR(100)
Age	INT
Gender	NVARCHAR(20)
CreatedAt	DATETIME
Artworks
Column	Type
ArtworkID	INT (PK)
Title	NVARCHAR(100)
ImagePath	NVARCHAR(255)
UserID	INT (FK)
CreatedAt	DATETIME

Foreign Key relationship between Users and Artworks

ON DELETE CASCADE enabled

Clean relational design suitable for scaling

The full schema is available under:

/database/ArtGalleryDB.sql
🛠 Technologies Used

C# (.NET Framework)

Windows Forms (WinForms)

SQL Server 2022 Express

ADO.NET (SqlConnection, SqlCommand)

Adobe After Effects (custom video content)

Git & GitHub

📐 Architecture Notes

Extensive use of UserControls for modular UI

Centralized database access via DatabaseHelper

Separation between:

UI logic

Data access

Focus on maintainability and readability rather than shortcuts

🎯 Project Motivation

This project was built to:

Push beyond basic CRUD examples

Focus on visual quality, interaction, and user experience

Combine my interests in software development, art, and design

Apply both programming and creative skills in a single application

It represents my transition from small exercises to a complete, real-world-style desktop application.

📸 Screenshots

Screenshots are included in the repository to demonstrate:

UI design

Navigation

Artwork galleries

User artwork management

(Animated demo video is hosted externally due to GitHub file size limits.)

📌 Notes

This is my first published application

Built with attention to detail and long-term learning in mind

Open to refactoring and improvements

🎥 Home page Video

**Homepage Video (After Effects):** https://drive.google.com/file/d/18iV_s2Eqjokp7De2lU3G1XD49rd7keSE/view?usp=drive_link