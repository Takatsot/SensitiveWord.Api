# SensitiveWord.Api

This service would be to “bloop” out sensitive words of 
the company’s choice, on their chat system i.e., SQL sensitive words, profanity, or anything the 
company deems “Sensitive”. As an example, we have chosen our words to be in line with SQL key 
words. An example of this would be “SELECT” or “DROP” but could be any other word on the 
companies Sensitive list.

This API consist of the CRUD endpoints for internal consumptions - Note You can change the access modifiers to private for the
CRUD method as it was specified it's for internal use but for testing purposes i left them public.

Preloaded list - You will find the list of these words on the file folder on the solution (sql_sensitive_list.txt).
The documentation for the problem we were solving (Interview-SqlWords) 

********************* Deployment Walkthrough **********************

Go to helper folder and make sure the path to file is updated to your new path.

  SQL production server can be a SQL Azure or your own production server.
 1. You just need to change your local connection string to a production one and run below command on package manager.
 2. Generate a SQL script using dotnet ef migrations script and run it on your production database.
 Call dbContext.Database.Migrate() at runtime during application startup (but be careful when running multiple apps/database clients)
 
 Run The application and there's a preload endpoint that will help you with inserting all provided words on the file.
 
 Once that one is successful then you will be able to utilise the api
 ********************** END *************************************  
 
 Thank you very much for the opportunity i really had fun working on this API
 
