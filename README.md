Pre-Requiste to run API code:
1. Run the script named "DB_Script.sql" from the folder in SQL management studio.Ensure TALDB has been created with two tables.
2. Open PremiumCalc.API folder and modify the connection string in the appsettings.JSON based on the SQL server configuration.
3. Rebuild the application

Pre-Requiste to run UI code:
1.Open PremiumCalcUI folder from visual studio code.
2. install npm packages from terminal by typing "npm install".
3.Open PremiumCalc.service.ts file from "PremiumCalcUI\src\app\shared" folder and replace the variable "rootURL" value with the base API url.

Best Practices used in API:
1. Request validation has been done using ValidationAttribute.
2. Logging mechanism has been implemeneted to capture the activities in the application and the exception
3. Generic exception handler mechanism has been implemented.
4. Unit test has been written and tested for all important functions.
5. Used automapper to map business object and data object

Best Practices used in UI:
1. Bootstrap is used for UI design
2. UI functionalities are validated
2. ToastrService package is used for error message display
