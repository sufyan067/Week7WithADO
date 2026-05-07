#  Patient Management System (Week 9)

##  Overview

This project is a full-stack Patient Management System built using:

- **Frontend:** Angular (Standalone Components)
- **Backend:** .NET Core Web API (ADO.NET)
- **Authentication:** JWT (JSON Web Token)

The application demonstrates secure communication between frontend and backend with protected API endpoints.

---

##  Authentication Flow

1. User enters credentials in Angular login form
2. Backend validates user via database
3. JWT token is generated and returned
4. Angular stores token in localStorage
5. Token is automatically attached to every API request via Interceptor
6. Backend validates token before allowing access

---

##  Authorization Strategy

- All sensitive endpoints are protected using `[Authorize]`
- Angular Route Guard prevents unauthorized access to protected routes
- If token is missing or invalid:
  - User is redirected to login page
  - Token is removed

---

##  Error Handling

Centralized error handling is implemented using Angular Interceptor:

- **401 Unauthorized**
  - User session cleared
  - Redirect to login

- **500 Server Error**
  - User notified via UI

---

##  Features

###  Authentication
- Login with JWT
- Secure API access

###  Patient Management
- Create Patient
- Update Patient
- Delete Patient
- Get All Patients
- Get Patient by ID

###  Frontend
- Reactive Forms with validation
- Clean UI layout
- Service-based API calls
- Environment-based configuration

---
##  UI Behavior Note

- All patient-related actions (Create, Update, Delete, Get) are fully integrated with the backend APIs.
- These operations are triggered via Angular UI buttons.
- For simplicity and focus on backend integration, API responses are currently displayed in the **browser console**.
- Data is not fully rendered on the UI (e.g., tables/lists) in this phase.

 This approach was intentionally used to emphasize:
- API integration
- Authentication flow
- Request/response handling

UI rendering can be extended in future iterations.

---

##  Authorization Scope

- Patient-related endpoints have been secured using `[Authorize]` and are fully integrated with JWT-based authentication.
- Appointment and Doctor endpoints were implemented in a previous phase (Week 7) and are currently not protected with authorization.

 This separation was maintained intentionally to focus on implementing and demonstrating authentication and authorization flow for a specific module (Patient   Management) in this phase.

 --- 
 
##  Key Concepts Learned

- JWT Authentication
- Angular Interceptors
- Route Guards
- API Contract Consistency
- Full-stack integration
- Secure communication

---
## Notes
- All API calls are secured
- No hardcoded URLs (environment config used)
- Clean architecture followed

---
##  Hosting Note

- Application is hosted using IIS
- Both frontend and backend are deployed and accessible via URLs

--- 
