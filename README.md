# Task (BestStories Application)
The BestStories application fetches the best stories from Hacker News API and displays them. It is built using ASP.NET Core and includes Swagger UI for easy API testing.

**Prerequisites**

Before running the application, ensure that you have the following prerequisites installed:
.NET SDK (version 8.0 or later)

**Running the Application**

To run the BestStories application, follow these steps:

1. Clone the repository to your local machine:
git clone https://github.com/fayadas2/task.git

2. Build the application:
Run the application:

3. Once the application is running, open a web browser and navigate to the Swagger UI:
https://localhost:{port}/swagger/index.html

**About the Application**

The BestStories application fetches the best stories from the Hacker News API and displays them. It includes a Stories controller with an endpoint to retrieve the best stories.

**Improvements**

If time permits, consider the following improvements to the application:

**Data Storage:** Instead of fetching data from the Hacker News API on every request, store the retrieved stories in a database. This will minimize the number of calls to the Hacker News API and improve performance. You can use Entity Framework Core to interact with the database.
