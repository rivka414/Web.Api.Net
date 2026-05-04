# Queue Management System - Web API

מערכת Web API מתקדמת לניהול תורים, שפותחה בטכנולוגיות .NET ו-C# תוך הקפדה על סטנדרטים גבוהים של הנדסת תוכנה וקוד נקי.

## 🚀 אודות הפרויקט

הפרויקט מהווה פתרון צד-שרת מקיף לניהול תורים ולקוחות, המתוכנן לעבודה בעומסים גבוהים ותמיכה בסקלביליות. המערכת נבנתה בגישת **Clean Architecture** המפרידה בין שכבות הלוגיקה, הנתונים והתשתית, מה שמבטיח תחזוקתיות קלה ויכולת הרחבה עתידית.

## 🛠 טכנולוגיות וכלים

*   **Framework:** .NET Core API
*   **Database:** SQL Server (EF Core Code First)
*   **Patterns:** Repository Pattern, Unit of Work
*   **Mapping:** AutoMapper (DTOs)
*   **Security:** JWT Authentication
*   **Asynchronicity:** Async/Await Programming
*   **Architecture:** Clean Architecture & Dependency Injection

## 🏗 ארכיטקטורה ועקרונות פיתוח

המערכת מבוססת על מספר עקרונות ודפוסי עיצוב מתקדמים:

*   **Clean Architecture:** הפרדה מוחלטת בין שכבת ה-Core (Domain/Application) לבין שכבות ה-Infrastructure וה-API.
*   **Entity Framework Core:** שימוש בגישת **Code First** לניהול בסיס הנתונים וביצוע Migrations בצורה מבוקרת.
*   **Repository & Unit of Work:** ניהול גישה לנתונים בצורה גנרית המאפשרת החלפה קלה של מקורות מידע ושמירה על עקביות הנתונים (Transactions).
*   **Dependency Injection:** מימוש הזרקת תלויות מובנית לשיפור המודולריות והקלה על כתיבת בדיקות יחידה.
*   **DTOs & AutoMapper:** הפרדה בין הישויות של בסיס הנתונים לבין המידע הנחשף ב-API להבטחת אבטחה וביצועים.

## 🔒 אבטחה ותפעול

*   **JWT:** מנגנון אבטחה מבוסס Token לאימות והרשאת משתמשים.
*   **Middleware:** הטמעת רכיבי Middleware מותאמים אישית לטיפול בשגיאות גלובליות ולוגים.
*   **Asynchronous Processing:** מימוש מקצה לקצה של עבודה אסינכרונית להבטחת ביצועים גבוהים וניצול מקסימלי של משאבי השרת.

## 🏃 הוראות הרצה

1.  שכפל את הרפוזיטורי (Clone).
2.  עדכן את ה-`ConnectionStrings` בקובץ `appsettings.json` לשרת ה-SQL המקומי שלך.
3.  הרץ את הפקודה הבאה ב-Package Manager Console ליצירת בסיס הנתונים:
    Update-Database
4. הרץ את הפרויקט (F5 ב-Visual Studio או dotnet run).
