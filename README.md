# resultant-review-application
This is a sample application used for interviewing candidates at Resultant.
<br>
<br>
.NET 8 API / Next.js 14 UI / Docker
<br>
<br>
This solution is a simple banking application that allows users to create accounts, 
withdrawal, deposit, and transfer between them.
<hr>
There are mistakes and bad code all throughout this solution, please take some notes and be ready to discuss.

### Possible Discussion Topics:

- What are some bad practices you identified?
- What are some things you would do to improve the solution?
- How would you improve duplicative code in the API? 
- How would you improve the UI navigation?
- How would you approach adding a `1:N` relationship between the users and accounts?
- What would be your approach to deploying this stack to the cloud?

### Running the Application

Prerequisites:
- Docker Desktop

Running:
1. From the root directory run `docker compose up --build`
2. Navigate to http://localhost:5005/swagger/index.html
3. Add user with 
     ```
    POST /api/users
    ```
4. Navigate to http://localhost:3000 and login with the user you created
5. Database is running @ localhost:9001
