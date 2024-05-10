# resultant-review-application

This is a sample application used for interviewing candidates at Resultant.
<br>
<br>
.NET 8 API / Next.js 14 UI / Ruby on Rails 7 / Docker
<br>
<br>
This solution is a simple banking application that allows users to create accounts,
withdrawal, deposit, and transfer between them.

The .NET API and Next.js UI work together to create a version of the application, while the Rails project is it's own version of the application

<hr>
Feel free to look at any part of the solution here, you can focus on the .NET, Next.JS, or Rails projects specifically if you want. There are mistakes and bad code all throughout this solution, please take some notes and be ready to discuss.

### Possible Discussion Topics:

- What are some bad practices you identified?
- What are some things you would do to improve the solution?
- How would you improve duplicative code in the .NET API?
- How would you improve the Next.js UI navigation?
- How would you improve security in the Rails project?
- How would you approach adding a `1:N` relationship between the users and accounts?
- What would be your approach to deploying this stack to the cloud?

### Running the .NET/Next.js Stack

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

### Running the Rails Project

Prerequisites:

- Docker Desktop

Running:

1. From the directory `ReviewApplication.Rails` run `docker compose up --build`
2. Navigate to http://localhost:3000/users/new and create an account
3. Log in
4. Database is running @ localhost:5559
