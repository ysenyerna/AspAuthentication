## ASP Authentication and Authorization Demo
Simple ASP.NET Core application which uses cookie-based authentication to allow users to log in. 
### Explanation
The application has a log in, a log out, and an admin page. The log in page asks the user to enter a username and
password, then validates the login based on the `data/users.json` file, which stores usernames and hashed 
passwords. If the user entered a valid username and password, they are logged in, a cookie is created, and 
they redirected to the admin page.   
If you try to open the admin page without logging in, it redirects you to the login page. To log out, use the
log out page, which erases the authentication cookie.
### Log In Page
The credentials to log in are:   
User: `admin`  
Password: `Password123`    
<img width="783" height="462" alt="login" src="https://github.com/user-attachments/assets/25c00fa4-585e-4448-aa84-6a25bc486082" />

### Admin Page
This page is only accessible when logged in.   
<img width="783" height="462" alt="admin" src="https://github.com/user-attachments/assets/e9694a52-1035-4891-9451-204db532f9c7" />

### Log Out Page
<img width="783" height="462" alt="logout" src="https://github.com/user-attachments/assets/dbaaed0c-5c8d-4af1-81aa-5f678f108fc3" />
