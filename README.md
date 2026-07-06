🎨 Art Gallery App

A desktop-based **Art Gallery Management Application** developed using **C# WinForms** and **SQL Server**, designed to present a modern digital art gallery experience that combines curated artworks with user-generated content.

This project focuses on **UI/UX design decisions**, **user interaction**, and **relational database structure**, and demonstrates a complete end-to-end desktop application workflow.

> [!IMPORTANT]
> **Source Code & Commercial Use**
>
> The source code is not publicly available.
>
> If you are an employer interested in reviewing the implementation, or a client interested in purchasing or licensing this project, please feel free to contact me.
>
> 📧 **Email:** bedirhan.elcik@stu.fbu.edu.tr
> 🔗 **LinkedIn:** https://www.linkedin.com/in/bedirhanelcik/

## ✨ Key Capabilities

- Custom first-login flow with mandatory user input validation
- Museum-style UI with custom layouts and hover interactions
- Categorized art exploration (historical, modern, and cultural)
- User-generated artwork system with ownership-based permissions
- Relational SQL Server database design with referential integrity
- Clean and maintainable WinForms project structure


## 🔐 First Login Experience

The application starts with a **custom-designed first login screen**.

Required inputs:
- Full Name (character-limited and validated)
- Gender (ComboBox)
- Age (ComboBox)

All fields are mandatory and must be completed before accessing the application.  
The interface intentionally avoids default WinForms components and applies minimalist input styling, icons, and spacing to create a polished first impression.


## 🏠 Home & Navigation

- A custom navigation bar provides access to:
  - Home
  - About
  - Categories
  - Artworks
  - Famous Artists
  - User Artworks
- A centrally placed **Add Artwork** action is intentionally separated from the navigation flow for UX clarity.

The homepage includes a **custom background video**, produced externally and integrated into the application to enhance visual atmosphere.


## 🗂 Art Categories

Users can explore artworks through three curated categories:

### Old Masters
- Redirects to the main Artworks gallery
- Features iconic historical artworks
- Hover interactions display title, artist, year, and contextual notes
- Vertical scrolling supported

### Modern Art
- Opens a dedicated page outside the main navigation
- Clean white background with a modern layout
- Displays artwork visuals, titles, years, and exhibition locations

### Turkish Art
- Focuses on culturally significant Turkish artworks
- Displays artwork name, artist, and birth–death years


## 🖼 Artworks & Famous Artists

### Artworks
- Central gallery of world-famous artworks
- Dark-themed presentation
- Hover-based “Read more” interactions
- Smooth scrolling for large collections

### Famous Artists
- Artist names displayed horizontally
- Hovering reveals related artwork visuals and animated underline transitions
- Designed to remain interactive without overwhelming the user


## 👤 User Artworks (Database-Driven)

This section represents the **core data-driven functionality** of the application.

Users can:
- View artworks added by all users
- Add new artworks with image uploads
- Update or delete **only their own artworks**

Ownership rules are enforced logically:
- Everyone can view content
- Only the creator can modify or remove their entries


## ➕ Add Artwork Flow

- Accessible via Home (not included in the navigation bar by design)
- Required fields:
  - Username
  - Artwork Name
  - Artwork Owner
  - Image upload
- Validation prevents incomplete submissions
- Successful saves persist data to the database and update the User Artworks view


## 🗄 Database Design

The application uses **SQL Server 2022 Express** with a relational schema.

- **Users** (Primary Key: UserID)
- **Artworks** (Primary Key: ArtworkID, Foreign Key: UserID)

A foreign key relationship ensures referential integrity with appropriate cascade rules.

Database schema:

/database/ArtGalleryDB.sql



## 🛠 Technologies Used

- C# (.NET Framework)
- Windows Forms (WinForms)
- SQL Server 2022 Express
- ADO.NET (SqlConnection, SqlCommand)
- Adobe After Effects (visual content production)
- Git & GitHub


## 📁 Project Structure


ArtGalleryApp1/
├─ Forms/ → Main application screens
├─ UserControls/ → Reusable UI components
├─ Helpers/ → Database and utility helpers
├─ Images/ → Static visual assets
├─ database/ → SQL schema
├─ screenshots/ → Application screenshots
└─ Program.cs → Application entry point



## 📸 Screenshots & Presentation Notes

Due to the nature of desktop applications and GitHub file size limitations, this project is presented through screenshots.

Screenshots included in the repository demonstrate:
- Login flow
- Navigation and category pages
- Artwork galleries
- User artwork management



## 🔮 Future Improvements

- User authentication system
- Role-based permissions
- Pagination for large artwork collections
- Image optimization and caching
- Migration to modern .NET or WPF architecture



## 👤 Author

**Bedirhan Elçik**  
MIS (Management Information Systems) – 3rd Year  

Focus areas: **Frontend and Backend Fundamentals**
